using Game.Facility.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


    public class stopwin : RoomState
    {

        public override void create()
        {

            set("short", "镇风兵器铺");
            set("long", @"
        当今武林奇侠辈出，武林好汉空前众多，这里的生意也因此好得不得了。此处
        的老板就是这四个甲子名气最响亮的金狮总镖头。这里的大掌柜则是当年大镖头的
        儿子。这里的兵器应有尽有，绝对不会有买不到的。
"

                );
            set("exits", new Dictionary<string, string>(){
                 
                         
                             { "east", __DIR__+"nwind4" },

            });

            set("outdoors", "fengyun");
            //      set("objects", Tuple.Create<string,int>(__DIR__ + "npc.caifan",1));

            //                ]));
            set("coor/x", -10);
            set("coor/y", 20);
            set("coor/z", 0);
           
        }
    }

