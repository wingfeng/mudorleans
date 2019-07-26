using Game.Core.Interface;
using Game.Core.Interface.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Text;


    public class patrol_soldier: CharacterState
    {

        public override void create()
        {
            set("name", "巡逻士兵");
            set("id", "police");
     //       set_name("巡逻士兵", ({ "police" }) );
            set("long",
    "这是个正在执行巡逻任务的士兵，负责维护风云城里的治安,打架行凶,\n"+
    "千万不要给他们看到。无论你以前是干什么的，他们都一视同仁。\n");
            set("attitude", "heroism");
            //      set("vendetta_mark", "authority");
            set("str", 40 + random(40));
            set("cor", 40);
            set("cps", 25);
            set("class", "wudang");
            set("combat_exp", 1000000 + random(2000000));
            set("chat_chance_combat", 45);
        //    set("chat_msg_combat", ({
        //        "巡逻士兵喝道：还不快放下武器束手就缚？\n",
        //        (: perform_action, "sword.chanzijue" :),
        //        (: summon_more(this_object()) :),
        //}) );
            //set_skill("unarmed", 70 + random(100));
            //set_skill("sword", 100 + random(50));
            //set_skill("parry", 70 + random(100));
            //set_skill("dodge", 70 + random(100));
            //set_skill("move", 150 + random(100));
            //set_skill("changquan", 200);
            //set_skill("spring-sword", 200);
            //map_skill("sword", "spring-sword");
            //map_skill("unarmed", "changquan");
            //set_temp("apply/attack", 70);
            //set_temp("apply/dodge", 70);
            //set_temp("apply/parry", 70);
            //set_temp("apply/armor", 70);
            //set_temp("apply/damage", 30 + random(200));
            //set_temp("apply/move", 100);
            set("chat_chance", 20);
            //    set("chat_msg", ({
            //        (: random_move :),
            //}) );
            //    setup();
            //    carry_object(__DIR__"obj/kiujia")->wear();
            //    carry_object(__DIR__"obj/sword")->wield();
          
        }
    }

