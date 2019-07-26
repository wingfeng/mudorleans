using Autofac;
using CommandLine;
using Game.Core.Interface;
using Game.Core.Interface.Enum;
using Game.Core.Interface.Model;
using Game.Core.Interfaces;
using Game.Facility.Interface;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Storage;
using Orleans.Streams;
using Orleans.Streams.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Net;
using System.Net.Sockets;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace Game.Server
{
    public class PlayerSession : IAsyncObserver<PlayerNotifyMsg>, IAsyncObserver<ChatMsg>
    {
        private static string welcomeText;
        static string WelcomeText
        {
            get
            {
                if (string.IsNullOrEmpty(welcomeText))
                {
                    welcomeText=File.ReadAllText("welcome.txt");
                }
                return welcomeText;
            }
        }
        private Guid sessionId;

        ContainerBuilder builder = new ContainerBuilder();
        CancellationTokenSource cancelToken = new CancellationTokenSource();
        IContainer container;
        StreamReader sr;
        StreamWriter sw;
        StreamWriter swgb;
        private EndPoint clientEndPoint;
        IClusterClient oClient;
        StreamSubscriptionHandle<PlayerNotifyMsg> streamHandler;
        StreamSubscriptionHandle<ChatMsg> chatStreamHandler;
        internal TcpClient socketClient { get; set; }
        internal PlayerState State { get; set; }
        Dictionary<string, string> alias;
        internal IPlayer Player;
        internal IWorld World;
        bool connected;
        public StreamWriter Out
        {
            get
            {
                if (EncodingIsGB)
                {
                    return swgb;
                }
                return sw;
            }
        }
        public ILogger logger;
        public event EventHandler OnPlayerLogined;
        public event EventHandler OnPlayerQuited;
        public bool EncodingIsGB { get; set; }
        public Guid Id
        {
            get
            {
                return sessionId;
            }
        }
        public IClusterClient GrainClient
        {
            get { return oClient; }
        }

        public PlayerSession(TcpClient socket, IClusterClient oClient, ILogger log)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            sessionId = Guid.NewGuid();
            logger = log;
            this.oClient = oClient;


            this.socketClient = socket;
            clientEndPoint = socketClient.Client.RemoteEndPoint;
            connected = true;

            sr = new StreamReader(socket.GetStream());

            sw = new StreamWriter(socket.GetStream());
            swgb = new StreamWriter(socket.GetStream(), Encoding.GetEncoding("GB2312"));
            swgb.AutoFlush = true;
            sw.AutoFlush = true;


            container = builder.Build();

        }

        public async void Notify(string msg, bool withPrompt = true)
        {
            if (!connected)
                return;

            if (withPrompt)
            {
#if (DEBUG)
                msg = msg + $"\r\n{State?.id}>";
#else
            msg = msg + $"\r\n>";
            
#endif
            }
            try
            {
                if (EncodingIsGB)
                    await swgb.WriteLineAsync(msg);
                else
                    await sw.WriteLineAsync(msg);
            }
            catch (Exception err)
            {
                logger.LogError(err, $"Session ID:{sessionId}\r\nWrite message {msg} to client {clientEndPoint} error:\r\n");
            }
        }
        public async Task<string> readLineAsync()
        {
            try
            {

                var command = await sr?.ReadLineAsync();
                if (command == null)
                    connected = false;
#if (DEBUG)
                logger.LogTrace("Client input:{0}", command);
#endif
                return command;
            }
            catch (Exception err)
            {
                logger.LogError(err, $"Client {clientEndPoint} offline!");
                connected = false;
            }
            return null;
        }
        private async Task chooseEncoding()
        {
            string msg = "请选择你的字符编码(GB2312) 1\\";
            swgb.Write(msg);
            msg = "请选择你的字符编码(UTF8) 2";
            sw.WriteLine(msg);

            var choice = await readLineAsync();

            if (string.Equals("1", choice, StringComparison.CurrentCultureIgnoreCase))
            {
                EncodingIsGB = true;
                return;
            }
            else if (string.Equals("2", choice, StringComparison.CurrentCultureIgnoreCase))
            {
                EncodingIsGB = false;
                return;
            }
            await chooseEncoding();
        }
        public async Task Login()
        {
            bool accountValidated = false;


            string msg = "\r\n请输入你的账号:";
            string account = "";
            while (!accountValidated && socketClient.Connected)
            {

                Notify(msg, false);
                account = await readLineAsync();
                if (account != null)
                {
                    var match = Regex.Match(account, "^[a-zA-z][a-zA-Z0-9_]{3,9}$");
                    if (!string.IsNullOrWhiteSpace(match.Value))
                    {
                        account = match.Value;
                        break;
                    }
                }
                msg = "账号的格式非法，应该是以字母开头以下划线或者数组组合不少于4个字符不超过9个字符的字串！\r\n";
                Notify(msg, true);
            }
            msg = $"欢迎{account} ,请输入你的密码：";

            Notify(msg, false);

            var strPassword = await readLineAsync();
            World = oClient.GetGrain<IWorld>(0);
            var loginResult = false;
            try
            {
                loginResult = await World.PlayerLogin(account, strPassword);
            }
            catch (Exception err)
            {
                Notify("系统好像发生了什么问题，请联系管理员!", true);
                logger.LogError(err, $"用户登录错误{account}");
                if (socketClient.Connected)
                    Login();
            }
            if (loginResult)
            {
                Notify($"{AnsiConst.CLR}");
                Player = oClient.GetGrain<IPlayer>(account);
                var AliasService = oClient.GetGrain<IAlias>(account);
                alias = await AliasService.Get();
                State = await Player.Get();
                var stream = oClient.GetStreamProvider(Constants.NotifyStreamProvider)
                    .GetStream<PlayerNotifyMsg>(State.guid, Constants.NotifyStreamNamespace);
                streamHandler = await stream.SubscribeAsync(this);
                //订阅公共聊天频道
                var streamChat = oClient.GetStreamProvider(Constants.ChatStreamProvider).GetStream<ChatMsg>(Constants.PublicChannelId, Constants.ChatStreamNamespace);
                chatStreamHandler = await streamChat.SubscribeAsync(this);
                //订阅个人频道
                streamChat = oClient.GetStreamProvider(Constants.ChatStreamProvider).GetStream<ChatMsg>(State.guid, Constants.ChatStreamNamespace);
                await streamChat.SubscribeAsync(this);
                //触发用户登入事件；
                OnPlayerLogined?.Invoke(account, new EventArgs() { });




                return;




            }
            else
            {
               
                Notify("账号密码错误，再见!", false);
                await Quit();
            }

        }
        private async Task waitCommand()
        {
            while (connected)
            {
                var cmd = await readLineAsync();
                await execCommand(cmd);
            }
        }

        private async Task execCommand(string com)
        {

            try
            {
                if (!string.IsNullOrWhiteSpace(com))
                {
                    var args = com.Split(' ');
                    if (alias.ContainsKey(args[0]))
                    {
                        args[0] = alias[args[0]];
                        com = string.Join(' ', args);  //处理别名里也有空格的问题，先重新拼接在分解；
                    }
                    State.LastActive = DateTime.Now;
                    var cmd=oClient.GetGrain<ICommand>(State.id);
                    await cmd.Execute(com);
                 


                }
            }

            catch (Exception err)
            {
                logger.LogError(err, "系统错误!");
                Notify("系统似乎发生了什么问题...", true);
            }
        }





        internal async void Initialize(object obj)
        {
            Notify(WelcomeText, false); try
            {
                await chooseEncoding();
                await Login();
               await waitCommand();
            }
            catch (Exception err)
            {
                logger.LogWarning($"Client {socketClient.Client.RemoteEndPoint} connection fail!");
            }

        }

        public async Task Quit()
        {
            try
            {
                connected = false;
                
                await chatStreamHandler?.UnsubscribeAsync();
                await streamHandler?.UnsubscribeAsync(); //取消订阅消息
                //  socketClient.GetStream().Flush();
                OnPlayerQuited?.Invoke(this, new EventArgs());
               
                Thread.Sleep(10);
                //  this.Server.RemovePlayer(this);


            }
            catch (Exception err)
            {
                logger.LogError(err, "用户退出,错误");
            }
            finally
            {
                this.socketClient.GetStream().Dispose();
                //             cancelToken.Cancel();
            }
        }

        public async Task OnNextAsync(PlayerNotifyMsg item, StreamSequenceToken token = null)
        {
            switch (item.Type)
            {
                case NotifyType.Message:
                    Notify(item.Message, false);
                    break;
                case NotifyType.System:
                    if (string.Equals("exit", item.Message, StringComparison.CurrentCultureIgnoreCase))
                        await Quit();
                    break;
            }
            
        }

        public async Task OnCompletedAsync()
        {
            logger.LogCritical("Player Notify Stream Completed!");
        }

        public async Task OnErrorAsync(Exception ex)
        {
            logger.LogError(ex, "Player Nofity Stream Error:");
            Notify("好像除了什么问题，但是你有说不出来");
            //  log error to logger;
        }

        public async Task OnNextAsync(ChatMsg item, StreamSequenceToken token = null)
        {
            string msgToClient = $"{item.ChannelName} {item.Author}:{item.Text}";
            if (EncodingIsGB)
            {
                msgToClient = Utf8ToGB2312(msgToClient);
            }

            Notify(msgToClient);
        }
        public string Utf8ToGB2312(string utf8String)
        {
            Encoding fromEncoding = Encoding.UTF8;
            Encoding toEncoding = Encoding.GetEncoding("gb2312");
            return EncodingConvert(utf8String, fromEncoding, toEncoding);
        }
        public string EncodingConvert(string fromString, Encoding fromEncoding, Encoding toEncoding)
        {
            byte[] fromBytes = fromEncoding.GetBytes(fromString);
            byte[] toBytes = Encoding.Convert(fromEncoding, toEncoding, fromBytes);

            string toString = toEncoding.GetString(toBytes);
            return toString;
        }
    }
}
