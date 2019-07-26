using System.Collections.Generic;
using Game.Facility.Interface;
using System;
    public class nwind1 : RoomState
    {

        public override void create()
        {



            set("short", "广场北");
            set("long", @"
    风街是风云城里最热闹的两条街道之一，连着广场的一头更是人来人往，络绎
    不绝。街道两旁店铺众多，生意兴隆。叫卖声、喝采声、女人们的娇笑声，此起彼
    伏。糕点的甜味儿，酒菜的香味儿，女人身上的花粉味儿，令人目眩头晕。大街东
    侧是城里最贵的酒楼—风云阁，西侧则是警世书局。
"
            );
            set("exits", new Dictionary<string, string>(){
      { "south", __DIR__+"fysquare" },
                    { "north", __DIR__+"nwind2" },
     { "east", __DIR__+"fyge" },
     { "west", __DIR__+"jssju" }});

            set("outdoors", "fengyun");
            set("objects", Tuple.Create<string,int>(__DIR__ + "npc/zhu",2));

            //                ]));
            set("coor/x", 0);
            set("coor/y", 10);
            set("coor/z", 0);
           
        }
    }
