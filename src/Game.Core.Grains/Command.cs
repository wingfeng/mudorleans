using Game.Core.Grains.Cmd;
using Game.Core.Interface;
using Game.Facility.Interface;
using Orleans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Grains
{
    public class Command : Grain, ICommand
    {
        IPlayer player;
        public override Task OnActivateAsync()
        {
            player = GrainFactory.GetGrain<IPlayer>(this.GetPrimaryKeyString())
;            return base.OnActivateAsync();
        }
        public async Task Execute(string com)
        {

            var args = com.Split(' ');
      

       
            await CommandHelper.Exec(args, player,GrainFactory);
        }
    }
}
