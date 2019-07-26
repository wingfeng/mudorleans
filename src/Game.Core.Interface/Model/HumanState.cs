using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Core.Interface.Model
{
    public class HumanState : CharacterState
    {
        public override void create()
        {
            set(id, Guid.NewGuid());
            set("unit", "位");
            set("gender", "男性");
            set("can_speak", 1);
            set("attitude", "peaceful");
            set("limbs", (new string[]{
                "头部", "颈部", "胸口", "後心", "左肩", "右肩", "左臂",
                "右臂", "左手", "右手", "腰间", "小腹", "左腿", "右腿",
                "左脚", "右脚", "左肋", "右肋", "前胸", "后背", "眉心",
                "后腰", "后颈", "左胯", "右胯", "后脑", "左眼", "右眼",
                "左颊", "右颊"
            }));
            setup_human();
            base.create();
        }
        void setup_human()
        {

            int combat_exp, bonus;

            var my = this;

            combat_exp = this.CombatExp;
            if (combat_exp < 100000)
            {
                bonus = (int)(combat_exp * 0.005);
            }
            else if (combat_exp < 1000000)
            {
                bonus = (int)(combat_exp * 0.0009 + 700);
            }
            else if (combat_exp < 10000000)
            {
                bonus = (int)(combat_exp * 0.00025 + 1750);
            }
            else
            {
                bonus = 4500;
            }


            //     ob->set("default_actions", (: call_other, __FILE__, "query_action" :));

            if (!my.ContainsKey("national")) my["national"] = "汉族";

            if (!my.ContainsKey("age")) my["age"] = random(30) + 15;
            if (!my.ContainsKey("str")) my["str"] = random(25) + 5;
            if (!my.ContainsKey("cor")) my["cor"] = random(20) + 5;
            if (!my.ContainsKey("int")) my["int"] = random(5) + 20;
            if (!my.ContainsKey("spi")) my["spi"] = random(20) + 5;
            if (!my.ContainsKey("cps")) my["cps"] = random(20) + 5;
            if (!my.ContainsKey("per")) my["per"] = random(20) + 5;
            if (!my.ContainsKey("con")) my["con"] = random(20) + 5;
            if (!my.ContainsKey("kar")) my["kar"] = random(20) + 5;
            if (!my.ContainsKey("agi")) my["agi"] = random(20) + 5;
            if (!my.ContainsKey("dur")) my["dur"] = random(2) + 1;
            if (!my.ContainsKey("fle")) my["fle"] = random(20) + 5;
            if (!my.ContainsKey("tol")) my["tol"] = random(20) + 5;


            if ((int)my["age"] <= 14)
            {
                my.MaxGin = 100 + (int)my["spi"] * 10;
            }
            else if ((int)my["age"] <= 20)
            {
                my.MaxGin = 100 + ((int)my["age"] - 14) * 20 + (int)my["spi"] * 10;
            }
            else if ((int)my["age"] <= 30)
            {
                my["max_gin"] = 220 + (int)my["spi"] * 10;
            }
            else if ((int)my["age"] <= 60)
            {
                my.MaxGin = 220 - ((int)my["age"] - 30) * 5 + (int)my["spi"] * 10;
            }
            else
            {
                my.MaxGin = 70 + (int)my["spi"] * 10;
            }
            if ((int)my.MaxAtman > 0)
            {
                my.MaxGin = my.MaxGin + my.MaxAtman;
            }
            my.MaxGin = my.MaxGin + (int)my["dur"] * (int)my["dur"];
            //if (!userp(ob))
            //{
            //    my["max_gin"] += bonus / 2;
            //}



            if ((int)my["age"] <= 14)
            {
                my.MaxKee = 100 + (int)my["con"] * 10;
            }
            else if ((int)my["age"] <= 20)
            {
                my.MaxKee = 100 + ((int)my["age"] - 14) * 20 + (int)my["con"] * 10;
            }
            else
            {
                my.MaxKee = 220 + (int)my["con"] * 10;
            }
            if (my.MaxForce > 0)
            {
                my.MaxKee = my.MaxKee + my.MaxForce;
            }
            my.MaxKee = my.MaxKee + (int)my["dur"] * (int)my["dur"];
            //if (!userp(ob))
            //{
            //    my["max_kee"] += bonus;
            //}

          
                if ((int)my["age"] <= 30)
                {
                    my.MaxSen = 100 + (int)my["int"] * 10;
                }
                else
                {
                    my.MaxSen = 100 + ((int)my["age"] - 30) * 5 + (int)my["int"] * 10;
                }
                if (my.MaxMana > 0)
                {
                    my.MaxSen = (int)my.MaxSen + my.MaxMana;
                }
                my.MaxSen = (int)my.MaxSen + (int)my["dur"] * (int)my["dur"];
                //if (!userp(ob))
                //{
                //    (int)my.MaxSen += bonus / 2;
                //}
            

            //      ob->set_default_object(__FILE__);
            //      if (!ob->query_weight()) ob->set_weight(BASE_WEIGHT + (my["str"] - 10) * 200);
        }
    }
}
