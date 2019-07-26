using Game.Core.Interface;
using Game.Facility.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Configuration;
using Orleans.Hosting;
using Orleans.Providers.Streams.AzureQueue;
using Orleans.Runtime;

using System;
using System.Linq;
using System.Runtime.Loader;
using System.Threading;
using System.Threading.Tasks;

namespace Game.Server
{
    public class Program
    {
        const int initializeAttemptsBeforeFailing = 5;
        private static readonly ManualResetEvent appStopped = new ManualResetEvent(false);
        private static int attempt = 0;
        static IConfiguration config;
        static void Main(string[] args)
        {

            config = new ConfigurationBuilder()

                           .AddJsonFile("appsettings.json", true, true)
                             .AddEnvironmentVariables()
                           .Build();

            var serviceCollection = new ServiceCollection();

            serviceCollection.AddSingleton<TelnetListener>();
            serviceCollection.AddSingleton<IClusterClient>((service) =>
            {
                var client = StartClientWithRetries().GetAwaiter().GetResult();

                return client;
            });
            serviceCollection.AddLogging(config =>
            {
                config.AddFilter((level) =>
                {
                    return true;
                });
                config.AddConsole();
            });
            var Container = serviceCollection.BuildServiceProvider();
            var serviceScopeFactory = Container.GetRequiredService<IServiceScopeFactory>();
            using (var scope = serviceScopeFactory.CreateScope())
            {
                var telnetListener = scope.ServiceProvider.GetService<TelnetListener>();
                telnetListener.OpenAsync(new CancellationToken()).GetAwaiter();
            }

            appStopped.WaitOne();


        }



        private static async Task<IClusterClient> StartClientWithRetries()
        {
            string dbConnection = config.GetValue<string>("dbconnection");

            attempt = 0;
            IClusterClient client;
            client = new ClientBuilder()
#if(DEBUG)
                .UseLocalhostClustering()
                .AddSimpleMessageStreamProvider(Constants.NotifyStreamProvider)
                 .AddSimpleMessageStreamProvider(Constants.ChatStreamProvider)
#else
                .UseAzureStorageClustering(option =>
                {
                    option.ConnectionString = dbConnection;
                    
                })
               .AddAzureQueueStreams<AzureQueueDataAdapterV2>(Constants.NotifyStreamProvider,
                configurator => configurator.Configure(configure =>
                {
                    configure.ConnectionString = dbConnection;
                }))
                 .AddAzureQueueStreams<AzureQueueDataAdapterV2>(Constants.ChatStreamProvider,
                configurator => configurator.Configure(configure =>
                {
                    configure.ConnectionString = dbConnection;
                }))

#endif
                .Configure<ClusterOptions>(options =>
                {
                    options.ClusterId = config.GetValue<string>("ClusterId");
                    options.ServiceId = config.GetValue<string>("ServiceId");
                })
                .AddClusterConnectionLostHandler((e, v) =>
                {

                })
               //  


              //     
              .AddApplicationInsightsTelemetryConsumer(config.GetValue<string>("AIKey"))
                .Build();

            await client.Connect(RetryFilter);
            Console.WriteLine("Client successfully connect to silo host");
            return client;
        }

        private static async Task<bool> RetryFilter(Exception exception)
        {
            if (exception.GetType() != typeof(SiloUnavailableException) && exception.GetType() != typeof(OrleansMessageRejectionException))
            {
                Console.WriteLine($"Cluster client failed to connect to cluster with unexpected error.  Exception: {exception}");
                return false;
            }
            attempt++;
            Console.WriteLine($"Cluster client attempt {attempt} of {initializeAttemptsBeforeFailing} failed to connect to cluster.  Exception: {exception}");
            if (attempt > initializeAttemptsBeforeFailing)
            {
                return false;
            }
            await Task.Delay(TimeSpan.FromSeconds(10));
            return true;
        }

    }
}
