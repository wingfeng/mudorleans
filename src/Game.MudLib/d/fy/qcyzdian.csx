using Game.Facility.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


    public class qcyzdian : RoomState
    {

        public override void create()
        {

            set("short", "�����֬��");
            set("long", @"
    ��������Ÿ�ʽ��������֬���дӾ��������ģ�Ҳ�б��ز��ġ���֬�ʺ���Ѫ,
    �����˱ǡ�ÿ����������������������ڣ�ӳ����֬�ϣ�����һ��ҫ�۵����졣��
    ����֬���ﻹ���ٻ��ͣ����۴������ϰ���˵������ʮ�������������������ݸ��֡�   
"

                );
            set("exits", new Dictionary<string, string>(){
                 
                         
                             { "east", __DIR__+"nwind2" },

            });

            set("outdoors", "fengyun");
            //      set("objects", Tuple.Create<string,int>(__DIR__ + "npc.caifan",1));

            //                ]));
            set("coor/x", -10);
            set("coor/y", 20);
            set("coor/z", 0);
           
        }
    }

