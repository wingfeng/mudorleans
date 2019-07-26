using CommandLine;
using Game.Core.Interface;
using Game.Core.Interfaces;
using Game.Facility.Interface;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Grains.Cmd
{
    //"go","up","down","en","s","sw","se","e","ne","n","nw","w"
    [Verb("reset", HelpText ="重置命令编译缓存")]
    public class ResetCommand : CommandBase
    {


        protected override async Task<int> OnExecute()
        {

            CommandHelper.CommandScripts.Clear();
            var world = GrainFactory.GetGrain<IWorld>(0);
            await world.Reset("");
            Player.Notify("Reset Finished!");
            return 0;
        }
    }
}
