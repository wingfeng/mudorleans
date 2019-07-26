using Orleans;
using Orleans.Concurrency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Facility.Interface
{
   public interface IWorld:IGrainWithIntegerKey
    {
      

        Task<string> GetBornplaceId();
        Task<bool> PlayerLogin(string account, string password);

        Task<bool> Register(string account,string Password);

        Task Reset(string id);
    }
}
