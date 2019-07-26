using Game.Facility.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

    public class jssju : RoomState
    {

        public override void create()
        {

            set("short", "警世书局");
            set("long", @"
    这是风云城中唯一的书局，是城中卖书最多最快的地方。老板大有名气，听说
    是当今皇太子的老师。凡是京都出的新书，都被快马送到这里，然后刻板印刷。书
    局里不但有很多风骚文人喜欢的诗词，还卖一些粗浅的功夫书，供城中居民练来强
    身健体。
"

                );
            set("exits", new Dictionary<string, string>(){
                 
                         
                             { "east", __DIR__+"nwind1" },

            });

            set("outdoors", "fengyun");
            //      set("objects", Tuple.Create<string,int>(__DIR__ + "npc.caifan",1));

            //                ]));
            set("coor/x", -10);
            set("coor/y", 10);
            set("coor/z", 0);
           
        }
    }

