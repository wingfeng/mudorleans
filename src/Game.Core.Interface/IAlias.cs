using Orleans;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Interface
{
    public interface IAlias:IGrainWithStringKey
    {
        Task SetAlias(string alias, string cmd);
        Task<Dictionary<string, string>> Get();
    }
}
