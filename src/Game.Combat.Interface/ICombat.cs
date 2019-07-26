using Orleans;
using System;
using System.Threading.Tasks;

namespace Game.Combat.Interface
{
   public interface ICombat:IGrainWithGuidKey
    {
        Task Start(string creator,string[] players);
        /// <summary>
        /// 终止战斗
        /// </summary>
        /// <returns></returns>
        Task Stop();

        /// <summary>
        /// 观战
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        Task Watch(string p);
    }
}
