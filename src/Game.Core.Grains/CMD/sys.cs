using CommandLine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Grains.Cmd
{
    [Verb("sys", HelpText = "获取服务器和本地信息！")]
    public class sysInfo : CommandBase
    {
        protected async override Task<int> OnExecute()
        {
            StringBuilder sb = new StringBuilder();
            //sb.AppendLine($"Client Address:{Session.socketClient.Client.RemoteEndPoint}");
            //sb.AppendLine($"Server Address:{Session.socketClient.Client.LocalEndPoint}");
            //sb.AppendLine($"Session Id:{Session.Id}");
            sb.AppendLine($"Server Version:{FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).ProductVersion}");
            await Player.Notify(sb.ToString());
            return 0;
        }
    }
}
