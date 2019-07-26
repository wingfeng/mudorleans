using Game.Facility.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


    public class nwind2 : RoomState
    {

        public override void create()
        {

            set("short", "北风街");
            set("long", @"
	这里是风云广场的北边，再往北眺望可以看到远处高耸的城墙。热闹的街道上
	充溢着清新的花香和甜丝丝脂粉的香气。花香是从大街东侧的飘香花店荡漾出来的，
	而浓厚的脂粉气息则是西首倾城胭脂店的招牌。
"
            );
            set("exits", new Dictionary<string, string>(){
                    { "south" , __DIR__+"nwind1"},
                    { "north" , __DIR__+"nwind3"},
                    { "east" ,__DIR__+"pxhdian"},
                    { "west" , __DIR__+"qcyzdian"}
            }

            );

            set("outdoors", "fengyun");
            set("coor/x", 0);
            set("coor/y", 20);
            set("coor/z", 0);

           
        }
    }

