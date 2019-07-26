using CommandLine;
using Game.Core.Interface;
using Game.Facility.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Grains.Cmd
{
    //"go","up","down","en","s","sw","se","e","ne","n","nw","w"
    [Verb("hp", HelpText = @"指令格式 : hp。指令格式 : hp
 
这个指令可以显示你(玩家)的一些基本状态： 
 精力  ：  545/  545 (100%)    食物：  74%
 气血  ：  838/  838 (100%)    饮水：  74%
 心神  ：  544/  544 (100%)    评价： 104
 灵力  ：  220/  220 (   0)    杀气： 156
 内力  ：  543/  543 (  34)    潜能： 751
 法力  ：  350/  219 (   0)    经验： 97775 \r\n")]
    public class HpCommand : CommandBase
    {
        StringBuilder sb = new StringBuilder();
        [Value(0)]
        public string Who { get; set; }
        //public override List<string> CreateArgs()
        //{
        //    return new List<string>();
        //}
        void printf(string value, params object[] val)
        {
            sb.AppendLine(string.Format(value, val));

        }
        protected override async Task<int> OnExecute()
        {

            var state = await Player.Get();

            printf(" 精力  ： {0}{1,4:d}/ {2,4:d}{3}({4,3:d}%)" + AnsiConst.NOR + "    食物：{5}{6,3:d}%\n" + AnsiConst.NOR,
        status_color(state.Gin, state.EffectGin), state.Gin, state.EffectGin,
        status_color(state.EffectGin, state.MaxGin), state.EffectGin * 100 / state.MaxGin,
        status_color(state.Food, state.FoodCapacity),
        state.Food * 100 / state.FoodCapacity
     );
            printf(" 气血  ： {0}{1,4:d}/ {2,4:d}{3}({4,3:d}%)" + AnsiConst.NOR + "    饮水： {5}{6,3:d}%\n" + AnsiConst.NOR,
                   status_color(state.Kee, state.EffectKee), state.Kee, state.EffectKee,
                   status_color(state.EffectKee, state.MaxKee), state.EffectKee * 100 / state.MaxKee,
                   status_color(state.Water, state.WaterCapacity),
                   state.Water * 100 / state.WaterCapacity
                );
            printf(" 心神  ： {0}{1,4:d}/ {2,4:d}{3}({4,3:d}%)" + AnsiConst.HIW + "    评价： {5,4:d}\n" + AnsiConst.NOR,
                   status_color(state.Sen, state.EffectSen), state.Sen, state.EffectSen,
                   status_color(state.EffectSen, state.MaxSen), state.EffectSen * 100 / state.MaxSen,
                   state.Score
                );
            printf(" 灵力  ：{0}{1,4:d}/ {2,4:d}({3,4:d}%)" + AnsiConst.HIR + "    杀气： {4,4:d}\n" + AnsiConst.NOR,
                   status_color(state.Atman, state.MaxAtman), state.Atman, state.MaxAtman,
                   state.AtmanFactor,
                   state.Bellicosity
                );
            printf(" 内力  ： {0}{1,4:d}/ {2,4:d}({3,4:d}%)" + AnsiConst.HIG + "    潜能：{4,4:d}\n" + AnsiConst.NOR,
                   status_color(state.Force, state.MaxForce), state.Force, state.MaxForce,
                   state.ForceFactor,
                   state.Potential - state.LearnedPoints
                );
            printf(" 法力  ： {0}{1,4:d}/ {2,4:d}({3,4:d}%)" + AnsiConst.HIM + "    经验： {4,4:d}\n" + AnsiConst.NOR,
                   status_color(state.Mana, state.MaxMana), state.Mana, state.MaxMana,
                   state.ManaFactor,
                   state.CombatExp
                );

          await  Player.Notify(sb.ToString());
            return 0;
        }

        string status_color(int current, int max)
        {
            int percent;

            if (max > 0) percent = current * 100 / max;
            else percent = 100;
            if (percent > 100) return AnsiConst.HIC;
            if (percent >= 90) return AnsiConst.HIG;
            if (percent >= 60) return AnsiConst.HIY;
            if (percent >= 30) return AnsiConst.YEL;
            if (percent >= 10) return AnsiConst.HIR;
            return AnsiConst.RED;
        }
    }
}
