using CommandLine;
using Game.Core.Interface;
using Game.Facility.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Grains.Cmd
{
    //"go","up","down","en","s","sw","se","e","ne","n","nw","w"
    [Verb("score", HelpText = @"指令格式 : hp。指令格式 : hp
 
这个指令可以显示你(玩家)的一些基本状态： 
 精力  ：  545/  545 (100%)    食物：  74%
 气血  ：  838/  838 (100%)    饮水：  74%
 心神  ：  544/  544 (100%)    评价： 104
 灵力  ：  220/  220 (   0)    杀气： 156
 内力  ：  543/  543 (  34)    潜能： 751
 法力  ：  350/  219 (   0)    经验： 97775 \r\n")]
    public class ScoreCommand : CommandBase
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
            var my = state;

            printf($"{ AnsiConst.BOLD}{state.Short}{AnsiConst.NOR} \n\n");
             printf("\n {0}\n\n",state.Short);
             printf(" 你是一{0}{1}{2}岁的{3}{4}，{5}生。\n",
                    state["unit"],
                    state["national"],
                    state["age"],
                    state["gender"],
                    state["race"],
                    state["birthday"]);
             //printf(" 你总共杀了{0}个人，{1}个玩家，被杀了{2}次。\n",
             //      ((int)my["MKS"] +(int) my["PKS"]), my["PKS"], my["KILLED"]);

             printf(" 你到目前为止总共完成了{0}个使命，{1}个组织任务。\n",
                    my["TASK"], my["QUESTNPC"]);
             printf(" 你总共战胜过{0}个风云天骄。\n",
                    state["m_killer"]);
             printf(" 你现在共有存款：{0}文钱。\n",
                    state["deposit"]);

            //if (mapp(my["organization"]))
            //{
            //    if (my["organization"]["privs"] == 0)
            //    {
            //         printf(" 你的组织是%s，首领是%s，", my["organization"]["org_name"], my["organization"]["leader_name"]);
            //        if (!my["organization"]["org_title"] || my["organization"]["org_title"] == "成员")
            //        {
            //             "你不担任任何职位。\n";
            //        }
            //        else
            //             printf("位居%s。\n", my["organization"]["org_title"]);
            //    }
            //    else
            //    {
            //         printf(" 你的组织是%s，你是该组织的%s首领", my["organization"]["org_name"], my["organization"]["privs"] == -1 ? "" : "前任");
            //        if (my["organization"]["org_title"])
            //        {
            //             printf("，号称%s。\n", my["organization"]["org_title"]);
            //        }
            //        else
            //             "。\n";
            //    }

            //}
            //else
            //     " 你目前没有加入任何组织。\n";
            //if (mapp(my["family"]))
            //{
            //    if (my["family"]["master_name"])
            //         printf("%s 你的师父是%s。\n",
            //                line, my["family"]["master_name"]);
            //}
            //if (my["marry"] || my["divorced"])
            //{
            //    if (my["marry"])
            //    {
            //         " 你的" + (state["gender") == "女性" ? "丈夫" : "妻子") + "是"
            //                     + my["marry_name"] + "(" + my["marry"] + ")。\n";

            //    }
            //    else
            //         " 你目前正在" + (state["gender") == "女性" ? "寡居" : "鳏居")
            //                + "。已有过" + chinese_number(my["divorced"]) + "次不幸婚姻。\n";
            //}
            //else
              printf(   " 你目前尚未婚配。\n");

            // printf(
            //        "\n 才智：%s\t\t体质：%s\n"+

            //        " 灵性：%s\t\t魅力：%s\n"+

            //        " 勇气：%s\t\t力量：%s\n"+

            //        " 耐力：%s\t\t韧性：%s\n"+

            //        " 速度：%s\t\t气量：%s\n"+

            //        " 运气：%s\t\t定力：%s\n",
            //        display_attr(my["int"], ob->query_int()),
            //        display_attr(my["con"], ob->query_con()),
            //        display_attr(my["spi"], ob->query_spi()),
            //        display_attr(my["per"], ob->query_per()),
            //        display_attr(my["cor"], ob->query_cor()),
            //        display_attr(my["str"], ob->query_str()),
            //        display_attr(my["dur"], ob->query_dur()),
            //        display_attr(my["fle"], ob->query_fle()),
            //        display_attr(my["agi"], ob->query_agi()),
            //        display_attr(my["tol"], ob->query_tol()),
            //        display_attr(my["kar"], ob->query_kar()),
            //        display_attr(my["cps"], ob->query_cps()));
            // printf("\n 自造物品： " HIR "%d\t\t" NOR, state["created_item"));
            // printf("自造房间： " HIR "%d\n" NOR, state["created_room"));
            //attack_points = COMBAT_D->skill_power(ob, SKILL_USAGE_ATTACK);
            //parry_points = COMBAT_D->skill_power(ob, SKILL_USAGE_PARRY);
            //dodge_points = COMBAT_D->skill_power(ob, SKILL_USAGE_DODGE);
            // printf(HIR"\n 攻击力： %d" HIG "\t\t防御力： %d\n" NOR,
            //        attack_points + 1,
            //        (dodge_points / 2 + (weapon ? parry_points : (parry_points / 2))) + 1);
            // printf(HIR" 杀伤力： %d" HIG "\t\t保护力： %d\n\n" NOR,
            //        ob->query_temp("apply/damage"), ob->query_temp("apply/armor"));
            // printf(HIM" 参 数 点： %d\n\n" NOR, state["gift_points") -
            //                                                    state["used_gift_points"));
            //write(line);

            await  Player.Notify(sb.ToString());
            return 0;
        }
        string display_attr(int gift, int value)
        {
            if (value > gift) return string.Format(AnsiConst.HIY+"{0} /{1}" +AnsiConst.NOR, value, gift);
            else if (value < gift) return string.Format(AnsiConst.HIR+ "{0} /{1}"+ AnsiConst.NOR, value, gift);
            else return string.Format("{0} /{1}", value, gift);
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
