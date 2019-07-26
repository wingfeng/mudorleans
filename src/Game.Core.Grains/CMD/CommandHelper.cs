using CommandLine;
using Game.Core.Interface;
using Game.Facility.Interface;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.Extensions.Options;
using Orleans;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq.Expressions;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Grains.Cmd
{
    public class CommandHelper
    {
        public static string BasePath { get; set; }
        private static List<Type> types;
        private static object locker = new object();
        IGrainFactory Factory;
        static List<Type> CommandTypes
        {
            get
            {
                lock (locker)
                {
                    if (types == null)
                    {
                        types = new List<Type>();
                        var assembly = typeof(CommandBase).Assembly;
                        foreach (var t in assembly.GetTypes())
                        {
                            if (t.IsSubclassOf(typeof(CommandBase)))
                                types.Add(t);
                        }
                    }
                }
                return types;
            }
        }
        public static async Task Exec(string[] args, IPlayer player, IGrainFactory grainFactory)
        {
            var parser = new Parser(with =>
            {
                with.EnableDashDash = false;

                //     with.HelpWriter = session.Out;
            });


            var result = parser.ParseArguments(args, CommandTypes.ToArray())
            .WithParsed<CommandBase>(async opts =>
            {
                try
                {
                    await opts.Execute(player, grainFactory);
                }
                catch (Exception err)
                {
                    //  throw err;
                }


            }).WithNotParsed(async testc =>
            {
                var pState = await player.Get();
                IRoom room = grainFactory.GetGrain<IRoom>(pState.RoomId);
                try
                {
                    var cRes = await callScriptCommand(player, room, args);
                    if (cRes == 0)
                        await player.Notify($"我不懂你在做什么呢？试试{AnsiConst.HIG}help{AnsiConst.NOR}命令？");
                }
                catch (Exception err)
                {
                    await player.Notify(err.ToString());
                }

            }

          );

        }
       static Dictionary<string, Script<int>> commandScripts = new Dictionary<string, Script<int>>();
        public static Dictionary<string,Script<int>> CommandScripts
        {
            get { return commandScripts; }
           
        }
        private static async Task<int> callScriptCommand(IPlayer me, IRoom room, string[] args)
        {
            string strCmd = args[0];
            string cmdPath = Path.Combine(BasePath, "cmds", $"{strCmd}.csx");
            string leftArgs = "";
            if (!File.Exists(cmdPath))
                return 0;
            if (args.Length > 1)
            {
                string[] newArgs = new string[args.Length - 1];
                Array.Copy(args, 1, newArgs, 0, newArgs.Length);
                leftArgs = string.Join(" ", newArgs);
            }
            else
                args = new string[] { "" };
            Script<int> script = null;
            lock (locker)
            {
                if (commandScripts.ContainsKey(strCmd))
                {
                    script = commandScripts[strCmd];
                }
                else
                {
                    using (var file = File.OpenText(cmdPath))
                    {
                        var scriptTxt = file.ReadToEnd();
                        var option = ScriptOptions.Default.WithReferences(typeof(CommandGlobal).Assembly);
                        option.WithReferences(typeof(AnsiConst).Assembly);
                        option.WithImports("System.IO");
                        option.WithImports("System.Threading.Tasks");
                        option.WithImports("Game.Core.Interface");
                        script = CSharpScript.Create<int>(scriptTxt, option, typeof(CommandGlobal)).ContinueWith<int>("await main(me,args)");
                        script.Compile();
                        commandScripts.Add(strCmd, script);
                    }
                }
            }

            CommandGlobal global = new CommandGlobal()
            {
                me = me,
                room = room,
                args = leftArgs
            };
            var globals = await script.RunAsync(global);
            return 1;
        }


    }

    public class CommandGlobal
    {
        public IPlayer me { get; set; }
        public IRoom room { get; set; }

        public string args { get; set; }
        public int notify_fail(string msg)
        {
            me.Notify($"{AnsiConst.HIR}{msg}{AnsiConst.NOR}");
            return 1;
        }
        public int write(string msg)
        {
            me.Notify(msg);
            return 1;
        }
    }
}
