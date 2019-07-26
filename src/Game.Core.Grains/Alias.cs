using Game.Core.Interface;
using Orleans;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Grains
{
    public class Alias : Grain<Dictionary<string, string>>, IAlias
    {
        public override Task OnActivateAsync()
        {
            if (State.Count == 0)
            {
                State = new Dictionary<string, string>() {
                    {"n","go north" },
                    {"nw","go northwest" },
                    {"ne","go neortheast" },
                    {"e","go east" },
                    {"w","go west" },
                    {"s","go south" },
                    {"sw","go southwest" },
                    {"se","go southeast" },
                    {"u","go up" },
                    {"up","go up" },
                    {"d","go down" },
                    {"down","go down" }
                };
            }
            return base.OnActivateAsync();
        }
        public async Task<Dictionary<string, string>> Get()
        {
            return State;
        }

        public async Task SetAlias(string alias, string cmd)
        {
            State.Add(alias, cmd);
        }
    }
}
