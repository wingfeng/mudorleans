﻿using Game.Facility.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


    public class wcloud2 : RoomState
    {

        public override void create()
        {



            set("short", "西云路");
            set("long", @"
        也许是快到风云广场的缘故，这里的气氛渐渐喧闹起来。脚下已不是坎坷不平
        的黄土路，大块的黑石砌成的大路可容八马并行，路上的行人脚步轻快，神情开朗，
        大路的南侧新开张了家长乐坊，而大路的北首是风云驿站。
"

            );
            set("exits", new Dictionary<string, string>(){
                             { "north", __DIR__+"mailst" },
                             { "south", __DIR__+"manhome" },
                             { "east", __DIR__+"wcloud1" },
                             { "west", __DIR__+"wcloud3" }});

            set("outdoors", "fengyun");
            set("coor/x", -20);
            set("coor/y", 0);
            set("coor/z", 0);
           
        }
    }

