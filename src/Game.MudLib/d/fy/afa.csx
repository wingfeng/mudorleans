using Game.Facility.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

    public class afa : RoomState
    {

        public override void create()
        {



            set("short", "阿发木器店");
            set("long", @"
        这里的老板是从南方过来的。官话很差，所以生意并不很好。但阿发好像并不
        在乎，似乎另有发财之路。他好像很怕光，所以这里一盏灯也没有，从傍晚开始，
        店里黑漆漆的一片，阿发就睁着一双发亮的眼睛坐在屋里望着门外的大街。
"

                );
            set("exits", new Dictionary<string, string>(){
                          //   { "north", __DIR__+"stone1" },
                             { "south", __DIR__+"wcloud4" },
                        //     { "east", __DIR__+"ecloud2" },
                         //   { "west", __DIR__+"fysquare" }
            });

            set("outdoors", "fengyun");
            //      set("objects", Tuple.Create<string,int>(__DIR__ + "npc.caifan",1));

            //                ]));
            set("coor/x", -40);
            set("coor/y", 10);
            set("coor/z", 0);
           
        }
    }

