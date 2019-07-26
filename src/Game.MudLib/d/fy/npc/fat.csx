using Game.Core.Interface;
using Game.Core.Interface.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Text;


    public class fat: HumanState
    {

        public override void create()
        {
            set("name", "小胖子");
            set("id", "fatman");
       //     set_name("小胖子", ({ "little fatman","fatman" }) );
            set("gender", "男性");
            set("title", $"{AnsiConst.HIG}花街大少{AnsiConst.NOR}");
            set("age", 26);
            set("long",
                    "这个家伙长得还算是眉清目秀，但是看上去总给人一种坏坏的感觉。．．\n");
            set("combat_exp", 500);
            set("attitude", "friendly");
            set("int", 50);
            set("spi", 50);
            set("cor", 50);
            set("con", 50);
            set("per", 50);
            set("str", 10);
            set("max_force", 500);
            set("force", 1000);
            set("force_factor", 10);
            set("max_gin", 1000);
            set("max_kee", 1000);
            set("max_sen", 1000);
            set("chat_chance", 1);
            //    set("chat_msg", ({
            //        "小胖子不屑道：奶奶个熊～～老子当年行走江湖，花街大少的名头那个不知，\n谁人不晓～～\n",
            //        "小胖子神秘的道：哥们，知道老子是谁吗？说出来吓死你，老子就是人间活宝，\n人见人爱的胖胖～的～豆～～腐～～天～～使～～！～～\n",
            //        "小胖子突然从身后拿出一个鸟笼，对着鸟笼里的小鸟道：亲爱的小弟弟，就你\n给我的快乐最多！\n",
            //        "小胖子叹了口气，悲伤的说道：最近窑子逛多了，手头周转不灵，看来得把鸟\n笼卖了才成。！\n",
            //}) );
            //    set("chat_msg_combat", ({
            //        "小胖子高叫道：奶奶个熊～～～跟老子打架，看老子教训教训你～～\n",
            //        (: command, "surrender" :),
            //}) );
            //set_skill("move", 100);
            //set_skill("parry", 200);
            //set_skill("dodge", 200);
            //set_skill("force", 200);
            //set_skill("unarmed", 20);
            //set_skill("wuzheng-force", 220);
            //set_skill("literate", 200);
            //set_skill("meng-steps", 220);
            //map_skill("force", "wuzheng-force");
            //map_skill("dodge", "meng-steps");
            //map_skill("move", "meng-steps");
            //setup();
            //carry_object("/d/fugui/npc/obj/m_cloth2")->wear();
         
        }
    }

