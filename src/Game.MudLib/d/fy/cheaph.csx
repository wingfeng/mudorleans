﻿using Game.Facility.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


    public class cheaph : RoomState
    {

        public override void create()
        {



            set("short", "土嫖馆");
            set("long", @"
        一间简陋的，用泥坯砌起来的低矮小房。东面的墙上有条裂缝，从右上角一直
        裂到左边的墙角里。西边有一张和泥屋连为一体的土炕。炕下有灶，炕头挂着厚布
        蚊帐，帐上贴纸一张：价格最平，男女老少皆宜，恕不找钱。
"

                );
            set("exits", new Dictionary<string, string>(){
                 
                             { "north", __DIR__+"wcloud3" },

            });

            set("outdoors", "fengyun");
            //      set("objects", Tuple.Create<string,int>(__DIR__ + "npc.caifan",1));

            //                ]));
            set("no_preach", 1);
            set("coor/x", -30);
            set("coor/y", -9);
            set("coor/z", 0);
           
        }
    }
