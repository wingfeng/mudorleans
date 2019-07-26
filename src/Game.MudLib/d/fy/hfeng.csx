using Game.Facility.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


    public class hfeng : RoomState
    {

        public override void create()
        {

            set("short", "浣凰堂");
            set("long", @"
        浣凰堂的门面比以前大多了，四面墙上风干的花环散发着醉人的香气。大堂的
        中央还是当年那个古色古香的青铜仙鹤，鹤嘴里面飘出袅袅青烟，沁人心脾。大堂
        的右边是一个小小的柜台，台子的后面有一个木架，架子上挂满了白毛巾。
"

                );
            set("exits", new Dictionary<string, string>(){
                 
                         
                             { "west", __DIR__+"nwind3" },

            });

            set("outdoors", "fengyun");
            //      set("objects", Tuple.Create<string,int>(__DIR__ + "npc.caifan",1));

            //                ]));
            set("coor/x", -10);
            set("coor/y", 20);
            set("coor/z", 0);
           
        }
    }

