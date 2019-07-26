using Game.Facility.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


    public class nwind5 : RoomState
    {

        public override void create()
        {

            set("short", "北门南");
            set("long", @"
    风街在这里渐渐变窄，街道两旁的店铺群立而又参差不齐。街的东边是一所小
    小的城隍庙，庙门破旧不堪。门上依稀的用木炭涂着一支手，这只手里似乎抓着十
    三支短箭。据说这里晚上常有鬼魂的出现。街的西边则是一家包子店。
"
            );
            set("exits", new Dictionary<string, string>(){
                { "south" , __DIR__+"nwind4" },
      { "north" , __DIR__+"ngate" },
      { "east" , __DIR__+"hiretem" },
      { "west" , __DIR__+"baozipu" },
      }

            );
            set("outdoors", "fengyun");
            //set("objects", ([
            //__DIR__"npc/dtz": 2,

            //                ]));
            set("coor/x", 0);
            set("coor/y", 50);
            set("coor/z", 0);

           
        }
    }

