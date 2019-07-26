using Game.Core.Interface.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Interface
{
   public interface ICharacterFactory
    {
        Task<CharacterState> create(string id);
    }
}
