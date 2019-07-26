using Game.Core.Interface;
using Game.Facility.Interface;
using Orleans;
using Orleans.MultiCluster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Grains.Cmd
{
    //public class Command : CommandBase
    //{
   
    //    //public override List<string> CreateArgs()
    //    //{
    //    //    return new List<string>();
    //    //}
    //}

   
   public abstract class CommandBase
    {
        protected IGrainFactory GrainFactory;
        public async Task Execute(IPlayer player,IGrainFactory factory)
        {
            Player = player;
            GrainFactory = factory;
       
            await OnExecute();
        }
       protected IPlayer Player;
   
        //   public abstract List<string> CreateArgs();

        protected abstract Task<int> OnExecute();
      
    }

}
