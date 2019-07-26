using Game.Facility.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


    public class jlong : RoomState
    {

        public override void create()
        {

            set("short", "浸龙堂");
            set("long", @"
        地板是上好的檀香木，光滑而略带潮湿。左手边是一个柜台，后面有个架子，
        上面挂满了白毛巾。几个如花似玉的小丫环正在忙碌，望向窗外，一个巨大的青铜
        缸架在烈火上，丫环们正在慢慢的加入清泉水。
"

                );
            set("exits", new Dictionary<string, string>(){
                 
                         
                             { "east", __DIR__+"nwind3" },

            });

            set("outdoors", "fengyun");
            //      set("objects", Tuple.Create<string,int>(__DIR__ + "npc.caifan",1));

            //                ]));
            set("coor/x", -10);
            set("coor/y", 20);
            set("coor/z", 0);
           
        }
    }

