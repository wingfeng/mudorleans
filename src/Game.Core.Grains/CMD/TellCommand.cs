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
    [Verb("tell", HelpText ="向某人说话!\r\n格式:tell {someone} something\r\n")]
    public class TellCommand : CommandBase
    {
     
        [Value(0)]
        public string Who { get; set; }
        [Value(1)]
        public IEnumerable<string> Msg { get; set; }
        //public override List<string> CreateArgs()
        //{
        //    return new List<string>();
        //}

        protected override async Task<int> OnExecute()
        {
           
            var Target = GrainFactory.GetGrain<IPlayer>(Who);
            var state =await Target.Get();
            var channel = GrainFactory.GetGrain<IChannel>(state.guid);
            var ps = await Player.Get();
            ChatMsg msg = new ChatMsg();
            msg.Author = ps.Short;
            msg.ChannelName = $"【{AnsiConst.HIG}私聊{AnsiConst.NOR}】 ";
            foreach(var s in Msg)
            {
                msg.Text += " " + s; 
            }
           
            await channel.Message(msg);
            var selfMsg = $"【{AnsiConst.HIG}私聊{AnsiConst.NOR}】你对{AnsiConst.HIM+state.Short+AnsiConst.NOR}说道:{msg.Text}";
             await Player.Notify(selfMsg);
            return 0;
        }
    }
}
