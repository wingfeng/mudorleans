using Game.Facility.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

    public class wcloud1 : RoomState
    {

        public override void create()
        {



            set("short", "广场西");
            set("long", @"
        风云广场在东，长乐坊在西，这里是风云城中风骚文人丛聚之地。据说天下赫
        赫有名的小李探花就是在这里中的秀才。南边的考场每年都举行一次选拔考试，前
        三名送入京都再试。北面则是探花诗台，是风骚文人们留下他们得意之作的地方。
"

            );
            set("exits", new Dictionary<string, string>(){
                             { "north", __DIR__+"poemp" },
                             { "south", __DIR__+"examp" },
                             { "east", __DIR__+"fysquare" },
                             { "west", __DIR__+"wcloud2" }});

            set("outdoors", "fengyun");
            //      set("objects", Tuple.Create<string,int>(__DIR__ + "npc.song",1));

            //                ]));
            //            set("objects", ([
            //__DIR__"npc/song": 1,
            //__DIR__"npc/xiwei": 4,

            //                ]));
            set("coor/x", -10);
            set("coor/y", 0);
            set("coor/z", 0);
           
        }
    }

