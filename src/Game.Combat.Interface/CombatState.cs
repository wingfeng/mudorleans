using Game.Core.Interface.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Game.Combat.Interface
{
   public class CombatState
    {
       
     
        public CharacterState Attacker { get; set; }
        public int Turns { get; set; }
        public CharacterState Defender { get; set; }
        public Guid id { get; set; }
        public string Creater { get; set; }
        public DateTime StartTime { get; set; }
        public List<string> Contributers { get; set; }
        public List<string> Watcher { get; set; }


    }
}
