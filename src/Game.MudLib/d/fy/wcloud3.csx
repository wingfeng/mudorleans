﻿using Game.Facility.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


    public class wcloud3 : RoomState
    {

        public override void create()
        {



            set("short", "西云大路");
            set("long", @"
        宽宽的黄土路向东西方向伸展，路边的茅屋矮小而破旧，街边的垃圾散发着令
        人作呕的腐臭，路上的行人面黄肌瘦，被贫困的生活拖得疲惫不堪。偶而有一两个
        面色红润之人，都掩鼻匆匆而过，生怕沾上一点晦气。南首有一扇木门，上面写道：
        每夜五十文，北首则是相面大师乙成仙的招牌：生死已卜。
"

            );
            set("exits", new Dictionary<string, string>(){
                             { "north", __DIR__+"futhur" },
                             { "south", __DIR__+"cheaph" },
                             { "east", __DIR__+"wcloud2" },
                             { "west", __DIR__+"wcloud4" }});

            set("outdoors", "fengyun");
            set("coor/x", -30);
            set("coor/y", 0);
            set("coor/z", 0);
           
        }
    }

