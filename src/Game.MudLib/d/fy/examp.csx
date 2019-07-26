using Game.Facility.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


    public class examp : RoomState
    {

        public override void create()
        {


            set("short", "考场");
            set("long", @"
        风云城人才辈出，凡是有志于宦途的风云年青人都要在这里通过第一次考试。
        文武双全的前三名会被送入京都再试。风云的老一辈大多是望子成龙，每到一年一
        度的考季，这里就会人山人海，看热闹的比参考的还多。。
"

                );
            set("exits", new Dictionary<string, string>(){
                 
                         
                             { "north", __DIR__+"wcloud1" },

            });

            set("outdoors", "fengyun");
            //      set("objects", Tuple.Create<string,int>(__DIR__ + "npc.caifan",1));

            //                ]));
            set("coor/x", -40);
            set("coor/y", 10);
            set("coor/z", 0);
           
        }
    }

