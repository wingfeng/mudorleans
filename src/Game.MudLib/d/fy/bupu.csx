using Game.Facility.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


    public class bupu : RoomState
    {

        public override void create()
        {



            set("short", "风云布铺");
            set("long", @"
    布铺里摆满了绫罗绸缎，这里专门订作，裁剪，改装各种鞋，帽，衫。老板娘
    做的衣服不但款式新颖，而且经久耐穿。风云城里老老少少们穿的大部份都是来自
    这儿。门口挂了一个大牌子（ｓｉｇｎ）．
"

                );
            set("exits", new Dictionary<string, string>(){
                 
                             { "south", __DIR__+"ecloud2" },

            });

            set("outdoors", "fengyun");
            //      set("objects", Tuple.Create<string,int>(__DIR__ + "npc.caifan",1));

            //                ]));
            set("coor/x", -40);
            set("coor/y", 10);
            set("coor/z", 0);
           
        }
    }

