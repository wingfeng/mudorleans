using System.Threading.Tasks;
using Game.Core.Interface;

        async Task<int> main(object me, string arg)
        {
            var player =me as IPlayer;
			var result=await player.Query<int>(arg);
            write($"{AnsiConst.HIG}+{result}\n{AnsiConst.NOR}");
			
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

