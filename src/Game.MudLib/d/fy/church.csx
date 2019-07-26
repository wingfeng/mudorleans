using Game.Facility.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

    public class church : RoomState
    {

        public override void create()
        {


            set("short", "天主教堂");
            set("long", @"
        这里的建筑别具一格，房顶特别高，成拱形，上面还有个巨大的十字架。房顶
        上又有满幅的浮雕。雕的是一些金发碧眼，背生翅膀的小天使。教堂正中的十字架
        上钉着一个全身是血，长发披面的塑像。
"

                );
            set("exits", new Dictionary<string, string>(){
                 
                             { "west", __DIR__+"swind2" },
                             { "north", __DIR__+"chjian" },

            });

            set("outdoors", "fengyun");
            //      set("objects", Tuple.Create<string,int>(__DIR__ + "npc.caifan",1));

            //                ]));
            set("coor/x", -40);
            set("coor/y", 10);
            set("coor/z", 0);
           
        }
    }

