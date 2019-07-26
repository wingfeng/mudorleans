using Game.Facility.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


    public class baozipu : RoomState
    {

        public override void create()
        {



            set("short", "薛记老号");
            set("long", @"
        这包子铺已经在这里几十年了，自开张后就没换过门面，布置还是那么简陋，
        屋子里面仅有的几张方桌和长凳都已经看不出原来的颜色。肮脏而残破的碗筷零乱
        地散落在桌面上，墙角里随便扔着几支脏稀稀的筷子，上面已结满蜘蛛网。几只苍
        蝇盲目地飞来飞去，为这死气沉沉的店堂添了几分生气。
"

                );
            set("exits", new Dictionary<string, string>(){
                 
                             { "east", __DIR__+"nwind5" },

            });

            set("outdoors", "fengyun");
            //      set("objects", Tuple.Create<string,int>(__DIR__ + "npc.caifan",1));

            //                ]));
            set("coor/x", -40);
            set("coor/y", 10);
            set("coor/z", 0);
           
        }
    }

