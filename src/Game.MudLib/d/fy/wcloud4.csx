﻿using Game.Facility.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


    public class wcloud4 : RoomState
    {

        public override void create()
        {



            set("short", "西云路西");
            set("long", @"
        宽宽的黄土路向东西方向伸展，路边的茅屋矮小而破旧，街边的垃圾散发着令
        人作呕的腐臭，路上的行人面黄肌瘦，被贫困的生活拖得疲惫不堪。偶而有一两个
        面色红润之人，都掩鼻匆匆而过，生怕沾上一点晦气。大路南侧的安生棺材店中迎
        门放着几口薄皮木棺，大路北面的阿发木器店中黑漆漆一片，看不到里面有什么。
"

            );
            set("exits", new Dictionary<string, string>(){
                             { "north", __DIR__+"afa" },
                             { "south", __DIR__+"ansheng" },
                             { "east", __DIR__+"wcloud3" },
                             { "west", __DIR__+"wcloud5" }});

            set("outdoors", "fengyun");
            set("coor/x", -40);
            set("coor/y", 0);
            set("coor/z", 0);
           
        }
    }

