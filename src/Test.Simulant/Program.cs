using CommandLine;

using System;
using System.IO;
using System.Net;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Test.Simulant
{
    class Program
    {
        public class Options
        {
            [Option("host", Default = "localhost")]
            public  string host { get; set; }
            [Option("port", Default = 4444)]
            public int port { get; set; }
            [Option("id",Default ="user")]
            public string Id { get; set; }

        }

        static ManualResetEvent connectDone, sendDone, receiveDone;
        static Random ran = new Random(DateTime.Now.Millisecond);
        static string[] dir = new string[] { "s", "n", "w", "e" ,"fy 狂风一翻滚，何处不是云"};
      
       
        static void Main(string[] args)
        {
            var result = Parser.Default.ParseArguments<Options>(args);
            CommandLine.Parser.Default.ParseArguments<Options>(args)
             .WithParsed<Options>(opts =>
             startClient(opts))
             .WithNotParsed<Options>((errs) =>
             {
                 Console.WriteLine("Arguments Error Error:{0}",errs);
             });
            Console.WriteLine("Press Enter to exit!");
            Console.ReadLine();
            
        }

        private async static void startClient(Options opts)
        {
            TcpClient client = new TcpClient();
            await client.ConnectAsync(opts.host, opts.port);

            var stream = client.GetStream();
            StreamWriter sw = new StreamWriter(stream);
            sw.AutoFlush = true;
            Task.Run( async () =>
            {
                StreamReader sr = new StreamReader(client.GetStream());
                while (true)
                {
                    var msg = await sr.ReadLineAsync();
                    Console.WriteLine(msg);
                }
            });

            //choose encoding
            sw.WriteLine("2");
            //login;
            sw.WriteLine(opts.Id);
            sw.WriteLine(opts.Id);
            while (true)
            {
                var seed = ran.Next(0, 100) % 5;
                sw.WriteLine(dir[seed]);
                Thread.Sleep(1000);
            }
        }

        private async void onData(object c)
        {
            TcpClient client = c as TcpClient;
         
        }
    }

    public class StateObject
    {
        // Client socket.  
        public Socket workSocket = null;
        // Size of receive buffer.  
        public const int BufferSize = 256;
        // Receive buffer.  
        public byte[] buffer = new byte[BufferSize];
        // Received data string.  
        public StringBuilder sb = new StringBuilder();
    }
}
