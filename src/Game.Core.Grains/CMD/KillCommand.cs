using CommandLine;
using Game.Combat.Interface;
using Game.Core.Interface;
using Game.Core.Interfaces;
using Game.Facility.Interface;
using Newtonsoft.Json.Schema;
using Orleans.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Grains.Cmd
{
    //"go","up","down","en","s","sw","se","e","ne","n","nw","w"
    [Verb("kill", HelpText ="向对手下达战斗指令\r\n格式:kill {someone} {index}\r\n当同样id的对手多于一个时可通过index参数来指定")]
    public class KillCommand : CommandBase
    {
     
        [Value(0)]
        public string Who { get; set; }
        [Value(1)]
        public int index { get; set; }
        //public override List<string> CreateArgs()
        //{
        //    return new List<string>();
        //}

        protected override async Task<int> OnExecute()
        {
           
            
            var state =await Player.Get();
            var targetId = await getLongNPCId(state.RoomId);
            if (string.IsNullOrWhiteSpace(targetId))
            {
                await Player.Notify(@"你要杀谁? {who}好像不在附近");
            }
            else
            {
                //以发起玩家的guid作为战斗的Id;
                var combat = GrainFactory.GetGrain<ICombat>(state.guid);


                await combat.Start(state.Short, new string[] { targetId });
            }
        
            return 0;
        }
        private  async Task<string> getLongNPCId(string roomId)
        {
            var room =await GrainFactory.GetGrain<IRoom>(roomId).Get();
           
            foreach(var s in room.NPCs)
            {
                string str2Match = $".{Who}_{index}";
                if (s.LastIndexOf(str2Match) == s.Length-str2Match.Length)
                    return s;
            }
            return "";
        }
    }
}
