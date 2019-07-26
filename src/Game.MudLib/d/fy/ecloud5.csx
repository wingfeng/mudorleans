using Game.Facility.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


    public class ecloud5 : RoomState
    {

        public override void create()
        {



            set("short", "东门西");
            set("long", @"
        再往东就是东城门了，东门外是通向山里的一条路。东门和其他的城门没有什
        么不同，上面贴满了告示和通缉令。听说当年大盗祈潼就是在东门被人发现，报告
        了官府后被抓住的。
"

            );
            set("exits", new Dictionary<string, string>(){
                             { "north", __DIR__+"hall" },
                         //    { "south", __DIR__+"ponder" },
                             { "east", __DIR__+"egate" },
                             { "west", __DIR__+"ecloud4" }});

            set("outdoors", "fengyun");
            //      set("objects", Tuple.Create<string,int>(__DIR__ + "npc.drugseller",1));

            //                ]));
            set("coor/x", 40);
            set("coor/y", 0);
            set("coor/z", 0);
           
        }
    }

