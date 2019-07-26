using Game.Core.Grains;
using Game.Core.Interface;
using Game.Facility.Grains;
using Game.Facility.Interface;
using Game.MudLib.d.fy;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Configuration;
using Orleans.Hosting;
using Orleans.Runtime;
using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.Loader;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game.Test
{
   public class LocalTestSiloClient
    {
        private static readonly ManualResetEvent siloStopped = new ManualResetEvent(false);
        private static ISiloHost silo;
        public static async void createSilo()
        {
            const string connectionString = "Server=10.0.75.1;Initial Catalog=Orleans;Persist Security Info=False;User ID=sa;Password=P@ssword0;MultipleActiveResultSets=False;Connection Timeout=30;";
            silo = new SiloHostBuilder()
                .Configure<ClusterOptions>(options =>
                {
                    options.ClusterId = "Test";
                    options.ServiceId = "MudGame";
                })
               .UseLocalhostClustering()
               .Configure<EndpointOptions>(options => options.AdvertisedIPAddress = IPAddress.Loopback)
                //.UseAdoNetClustering(options =>
                //{
                //    options.ConnectionString = connectionString;
                //    options.Invariant = "System.Data.SqlClient";
                //})
                .ConfigureEndpoints(siloPort: 11111, gatewayPort: 30000)
                .AddMemoryGrainStorageAsDefault()

                  .AddMemoryGrainStorage("PubSubStore")
                 .AddSimpleMessageStreamProvider(Constants.NotifyStreamProvider)
                .ConfigureApplicationParts(parts => parts.AddApplicationPart(typeof(Player).Assembly).WithReferences())
                .ConfigureApplicationParts(parts => parts.AddApplicationPart(typeof(WorldService).Assembly).WithReferences())

                .ConfigureLogging(builder => builder.SetMinimumLevel(LogLevel.Critical))
                .ConfigureServices(async service =>
                {
                    RoomFactory rf = new RoomFactory();
                    rf.BornRoom = typeof(fysquare).FullName; //将风云广场设置为出生地；
                    await rf.Init(typeof(fysquare).Assembly);
                    service.AddSingleton<RoomFactory>(rf);

                })
                .Build();

          await  StartSilo();

            AssemblyLoadContext.Default.Unloading += context =>
            {
                Task.Run(StopSilo);
                siloStopped.WaitOne();
            };

            siloStopped.WaitOne();
        }
        private static async Task StartSilo()
        {
            await silo.StartAsync();
            Console.WriteLine("Silo started");
        }

        public static async Task StopSilo()
        {
            await silo.StopAsync();
            Console.WriteLine("Silo stopped");
            siloStopped.Set();
        }
        static int attempt;
        public static async Task<IClusterClient> createClient()
        {
            string strConnection = "Server=10.0.75.1;Initial Catalog=Orleans;Persist Security Info=False;User ID=sa;Password=P@ssword0;MultipleActiveResultSets=False;Connection Timeout=30;";

            attempt = 0;
            IClusterClient client;
            client = new ClientBuilder()
                .UseLocalhostClustering()
              //.ConfigureHostConfiguration(config =>
              //{
                  
              //})
                //.UseAdoNetClustering(options =>
                //{
                //    options.ConnectionString = strConnection;
                //    options.Invariant = "System.Data.SqlClient";
                //})
                .Configure<ClusterOptions>(options =>
                {
                    options.ClusterId = "test";
                    options.ServiceId = "MudGame";
                })

                .AddSimpleMessageStreamProvider(Constants.NotifyStreamProvider)
                .ConfigureLogging(logging => logging.SetMinimumLevel(LogLevel.Critical))
                .Build();

            await client.Connect(RetryFilter);
            Console.WriteLine("Client successfully connect to silo host");
            return client;
        }
        const int initializeAttemptsBeforeFailing = 5;
        private static async Task<bool> RetryFilter(Exception exception)
        {
            if (exception.GetType() != typeof(SiloUnavailableException))
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
            await Task.Delay(TimeSpan.FromSeconds(4));
            return true;
        }
    }
}
