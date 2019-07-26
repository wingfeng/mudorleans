using System.Threading.Tasks;
using Game.Core.Interface;
        async Task<int> main(object me, string arg)
        {
            string[] txt;
            if (string.IsNullOrWhiteSpace(arg)) 
				{ 
				notify_fail("指令格式：describe <描述>\n");
				return 1;
				}
            if (arg == "none")
            {
             //   me->delete("long");
              //  write("描述删除完毕。\n");
                return 1;
            }
            txt = arg.Split('\n');
            if (txt.Length > 8)
			{    notify_fail("请将您对自己的描述控制在八行以内。\n");
		return 1;
			}
//            arg = implode(txt, "$NOR$\n") + "\n";
            arg.Replace( "$BLK$", AnsiConst.BLK);
            arg.Replace( "$RED$", AnsiConst.RED);
            arg.Replace( "$GRN$", AnsiConst.GRN);
            arg.Replace( "$YEL$", AnsiConst.YEL);
            arg.Replace( "$BLU$", AnsiConst.BLU);
            arg.Replace( "$MAG$", AnsiConst.MAG);
            arg.Replace( "$CYN$", AnsiConst.CYN);
            arg.Replace( "$WHT$", AnsiConst.WHT);
            arg.Replace( "$HIR$", AnsiConst.HIR);
            arg.Replace( "$HIG$", AnsiConst.HIG);
            arg.Replace( "$HIY$", AnsiConst.HIY);
            arg.Replace( "$HIB$", AnsiConst.HIB);
            arg.Replace( "$HIM$", AnsiConst.HIM);
            arg.Replace( "$HIC$", AnsiConst.HIC);
            arg.Replace( "$HIW$", AnsiConst.HIW);
            arg.Replace( "$NOR$", AnsiConst.NOR);
            ((IPlayer)me).Set("long", arg + AnsiConst.NOR);
			//
            write($"{AnsiConst.HIG}+Ok.\n{AnsiConst.NOR}");
			
            return 1;
        }
        int help()
        {
            write(@"
                指令格式：describe < 描述 >
                这个指令让你设定当别人用 look 指令看你时，对你的描述，通常当你
                的描述超过一行时可以用 to describe 的方式来输入。
                输入describe none可以删除你的当前描述。
                "
            );
			
            return 1;
        }

