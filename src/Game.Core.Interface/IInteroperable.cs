using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Interface
{
    public interface IInteroperable
    {
        Task<List<string>> GetCommands();

    }
}
