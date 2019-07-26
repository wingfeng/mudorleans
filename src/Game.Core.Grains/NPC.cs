using Game.Core.Interface;
using Game.Core.Interface.Model;
using Orleans;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Grains
{
    public class NPC : Grain<CharacterState>, INPC
    {
        ICharacterFactory factory;
        public async override Task OnActivateAsync()
        {
            if (string.IsNullOrWhiteSpace(State.id))
            {
                var orgId = this.GetPrimaryKeyString();
                orgId = objectId(orgId);
                State = await factory.create(orgId);

            }
            await base.OnActivateAsync();
        }
        private string objectId(string id)
        {
            var s = id.Split('_');
            //取消最后一个_
            string[] target = new string[s.Length - 1];
            Array.Copy(s, target,s.Length - 1);
           return string.Join("_", target);
        }
        public NPC(ICharacterFactory factory)
        {
            this.factory = factory;

        }
        public async Task Beat(long ticks)
        {
         //do nothing on beat;
        }

        public async Task<CharacterState> Get()
        {
            return this.State;
        }
    }
}
