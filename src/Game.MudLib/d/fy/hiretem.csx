using Game.Facility.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


    public class hiretem : RoomState
    {

        public override void create()
        {

            set("short", "城隍古庙");
            set("long", @"
        这庙少说也有几百年的历史了。阴暗潮湿，破旧不堪，每当狂风吹过，整座庙
        都在摇晃，似乎马上就会倒塌下来。这里香火很是惨淡，只有一支残烛在风中摇曳，
        忽明忽暗，鬼气森森。整个庙里灰尘满布，角落里的一个暗红色的神龛却是一尘不
        染。
"

                );
            set("exits", new Dictionary<string, string>(){
                 
                         
                             { "west", __DIR__+"nwind5" },

            });

            set("outdoors", "fengyun");
            //      set("objects", Tuple.Create<string,int>(__DIR__ + "npc.caifan",1));

            //                ]));
            set("coor/x", -10);
            set("coor/y", 20);
            set("coor/z", 0);
           
        }
    }

