using Game.Core.Interface;
using Game.Core.Interface.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Text;


    public class zhu: CharacterState
    {

        public override void create()
        {
            set("name","青竹先生(zhu)" );
            set("id", "zhu");
            set("gender", "男性");
            set("age", 65);
            set("title", $"{AnsiConst.HIG}岁寒三友{AnsiConst.NOR}");
            set("str", 6);
            set("cor", 24);
            set("cps", 11);
            set("per", 27);
            set("int", 27);
            set("reward_npc", 1);
            set("difficulty", 2);
            set("intellgent", 1);
            set("attitude", "peaceful");
            set("chat_chance", 1);
            //just for test
            set("damage", 10000);
            set("speed", 500);
            set("defence", 8000);
            set("dodge", 5000);

        //    set("chat_msg", ({
        //        (: random_move :),
        //}) );
            set("fly_target", 1);
            set("max_atman", 300);
            set("atman", 300);
            set("max_force", 500);
            set("force", 500);
            set("max_mana", 300);
            set("mana", 300);
            set("long", "西方神教的三大护法之一\n");
            set("combat_exp", 999999);
            //    set_skill("unarmed", 120);
            //    set_skill("throwing", 100);
            //    set_skill("dodge", 100);
            //    set_skill("force", 130);
            //    set_skill("literate", 70);
            //    set_skill("demon-force", 100);
            //    set_skill("demon-strike", 80);
            //    set_skill("demon-steps", 10);
            //    map_skill("unarmed", "demon-strike");
            //    map_skill("dodge", "demon-steps");
            //    map_skill("force", "demon-force");
            //    set("chat_chance_combat", 50);
            //    set("chat_msg_combat", ({
            //        (: perform_action, "unarmed.dimo" :),
            //        (: perform_action, "unarmed.renmo" :),
            //        (: perform_action, "unarmed.tianmo" :),
            //        (: exert_function, "mihun" :),
            //}) );

            //    setup();
            //carry_object(__DIR__"obj/stone")->wield();
            //carry_object("/obj/armor/cloth")->wear();
           
        }
    }

