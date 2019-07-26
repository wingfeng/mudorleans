using Game.Facility.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


    public class wgate : RoomState
    {

        public override void create()
        {

            set("short", "风云西城门");
            set("long", @"
        西城门阁矮小而破旧，守城卫兵斜戴着红樱帽，搂着长枪在打瞌睡。也许因为
        西城区所住皆贫困撩倒之徒，这里的治安和卫生都不是很好。狂风掠过之时，满地
        垃圾随风飞舞，夜幕降临之后，惨号和狞笑声此起彼伏。
"
            );
            set("exits", new Dictionary<string, string>(){

      { "east" , __DIR__+"wcloud5" },
   //          { "south" , "/d/fycycle/fysouth" },
 
//      { "up" , AREA_FYWALL+"nupgate" },
      }

            );
            set("outdoors", "fengyun");
            //set("objects", ([
            //__DIR__"npc/dtz": 2,

            //                ]));
            set("coor/x", -60);
            set("coor/y", 0);
            set("coor/z", 0);

           
        }
    }

