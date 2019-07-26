using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Interface
{
    public enum PlayerStatus
    {
        Connecting,
        Active,
        Offline,
        Idle,
        NotExist
    }

    public enum PlayerEvent
    {
        RoomChange,
        BeginCombat
    }
}
