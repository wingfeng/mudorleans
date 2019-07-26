using Game.Facility.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


    public class ecloud1 : RoomState
    {

        public override void create()
        {



            set("short", "广场东");
            set("long", @"
        这里是风云城中三教九流，龙蛇混集之所。不管你是达官贵人，还是贩夫走卒，
        只要你身上有两钱儿，在这里就会受到热情的招呼。任何你不知道的事，在这里打
        听一下，都可以知道个八九不离十。整条街上有卖菜的，卖肉的，卖玩具的，卖艺
        的，卖药的...，应有尽有。
"

            );
            set("exits", new Dictionary<string, string>(){
                             { "north", __DIR__+"stone1" },
                             { "south", __DIR__+"marry_room" },
                             { "east", __DIR__+"ecloud2" },
                             { "west", __DIR__+"fysquare" }});

            set("outdoors", "fengyun");
            //      set("objects", Tuple.Create<string,int>(__DIR__ + "npc.caifan",1));

            //                ]));
            set("coor/x", 10);
            set("coor/y", 0);
            set("coor/z", 0);
           
        }
    }

