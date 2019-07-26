using CommandLine;
using Game.Core.Interface;
using Game.Core.Interfaces;
using Game.Facility.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Grains.Cmd
{
    //"go","up","down","en","s","sw","se","e","ne","n","nw","w"
    [Verb("fy", HelpText = "向风云频道说话!\r\n")]
    public class cFyCommand : CommandBase
    {
       
   
        [Value(0)]
        public IEnumerable<string> Msg { get; set; }
        //public override List<string> CreateArgs()
        //{
        //    return new List<string>();
        //}

        protected override async Task<int> OnExecute()
        {
           var channel= GrainFactory.GetGrain<IChannel>(Constants.PublicChannelId);
            var ps =await Player.Get();
            ChatMsg msg = new ChatMsg();
            msg.Author = ps.Short;
            msg.ChannelName = $"【{AnsiConst.HIM}风云{AnsiConst.NOR}】";

            foreach (var s in Msg)
            {
                msg.Text += " " + s;
            }

            await channel.Message(msg);
            return 0;
        }
    }
}
