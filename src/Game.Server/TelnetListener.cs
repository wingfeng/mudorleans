using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using Orleans;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace Game.Server
{
    public class TelnetListener
    {

        ILogger logger;
        private Thread listenThread;
        private TcpListener tcpListener;
        private Dictionary<Guid, Thread> playerThreadList = new Dictionary<Guid, Thread>();
        private List<PlayerSession> sessions = new List<PlayerSession>();
        private Dictionary<string, PlayerSession> players = new Dictionary<string, PlayerSession>();
        IClusterClient orleansClient;
        public Dictionary<string, PlayerSession> Players
        {
            get { return players; }
        }

        public List<PlayerSession> Sessions
        {
            get { return sessions; }
        }
        private object playerLocker = new object();

        public TelnetListener(IClusterClient client, ILogger<TelnetListener> log)
        {
            orleansClient = client;
            logger = log;

        }

        public void Abort()
        {
            //do nothing;
        }

        public Task CloseAsync(CancellationToken cancellationToken)
        {
            //do nothing;
            return Task.FromResult(0);
        }

        public Task<string> OpenAsync(CancellationToken cancellationToken)
        {

            //Todo:Build a Client Thread Pool;
            this.tcpListener = new TcpListener(IPAddress.Parse("0.0.0.0"), 4444);
            logger.LogTrace("Begin listen on 4444");
            this.listenThread = new Thread(new ThreadStart(ListenForClients));
            this.listenThread.Start();
            return Task.FromResult("");
        }

        private async void ListenForClients()
        {
            //start our listener socket
            this.tcpListener.Start();

            //start infinite listening loop
            while (true)
            {

                try
                {
                    var cancellation = new CancellationTokenSource();
                    logger.LogTrace("Waiting for client...");
                    var clientTask = this.tcpListener.AcceptTcpClientAsync();
                    if (clientTask.Result != null)
                    {
                        logger.LogTrace("Client connected. Waiting for data.");
                        var client = clientTask.Result;
                        //when it does, we'll create a new player instance, passing in some stuff
                        PlayerSession session = new PlayerSession(client, orleansClient, logger)
                        {
                        };

                        session.OnPlayerLogined += Player_OnPlayerLogined;
                        session.OnPlayerQuited += Session_OnPlayerQuited;
                        //then let's create a new thread and initialize our player instance
                        Thread clientThread = new Thread(new ParameterizedThreadStart(session.Initialize));
                        clientThread.Start();
                    }
                }
                catch (Exception err)
                {
                    logger.LogError("player session error", err);

                }
            }
        }

        private void Session_OnPlayerQuited(object sender, EventArgs e)
        {
            
        }

        private void Player_OnPlayerLogined(object sender, EventArgs e)
        {
            var player = sender as string;
            //if (!players.ContainsKey(player))
            //    this.players.Add(player, playerProxy);
        }

        public void RemovePlayer(PlayerSession player)
        {
            lock (playerLocker)
            {
                this.sessions.Remove(player);
            }
        }

    }
}
