using Game.Facility.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


    public class ansheng : RoomState
    {

        public override void create()
        {



            set("short", "阿发木器店");
            set("short", "安生棺材店");
            set("long", @"
    店门口的招牌是几个已被雨淋日晒得变了颜色的花圈。店口的地上放着几口打
    造好，但还没有上漆的薄皮棺材。 四面的墙上零乱的挂着几串纸钱和纸花。墙角
    放着一口上好的红木棺材，但棺盖似乎并没有盖好。
    "

                );
            set("exits", new Dictionary<string, string>(){
                             { "north", __DIR__+"wcloud4" },
                          //   { "south", __DIR__+"wcloud4" },
                        //     { "east", __DIR__+"ecloud2" },
                         //   { "west", __DIR__+"fysquare" }
            });

            set("outdoors", "fengyun");
            //      set("objects", Tuple.Create<string,int>(__DIR__ + "npc.caifan",1));

            //                ]));
            set("coor/x", -40);
            set("coor/y", -10);
            set("coor/z", 0);
           
        }
    }

