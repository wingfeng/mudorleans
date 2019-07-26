using Game.Core.Interface;
using Game.Core.Interface.Model;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Orleans.Core;
using Orleans.Runtime;
using Orleans.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Grains
{
    public class CharacterFactory : ICharacterFactory, IGrainService
    {
        ILogger logger;
        public string LibPath { get; set; }
        Dictionary<string, CharacterState> npcs;
        public CharacterFactory(IConfiguration config, ILogger<CharacterFactory> logger)
        {
            LibPath = config.GetValue<string>(Constants.MudLibKey);
            npcs = new Dictionary<string, CharacterState>();
            this.logger = logger;
        }

        readonly object locker = new object();
        static Dictionary<string, CharacterState> scripts = new Dictionary<string, CharacterState>();
        public static Dictionary<string, CharacterState> Scripts { get { return scripts; } }
        string getNPCName(string id)
        {
            var str = id.Split('/');
            return str[str.Length - 1].ToLower();
        }
        string getDir(string id)
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
        private async Task<CharacterState> getNPCFromScript(string id)
        {
            string roomName = getNPCName(id);
            string scriptPath = Path.Combine(LibPath, $"{id}.csx");

            if (!File.Exists(scriptPath))
                return null;

            CharacterState state = null;

            if (scripts.TryGetValue(id, out state))
            {
                return state;
            }
            else
            {
                using (var file = File.OpenText(scriptPath))
                {
                    var scriptTxt = file.ReadToEnd();
                    var option = ScriptOptions.Default.WithReferences(typeof(ScriptGlobal).Assembly);
                    option.WithReferences(typeof(AnsiConst).Assembly);
                    option.WithReferences(typeof(CharacterState).Assembly);
                    //option.WithImports("System.IO");
                    //option.WithImports("System.Threading.Tasks");
                    //option.WithImports("Game.Core.Interface");

                    scriptTxt += $"\n var _state=new {roomName}();_state.create();return _state;";
                    var script = CSharpScript.Create<CharacterState>(scriptTxt, option, typeof(ScriptGlobal));
                    script.Compile();
                    ScriptGlobal global = new ScriptGlobal()
                    {
                        __DIR__ = getDir(id)
                    };
                    var scriptResult = script.RunAsync(global).GetAwaiter().GetResult();
                    state = scriptResult.ReturnValue;

                    scripts.Add(id, state);
                    return state;
                }
            }




        }

        public async Task<CharacterState> create(string id)
        {
            try
            {
                id = id?.ToLower();
                var state = await getNPCFromScript(id);
                return state;
            }
            catch (Exception err)
            {
                logger.LogError(err, @"Create Room ({id}) Error.");
                throw err;
            }
            return null;
        }
    }

    public class ScriptGlobal
    {
        public IPlayer me { get; set; }
        public string __DIR__;

    }
}
