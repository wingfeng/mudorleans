using Game.Facility.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


    public class swind1 : RoomState
    {

        public override void create()
        {



            set("short", "广场南");
            set("long", @"
    北面就是风云的中心广场。这里是风云城中大富人家去集市的必经之路。豪富
    的行人导致了这里的崎形繁荣。大街西侧的玉龙珠宝店人进人出，拥挤不堪。东侧
    则是专门为有钱人的远方朋友到风云城来玩时所准备的凤求凰客栈。
"
            
            );
            set("exits", new Dictionary<string, string>(){
      { "south", __DIR__+"swind2" },
                    { "north", __DIR__+"fysquare" },
     { "east", __DIR__+"fqkhotel" },
     { "west", __DIR__+"yuljade" }});

            set("outdoors", "fengyun");
            //      set("objects", Tuple.Create<string,int>(__DIR__ + "npc.zhu",2));

            //                ]));
            set("coor/x", 0);
            set("coor/y", -10);
            set("coor/z", 0);
           
        }
    }

