using Game.Facility.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


    public class futhur : RoomState
    {

        public override void create()
        {

            set("short", "红屋");
            set("long", @"
    这是西城区唯一比较像样的建筑，但颜色很怪，一种血色干凝的暗红色。屋里
    更是鬼气森森。房子无窗，一盏油灯忽明忽暗。以太极八卦图为底的招牌上用篆体
    刻着四个字“生死已卜”，也是黯淡无光的红色。
"

                );
            set("exits", new Dictionary<string, string>(){
                 
                         
                             { "south", __DIR__+"wcloud3" },

            });

            set("outdoors", "fengyun");
            //      set("objects", Tuple.Create<string,int>(__DIR__ + "npc.caifan",1));

            //                ]));
            set("coor/x", -40);
            set("coor/y", 10);
            set("coor/z", 0);
           
        }
    }
