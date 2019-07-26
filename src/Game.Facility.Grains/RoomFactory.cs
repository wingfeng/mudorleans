using Game.Core.Interface;
using Game.Facility.Interface;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Orleans.Services;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Game.Facility.Grains
{
    public class RoomFactory : IGrainService
    {
        ILogger logger;
        public string LibPath { get; set; }
        Dictionary<string, RoomState> _rooms = new Dictionary<string, RoomState>();
        public string BornRoom { get; set; }

        public RoomFactory(IConfiguration config, ILogger<RoomFactory> logger)
        {
            this.logger = logger;
            LibPath = config.GetValue<string>(Constants.MudLibKey);
            BornRoom = config.GetValue<string>("BornRoom") ?? "d/fy/fysquare";

        }

        /// <summary>
        /// 获取Room的原始状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<RoomState> GetRoom(string id)
        {
            try
            {
                var room = await getRoomFromScript(id);
                return room;
            }
            catch (Exception err)
            {
                logger.LogError(err, $"Get Room {id} Error!");
                throw err;
            }

            return null;
        }
        object locker = new object();
        static Dictionary<string, RoomState> roomScripts = new Dictionary<string, RoomState>();
        public static Dictionary<string, RoomState> RoomScripts { get { return roomScripts; } }
        string getRoomName(string id)
        {
            var str = id.Split('/');
            return str[str.Length - 1].ToLower();
        }
        string getRoomDir(string id)
        {
            string dir = "";
            var args = id.Split('/');
            if (args.Length > 1)
            {
                string[] newArgs = new string[args.Length - 1];
                Array.Copy(args, 0, newArgs, 0, newArgs.Length);
                dir = string.Join("/", newArgs);
            }
            if (dir.LastIndexOf('/') != dir.Length - 1)
                dir += "/";
            return dir;
        }
        private async Task<RoomState> getRoomFromScript(string id)
        {
            string roomName = getRoomName(id);
            string scriptPath = Path.Combine(LibPath, $"{id}.csx");

            if (!File.Exists(scriptPath))
            {
                logger.LogWarning($"Get Empty Room {id} State \n LibPath {LibPath}");
                return null;
            }

            RoomState state = null;

            if (roomScripts.TryGetValue(id, out state))
            {
                return state;
            }
            else
            {
                using (var file = File.OpenText(scriptPath))
                {
                    var scriptTxt = file.ReadToEnd();
                    var option = ScriptOptions.Default.WithReferences(typeof(RoomScriptGlobal).Assembly);
                    option.WithReferences(typeof(AnsiConst).Assembly);
                    option.WithReferences(typeof(RoomState).Assembly);
                    //option.WithImports("System.IO");
                    //option.WithImports("System.Threading.Tasks");
                    //option.WithImports("Game.Core.Interface");
                    string dir = getRoomDir(id);
                    scriptTxt += $"\n var _state=new {roomName}();_state.__DIR__=\"{dir}/\";_state.create();return _state;";
                    var script = CSharpScript.Create<RoomState>(scriptTxt, option, typeof(RoomScriptGlobal));//.ContinueWith<RoomState>($"var _state=new {roomName}();_state.create();return _state;");
                    script.Compile();
                    logger.LogWarning($"Script {id} Cache Added!");
                    RoomScriptGlobal global = new RoomScriptGlobal()
                    {
                        __DIR__ = getRoomDir(id)
                    };
                    var scriptResult = script.RunAsync(global).GetAwaiter().GetResult();
                    state = scriptResult.ReturnValue;
                    roomScripts.Add(id, state);
                    return state;
                }
            }

        }


        //public async Task Init(Assembly mublibAssembly)
        //{
        //    var types = mublibAssembly.GetTypes();
        //    foreach (var t in types)
        //    {
        //        if (t.IsSubclassOf(typeof(RoomState)))
        //        {
        //            RoomState state = t.InvokeMember("", BindingFlags.CreateInstance, null, null, null) as RoomState;
        //            state.create();
        //            _rooms.Add(t.FullName.ToLower(), state);
        //        }
        //    }

        //}
    }

    public class RoomScriptGlobal
    {
        public IPlayer me { get; set; }
        public string __DIR__;

    }
}
