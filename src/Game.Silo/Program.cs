using Game.Facility.Grains;
using Orleans.Hosting;
using Orleans;
using System;
using System.Runtime.Loader;
using System.Threading.Tasks;
using System.Threading;
using Orleans.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Game.Facility.Interface;
using System.Net;
using Game.Core.Grains;
using Microsoft.Extensions.DependencyInjection;
using Game.Core.Interface;
using System.Runtime.CompilerServices;

using Game.Combat.Grains;
using System.Reflection.Metadata;
using Orleans.Providers.Streams.AzureQueue;
using Orleans.Storage;
using Game.Core.Grains.Cmd;

namespace Game.Silo
{
    class Program
    {
        private static ISiloHost silo;
        private static readonly ManualResetEvent siloStopped = new ManualResetEvent(false);
        static IConfiguration config;
        static void Main(string[] args)
        {
            config = new ConfigurationBuilder()

                            .AddJsonFile("appsettings.json", true, true)
                              .AddEnvironmentVariables()
                            .Build();


            //     Console.WriteLine($"DBConnection is :{dbConnection}");
            var siloBuilder = new SiloHostBuilder()
                .UseDashboard(option =>
                {

                })
                .Configure<ClusterOptions>(options =>
                {
                    options.ClusterId = config.GetValue<string>("ClusterId");
                    options.ServiceId = config.GetValue<string>("ServiceId");
                });
#if (DEBUG)

            siloBuilder = configLocalEnv(siloBuilder);
#else
            siloBuilder = configAzureEnv(siloBuilder, config);    
#endif





            siloBuilder.ConfigureApplicationParts(parts => parts.AddApplicationPart(typeof(Player).Assembly).WithReferences())
                       .ConfigureApplicationParts(parts => parts.AddApplicationPart(typeof(WorldService).Assembly).WithReferences())
                       .ConfigureApplicationParts(parts => parts.AddApplicationPart(typeof(Game.Combat.Grains.Combat).Assembly).WithReferences())
                       .ConfigureLogging(builder => builder.SetMinimumLevel(LogLevel.Warning).AddConsole())
                       .AddApplicationInsightsTelemetryConsumer(config.GetValue<string>("AIKey"))
                       .ConfigureAppConfiguration(c =>
                       {
                           c.AddJsonFile("appsettings.json", true, true)
                            .AddEnvironmentVariables();
                       })
                       .ConfigureServices(service =>
                       {
                           service.AddSingleton<ICharacterFactory, CharacterFactory>();
                           service.AddSingleton<RoomFactory>();

                       });

            silo = siloBuilder.Build();
            CommandHelper.BasePath = config.GetValue<string>(Constants.MudLibKey);
            Task.Run(StartSilo);

            AssemblyLoadContext.Default.Unloading += context =>
            {
                Task.Run(StopSilo);
                siloStopped.WaitOne();
            };

            siloStopped.WaitOne();
        }

        private static ISiloHostBuilder configAzureEnv(ISiloHostBuilder builder, IConfiguration config)
        {
          
            string dbConnection = config.GetValue<string>("dbconnection");

            builder.UseAzureStorageClustering(option =>
             {
                 option.ConnectionString = dbConnection;

             })
              .ConfigureEndpoints(siloPort: 11111, gatewayPort: 30000, listenOnAnyHostAddress: true)
                .AddAzureTableGrainStorageAsDefault(option =>
                {
                    option.ConnectionString = dbConnection;
                })
                .UseAzureTableReminderService(option =>
                {
                    option.ConnectionString = dbConnection;
                })
                .AddAzureTableGrainStorage("PubSubStore", option =>
                {
                    option.ConnectionString = dbConnection;
                })

               .AddAzureQueueStreams<AzureQueueDataAdapterV2>(Constants.NotifyStreamProvider,
                configurator => configurator.Configure(option =>
                {
                    option.ConnectionString = dbConnection;
                }))
                                .AddAzureQueueStreams<AzureQueueDataAdapterV2>(Constants.ChatStreamProvider,
                configurator => configurator.Configure(configure =>
                {
                    configure.ConnectionString = dbConnection;
                }));
            return builder;
        }
        private static ISiloHostBuilder configLocalEnv(ISiloHostBuilder builder)
        {
            builder.UseLocalhostClustering()
                .Configure<EndpointOptions>(options => options.AdvertisedIPAddress = IPAddress.Loopback)
                .AddMemoryGrainStorageAsDefault()
                .UseInMemoryReminderService()
                 .AddMemoryGrainStorage("PubSubStore")
                 .AddSimpleMessageStreamProvider(Constants.NotifyStreamProvider)
                 .AddSimpleMessageStreamProvider(Constants.ChatStreamProvider);

            return builder;
        }
        private static async Task StartSilo()
        {
            await silo.StartAsync();
            Console.WriteLine("Silo started");
        }

        private static async Task StopSilo()
        {
            await silo.StopAsync();
            Console.WriteLine("Silo stopped");
            siloStopped.Set();
        }
    }


}
