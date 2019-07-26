using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Core.Interface.Model
{
    public class CharacterState : Dictionary<string, object>
    {
        public string id { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public int Gin { get; set; }
        public int EffectGin { get; set; }

        public int MaxGin { get; set; } = 100;

        public int Kee { get; set; }
        public int EffectKee { get; set; }
        public int MaxKee { get; set; } = 100;

        public int Sen { get; set; }
        public int EffectSen { get; set; } = 100;
        public int MaxSen { get; set; } = 100;

        public int Food { get; set; }

        public int FoodCapacity { get; set; } = 100;

        public int Water { get; set; }
        public int WaterCapacity { get; set; } = 100;

        public long Score { get; set; }

        public int Atman { get; set; }
        public int MaxAtman { get; set; } = 100;
        public object AtmanFactor { get; set; }
        public object Bellicosity { get; set; }
        public int Force { get; set; }
        public int MaxForce { get; set; } = 100;
        public object ForceFactor { get; set; }
        public int Potential { get; set; }
        public int LearnedPoints { get; set; }
        public int Mana { get; set; }
        public int MaxMana { get; set; } = 100;
        public int ManaFactor { get; set; }
        public int CombatExp { get; set; } = 0;
        /// <summary>
        /// 速度
        /// </summary>
        public int Speed { get; set; }
        /// <summary>
        /// 伤害
        /// </summary>
        public int Damage { get; set; }
        /// <summary>
        /// 闪避
        /// </summary>
        public int Dodge { get; set; }
        /// <summary>
        /// 防御
        /// </summary>
        public int Defence { get; set; }

        protected void set(string prop, object value)
        {
            switch (prop.ToLower())
            {
                case "title":
                    this.Title = value.ToString();
                    break;
                case "name":
                    this.Name = value.ToString();
                    break;
                case "damage":
                    this.Damage = (int)value;
                    break;
                case "speed":
                    this.Speed = (int)value;
                    break;
                case "defence":
                    this.Defence = (int)value;
                    break;
                case "dodge":
                    this.Dodge = (int)value;
                    break;
                default:
                    if (this.ContainsKey(prop))
                        this[prop] = value;
                    else
                        this.Add(prop, value);
                    break;
            }
        }

        public virtual void create() { }

        static Random ran = new Random(DateTime.Now.Millisecond);
        protected int random(int value)
        {
            return ran.Next(0, value);
        }

        public new object this[string index]
        {
            get
            {
                if (base.ContainsKey(index))
                    return base[index];
                else
                    return null;
            }
            set
            {
                base[index] = value;
            }
        }
    }
}
