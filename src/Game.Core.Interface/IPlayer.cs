
using Game.Core.Interface.Enum;
using Orleans;
using Orleans.Concurrency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Interface
{
    public interface IPlayer: IGrainWithStringKey, IInteroperable
    {
        Task Login();
        Task<PlayerState> Get();
        Task<bool> CheckPassword(string pwd);

        Task<bool> ChangePassword(string newPwd, string oldPwd);

       
        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>

   
       
        Task Quit();
        Task EnterRoom(string dir,string newRoomId);
        Task Set(string prop, object value);
        Task<T> Query<T>(string prop);
        Task Kill(string target);
        Task Look(string target);
        [AlwaysInterleave]
        Task Notify(string msg,NotifyType type= NotifyType.Message);
    }
}
