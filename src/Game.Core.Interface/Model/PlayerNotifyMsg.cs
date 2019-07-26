using Game.Core.Interface.Enum;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Game.Core.Interface.Model
{
    public class PlayerNotifyMsg
    {
        public NotifyType Type { get; set; }

        public string Message { get; set; }
    }
}
