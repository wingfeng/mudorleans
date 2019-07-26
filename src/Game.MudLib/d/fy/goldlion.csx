using Game.Facility.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


    public class goldlion : RoomState
    {

        public override void create()
        {

            set("short", "金狮镖局大院");
            set("long", @"
        这里几十年来几乎没有什么变化，黑石铺地，大院右边零乱的放着一些大小不
        一的石锁，想必是镖局中的趟子手用来练臂力的。左侧则是碗口粗细一人多高的梅
        花桩。总镖头查猛是少林俗家弟子出身，虽然教出的徒弟不怎么样，但是他的轻功
        和掌法都已经炉火纯青了。
"

                );
            set("exits", new Dictionary<string, string>(){
                 
                         
                             { "west", __DIR__+"nwind4" },

            });

            set("outdoors", "fengyun");
            //      set("objects", Tuple.Create<string,int>(__DIR__ + "npc.caifan",1));

            //                ]));
            set("coor/x", -10);
            set("coor/y", 20);
            set("coor/z", 0);
           
        }
    }

