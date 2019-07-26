using Game.Core.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Facility.Interface
{
    public class RoomState:Dictionary<string, string>
    {

       
        public Dictionary<string, string> Tag = new Dictionary<string, string>();

        string _dir;
        public string __DIR__
        {
            get
            {
            
                return _dir;
            }
            set
            {
                _dir=value;
            }
        }
        public RoomState()
        {
          
            Players = new List<string>();
            NPCs = new List<string>();
        }
    
        /// <summary>
        /// 用于初始化某个房间的状态
        /// </summary>
        /// <returns></returns>

        public Dictionary<string, string> Exits { get; set; }
        public string Id { get; set; }

        public string Short { get; set; }
        public string Long { get; set; }
        public List<string> Players { get; set; }

        public List<string> NPCs { get; set; }
        public virtual bool validate_leave(IPlayer me,string dir)
        {
            return true;
        }
        protected void set(string property, object value)
        {
            property = property.ToLower();
            switch (property)
            {
                case "short":
                    this.Short = value.ToString();
                    break;
                case "long":
                    this.Long = value.ToString();
                    break;
                case "exits":
                    this.Exits = (Dictionary<string, string>)value;

                    break;
                case "objects":
                    var val = (Tuple<string, int>)value;
                    for (int i = 0; i < val.Item2; i++)
                    {
                        var orgId = val.Item1;
                        var id = string.Format("{0}_{1}", val.Item1, i);
                        this.NPCs.Add(id);
                    }
                    //                 state.InitNPCs.Add((Tuple<string,int>)value);
                    break;
                default:
                    if (this.ContainsKey(property))
                        this[property] = value?.ToString();
                    else
                        this.Add(property, value?.ToString());
                    break;
            }
        }

        public virtual void create()
        {
            Id = GetType().FullName;
        }

        string dir_chinese(string dir)
        {
            switch (dir)
            {
                case "east": return "东面";
                case "west": return "西面";
                case "north": return "北面";
                case "south": return "南面";
                case "enter": return "里面";
                case "out": return "外面";
                case "southeast": return "东南面";
                case "northwest": return "西北面";
                case "southwest": return "西南面";
                case "northeast": return "东北面";
                case "northup": return "北上方";
                case "eastup": return "东上方";
                case "southup": return "南上方";
                case "westup": return "西上方";
                case "up": return "上面";
                case "down": return "下面";
                case "eastdown": return "东下方";
                case "westdown": return "西下方";
                case "southdown": return "南下方";
                case "northdown": return "北下方";
                default: return dir;
            }
        }
        string anti_dir(string dir)
        {
            string dir1 = dir;
            if (dir == "east") return "west";
            if (dir == "west") return "east";
            if (dir == "south") return "north";
            if (dir == "north") return "south";
            if (dir == "up") return "down";
            if (dir == "down") return "up";
            if (dir == "northeast") return "southwest";
            if (dir == "northwest") return "southeast";
            if (dir == "southeast") return "northwest";
            if (dir == "southwest") return "northeast";

            return dir1;
        }
    }
}
