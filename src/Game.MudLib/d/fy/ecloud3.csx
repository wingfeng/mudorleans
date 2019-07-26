using Game.Facility.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


    public class ecloud3 : RoomState
    {

        public override void create()
        {



            set("short", "东云大路");
            set("long", @"
        这儿全不似广场的热闹，偶尔有几家店铺也少有人光顾，如果脚下不是东云大
        路，简直不敢相信城中居然有这样的地方。北边的张家铁铺成天发出叮叮铛铛打铁
        的声音，昼夜不停。而南面则是一家私塾学堂。但似乎并没有什么学生。
"

            );
            set("exits", new Dictionary<string, string>(){
                             { "north", __DIR__+"smithy" },
                             { "south", __DIR__+"washroom" },
                             { "east", __DIR__+"ecloud4" },
                             { "west", __DIR__+"ecloud2" }});

            set("outdoors", "fengyun");
            //      set("objects", Tuple.Create<string,int>(__DIR__ + "npc.caifan",1));

            //                ]));
            set("coor/x", 10);
            set("coor/y", 0);
            set("coor/z", 0);
           
        }
    }

