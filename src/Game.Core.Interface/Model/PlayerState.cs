
using Game.Core.Interface.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Interface
{
    public class PlayerState:HumanState
    {
       
        public Guid guid { get; set; }
      //  public string id { get; set; }
        public string Server { get; set; }
        public string RoomId { get; set; }
        public string Short { get; set; }
        public string Long { get; set; }
        public PlayerStatus Status { get; set; }
        public string PasswordHash { get; set; }
        public DateTime LastActive { get; set; }

    }
}
