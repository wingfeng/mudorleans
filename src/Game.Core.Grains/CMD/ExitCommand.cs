using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using Game.Core.Interface;

namespace Game.Core.Grains.Cmd
{
    [Verb("exit", "quit", HelpText = "离开游戏\r\n")]
    public class ExitCommand : CommandBase
    {
        protected override async Task<int> OnExecute()
        {
          
            await Player.Quit();
           
            return 0;
        }
    }
}
