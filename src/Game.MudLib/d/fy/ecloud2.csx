using Game.Facility.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

    public class ecloud2 : RoomState
    {

        public override void create()
        {



            set("short", "东云路");
            set("long", @"
        风云城中最杂最乱的地方。虽然如此，这里还是人来人往。只要你想得出来的，
        这里就有，不管是吃的还是玩的。南面是一个破旧的小亭子，里面寄居这一个老道
        士。北面则是风云城里老字号的布铺。
"

            );
            set("exits", new Dictionary<string, string>(){
                             { "north", __DIR__+"bupu" },
                             { "south", __DIR__+"jijian" },
                             { "east", __DIR__+"ecloud3" },
                             { "west", __DIR__+"ecloud1" }});

            set("outdoors", "fengyun");
            //      set("objects", Tuple.Create<string,int>(__DIR__ + "npc.caifan",1));

            //                ]));
            set("coor/x", 10);
            set("coor/y", 0);
            set("coor/z", 0);
           
        }
    }

