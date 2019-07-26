
using Orleans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Facility.Interface
{
    public interface IRoom: IGrainWithStringKey
    {
        Task<RoomState> Get();

        Task<string> GetText();
        Task<RoomState> Enter(string player);
        Task<bool> Leave(string player,string dir);
        /// <summary>
        /// 查询房间内的玩家
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Task<string> QueryPlayer(string name);
        /// <summary>
        /// 查询出口
        /// </summary>
        /// <returns></returns>
       Task< List<KeyValuePair<string,string>>> QueryEntry();
    }
}
