using Game.Facility.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

    public class swind5 : RoomState
    {

        public override void create()
        {



            set("short", "南门北");
            set("long", @"
        到处都散发着安祥宁静的气氛。街道西边的普生堂远近驰名，听说当年皇上游
        览风云城时被刺，身受重伤，幸亏是普生的灵丹妙药才令皇上起死回生。堂中的金
        匾就是御赐的。普生堂的对面是南宫钱庄。
"

            );
            set("exits", new Dictionary<string, string>(){
      { "south", __DIR__+"sgate" },
                    { "north", __DIR__+"swind4" },
     { "east", __DIR__+"nanbank" },
     { "west", __DIR__+"pusheng" }});

            set("outdoors", "fengyun");
            //      set("objects", Tuple.Create<string,int>(__DIR__ + "npc.zhu",2));

            //                ]));
            set("coor/x", 0);
            set("coor/y", -50);
            set("coor/z", 0);
           
        }
    }

