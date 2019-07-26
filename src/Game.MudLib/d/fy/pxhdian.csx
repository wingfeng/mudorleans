using Game.Facility.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


    public class pxhdian : RoomState
    {

        public override void create()
        {

            set("short", "飘香花店");
            set("long", @"
        经过了这么多年，这里似乎一点都没有改变，人来人往不断。未入此处，清新
        的花香已沁人心脾。店中各种名花，玲琅满目，不乏珍奇异种。来客不分高低贵贱，
        这里的主人总是笑脸相迎。许多城中的年青人都喜欢在这儿逗留，盼有一天桃花运
        会降临在身上。据这里的老板说，在飘香花店结成的良缘已不可胜数。店门口红纸
        贴了张告示（ｓｉｇｎ）。
"

                );
            set("exits", new Dictionary<string, string>(){
                 
                         
                             { "west", __DIR__+"nwind2" },

            });

            set("outdoors", "fengyun");
            //      set("objects", Tuple.Create<string,int>(__DIR__ + "npc.caifan",1));

            //                ]));
            set("no_fight", 1);
            set("no_magic", 1);
            set("NONPC", 1);
            set("coor/x", 1);
            set("coor/y", 20);
            set("coor/z", 0);
           
        }
    }

