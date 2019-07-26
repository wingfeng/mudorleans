using Orleans;
using System;
using System.Threading.Tasks;

namespace Game.Core.Interface
{
    public interface ICommand: IGrainWithStringKey
    {
        Task Execute(string args);
    }
}
