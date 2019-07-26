﻿using Game.Facility.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

    public class nwind4 : RoomState
    {

        public override void create()
        {

            set("short", "北风街北");
            set("long", @"
    北城区是武林人物会聚的地方。西首的镇风兵器店自诸葛雷创业以来，打造的
    兵器在江湖上小有名气，东首的金狮镖局从来没有丢过一支镖，声誉传遍大江南北。
    在这里进进出出的大部分都是腰带兵刃，虎背熊腰的江湖人物。
"
            );
            set("exits", new Dictionary<string, string>(){
                { "south" , __DIR__+"nwind3" },
      { "north" , __DIR__+"nwind5" },
      { "east" , __DIR__+"goldlion" },
      { "west" , __DIR__+"stopwin" },
      }

            );
            set("outdoors", "fengyun");
            //set("objects", ([
            //__DIR__"npc/dtz": 2,
    
            //                ]));
            set("coor/x", 0);
            set("coor/y", 40);
            set("coor/z", 0);

           
        }
    }

