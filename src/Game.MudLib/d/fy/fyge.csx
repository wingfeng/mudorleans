using Game.Facility.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


    public class fyge : RoomState
    {

        public override void create()
        {
            set("short", "风云阁");
            set("long", @"
    风云阁的主人就是当年天下大名鼎鼎的小李飞刀。虽然李探花已经隐退多时，
    但是还有客人慕名来到此阁，以求一面之缘。阁中大红波斯地毯铺地，富丽堂皇。
    朱红的大门两侧各挂一幅石刻的对联儿：

                            一门七进士
    
                            父子三探花
    "
            );
            set("exits", new Dictionary<string, string>(){

     { "up", __DIR__+"fyyage" },
     { "west", __DIR__+"nwind1" }});

            set("outdoors", "fengyun");
            //set("objects", ([
            //__DIR__"npc/zhu": 1,

            //                ]));
            set("coor/x", 0);
            set("coor/y", 10);
            set("coor/z", 0);
           
        }
    }

