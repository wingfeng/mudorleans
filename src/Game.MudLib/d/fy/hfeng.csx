using Game.Facility.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


    public class hfeng : RoomState
    {

        public override void create()
        {

            set("short", "佻���");
            set("long", @"
        佻��õ��������ǰ����ˣ�����ǽ�Ϸ�ɵĻ���ɢ�������˵����������õ�
        ���뻹�ǵ����Ǹ���ɫ�������ͭ�ɺף���������Ʈ���������̣�������Ƣ������
        ���ұ���һ��СС�Ĺ�̨��̨�ӵĺ�����һ��ľ�ܣ������Ϲ����˰�ë��
"

                );
            set("exits", new Dictionary<string, string>(){
                 
                         
                             { "west", __DIR__+"nwind3" },

            });

            set("outdoors", "fengyun");
            //      set("objects", Tuple.Create<string,int>(__DIR__ + "npc.caifan",1));

            //                ]));
            set("coor/x", -10);
            set("coor/y", 20);
            set("coor/z", 0);
           
        }
    }

