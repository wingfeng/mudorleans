using CommandLine;
using Game.Core.Grains;
using Game.Core.Interface;
using Game.Facility.Interface;
using Orleans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Grains.Cmd
{
    //"go","up","down","en","s","sw","se","e","ne","n","nw","w"
    [Verb("go","up", "down", "en", "s", "sw", "se", "e", "ne", "n", "nw", "w", HelpText ="向某个方向移动或者进入房间。\r\n")]
    public class GoCommand : CommandBase
    {
     
        [Value(0)]
        public string Dir { get; set; }
        //public override List<string> CreateArgs()
        //{
        //    return new List<string>();
        //}

        protected override async Task<int> OnExecute()
        {

          
            var ps = await Player.Get();
            var room = GrainFactory.GetGrain<IRoom>(ps.RoomId);
            var roomState = await room.Get();
            var newRoomId = roomState.Exits.Where(o => string.Equals(o.Key, Dir, StringComparison.CurrentCultureIgnoreCase)).FirstOrDefault().Value;


            if (!string.IsNullOrWhiteSpace(newRoomId))
                await Player.EnterRoom(Dir,newRoomId);
            else
                await Player.Notify($"你要到哪里去？{Dir}方向好像没有出口");
            return 0;
        }
    }
}
