using Game.Facility.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


    public class fqkhotel : RoomState
    {

        public override void create()
        {


            set("short", "凤求凰客栈");
            set("long", @"
    前厅挂着一幅龙凤双飞的巨画。当门挂着对鸳鸯球。球上系着几个小小的黄铜
    风铃。微风掠过，风铃发出清脆悦耳的叮咚声。大门两侧挂着斗大的大红灯笼，上
    书凤凰两字。朱门上横批一个“求”字。门前一口大缸，为往来行人提供清水。
"

                );
            set("exits", new Dictionary<string, string>(){
                 
                         
                             { "west", __DIR__+"swind1" },

            });

            set("outdoors", "fengyun");
            //      set("objects", Tuple.Create<string,int>(__DIR__ + "npc.caifan",1));

            //                ]));
            set("coor/x", -40);
            set("coor/y", 10);
            set("coor/z", 0);
           
        }
    }

