﻿
using System.Collections.Generic;
using Game.Facility.Interface;



    public class fysquare : RoomState
    {

        public override void create()
        {
			

            set("short", "风云天下");
            set("long", @"
    风风雨雨，风云城的中心广场依旧鲜亮如新。风街和云路在这里交会，宽阔的
    街道围成一个巨大的广场。广场中央的水池已经干涸，当年碧绿的池水和尾尾金鱼
    不复存在，留下的是个几丈方圆，深不见底的大洞。水池旁的蟠龙摩天石柱饱经岁
    月沧桑，依然不屈不挠地耸立，石柱上九条飞龙张牙舞爪，直欲冲天而去。");
            set("exits", new Dictionary<string, string>(){ /* sizeof() == 4 */
                 { "north" , __DIR__+"nwind1" },
                 { "south" , __DIR__+"swind1" },
             { "east" , __DIR__+"ecloud1" },
             { "west" , __DIR__+"wcloud1" } });

            set("outdoors", "fengyun");
            //set("objects", ([
            //        __DIR__"npc/center_soldier" : 1,
            //        __DIR__"npc/half_god" : 1,
            //        __DIR__"obj/gui1" : 1,
            //        "/d/cave/obj/slayedman" : 1,
          // ]));
            set("coor/x", 0);
            set("coor/y", 0);
            set("coor/z", 0);
            set("no_dazuo", 1);
            set("no_study", 1);

          
        }
    }



