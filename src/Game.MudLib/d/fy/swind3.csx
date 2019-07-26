using Game.Facility.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


    public class swind3 : RoomState
    {

        public override void create()
        {



            set("short", "南风大街");
            set("long", @"
        一个闪亮的银钩挂在大街西面一座巨宅的飞檐下，将日光折射开来，洒向整条
        街，就象在汉白玉的路面上铺上了一层银粉，闪闪发光，这就是风云城中最豪华的
        银钩赌坊。银钩赌坊的对面是一品居茶座。
"

            );
            set("exits", new Dictionary<string, string>(){
      { "south", __DIR__+"swind4" },
                    { "north", __DIR__+"swind2" },
     { "east", __DIR__+"yitea" },
     { "west", __DIR__+"yingou" }});

            set("outdoors", "fengyun");
            //      set("objects", Tuple.Create<string,int>(__DIR__ + "npc.zhu",2));

            //                ]));
            set("coor/x", 0);
            set("coor/y", -30);
            set("coor/z", 0);
           
        }
    }

