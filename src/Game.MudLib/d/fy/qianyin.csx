using Game.Facility.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


    public class qianyin : RoomState
    {

        public override void create()
        {

            set("short", "千银当铺");
            set("long", @"
        此当铺是南风大街对面的千金楼所设。以方便手头不宽的嫖客。千金楼的姑娘
        们也经常光顾这里，典当或是卖掉客人们高兴之余所赏赐的小玩意儿。此当铺虽然
        是千金楼所属，但却童叟无欺。当铺挂有牌（ｓｉｇｎ）一块。
"

                );
            set("exits", new Dictionary<string, string>(){
                 
                         
                             { "west", __DIR__+"swind4" },

            });

            set("outdoors", "fengyun");
            //      set("objects", Tuple.Create<string,int>(__DIR__ + "npc.caifan",1));

            //                ]));
            set("coor/x", -10);
            set("coor/y", 20);
            set("coor/z", 0);
           
        }
    }

