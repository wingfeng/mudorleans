using Game.Core.Interface;
using Game.Facility.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

    public class ngate : RoomState
    {

        public override void create()
        {

            set("short", "风云北城门");
            set("long", @"
    风云北门高叁丈，宽约二丈有余，尺许厚的城门上镶满了拳头般大小的柳钉。
门洞长约四丈，大约每隔两个时辰就换官兵把守。洞侧帖满了悬赏捉拿之类的官
    府通谍。门洞西侧则是一条上城墙的窄梯。
"
            );
            set("exits", new Dictionary<string, string>(){
                { "south" , __DIR__+"nwind5" },
   //   { "north" , __DIR__+"ngate" },
       { "down" , __DIR__+"ngatedown" },
//      { "up" , AREA_FYWALL+"nupgate" },
      }

            );
            set("outdoors", "fengyun");
            //set("objects", ([
            //__DIR__"npc/dtz": 2,

            //                ]));
            set("coor/x", 0);
            set("coor/y", 60);
            set("coor/z", 0);
            
            base.create();
        }
        public override bool validate_leave(IPlayer me, string dir)
        {
            if (dir == "down")
            {
                me.Notify("你要去哪里？");
                return false;
            }
            return true;
        }
    }