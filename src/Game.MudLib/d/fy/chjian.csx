using Game.Facility.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


    public class chjian : RoomState
    {

        public override void create()
        {



            set("short", "忏悔间");
            set("long", @"
        一间只容一个人的小房间。房间的一面墙上有孔，这里的声音可以很清晰的传
        到隔壁。房间里只有张小木凳和钉在墙上供人放东西的木板。
"

                );
            set("exits", new Dictionary<string, string>(){
                 
                             { "south", __DIR__+"church" },

            });

            set("outdoors", "fengyun");
            //      set("objects", Tuple.Create<string,int>(__DIR__ + "npc.caifan",1));

            //                ]));
            set("coor/x", -40);
            set("coor/y", 10);
            set("coor/z", 0);
           
        }
    }
