using Game.Facility.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


    public class examp : RoomState
    {

        public override void create()
        {


            set("short", "����");
            set("long", @"
        ���Ƴ��˲ű�����������־�ڻ�;�ķ��������˶�Ҫ������ͨ����һ�ο��ԡ�
        ����˫ȫ��ǰ�����ᱻ���뾩�����ԡ����Ƶ���һ����������ӳ�����ÿ��һ��һ
        �ȵĿ���������ͻ���ɽ�˺��������ֵıȲο��Ļ��ࡣ��
"

                );
            set("exits", new Dictionary<string, string>(){
                 
                         
                             { "north", __DIR__+"wcloud1" },

            });

            set("outdoors", "fengyun");
            //      set("objects", Tuple.Create<string,int>(__DIR__ + "npc.caifan",1));

            //                ]));
            set("coor/x", -40);
            set("coor/y", 10);
            set("coor/z", 0);
           
        }
    }

