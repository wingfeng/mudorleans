
using CommandLine;
using Game.Core.Interface;
using Game.Facility.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Grains.Cmd
{
    
    [Verb("look","l",HelpText = "alias: l ,查看当前所处的地形，或者查看某个具体的物体。\r\n")]
    public class LookCommand : CommandBase
    {

        // You can use this pattern when the parent command may have options or methods you want to
        // use from sub-commands.
        // This will automatically be set before OnExecute is invoked
     
    

         [Value(0)]
        string Target { get; set; }
        //public override List<string> CreateArgs()
        //{
        //    return new List<string>();
        //}
        protected override async Task<int> OnExecute()
        {
            await look_Room(Target);
            return 0;
        }
        private async Task look_Room(string entry)
        {

            var sb = new StringBuilder();
            //如果查看的出口为空，就查看当前房间；
            if (string.IsNullOrWhiteSpace(entry))
            {
                var state = await Player.Get();
                var room = GrainFactory.GetGrain<IRoom>(state.RoomId);
                var text =await room.GetText();
                await Player.Notify(text);
           //     console.WriteLine(text);
            }
            
        }
    }
}
