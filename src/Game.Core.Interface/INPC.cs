using Game.Core.Interface.Model;
using Orleans;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Interface
{
    /// <summary>
    /// NPC接口
    /// </summary>
    public interface INPC:IGrainWithStringKey
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ticks"></param>
        Task Beat(long ticks);
        Task<CharacterState> Get();
    }
}
