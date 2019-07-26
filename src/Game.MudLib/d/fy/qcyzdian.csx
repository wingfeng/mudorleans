using Game.Facility.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


    public class qcyzdian : RoomState
    {

        public override void create()
        {

            set("short", "倾城胭脂店");
            set("long", @"
    这里陈列着各式各样的胭脂，有从京都运来的，也有本地产的。胭脂鲜红似血,
    香气扑鼻。每当朝阳初升，阳光照入店内，映在胭脂上，给人一种耀眼的亮红。除
    了胭脂这里还卖刨花油，花粉袋。店老板听说就是五十年来江湖中有名的易容高手。   
"

                );
            set("exits", new Dictionary<string, string>(){
                 
                         
                             { "east", __DIR__+"nwind2" },

            });

            set("outdoors", "fengyun");
            //      set("objects", Tuple.Create<string,int>(__DIR__ + "npc.caifan",1));

            //                ]));
            set("coor/x", -10);
            set("coor/y", 20);
            set("coor/z", 0);
           
        }
    }

