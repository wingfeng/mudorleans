using Game.Combat.Interface;
using Game.Core.Interface;
using Game.Core.Interface.Model;
using Orleans;
using Orleans.Runtime;
using Orleans.Streams;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Game.Combat.Grains
{
    public class Combat : Grain<CombatState>, ICombat
    {
        static Random random = new Random(DateTime.Now.Millisecond);
    
        IDisposable combatTimer;
        IPlayer Attacker;
        public async Task Start(string creator, string[] victims)
        {
  
            State.id = this.GetPrimaryKey();

       
            Attacker = GrainFactory.GetGrain<IPlayer>(creator);
            State.Attacker = await Attacker.Get();
            State.Defender = await GrainFactory.GetGrain<INPC>(victims[0]).Get();

            combatTimer = this.RegisterTimer(Tick, null, TimeSpan.FromMilliseconds(0), TimeSpan.FromMilliseconds(1000));

        }

        private async Task Tick(object state)
        {
            string turn = "";
            if (State.Turns % 2 == 0)
            {
               turn= fight(State.Attacker, State.Defender);
            }
            else
                turn=fight(State.Defender, State.Attacker);
          await  Attacker.Notify(turn);
       //    await stream.OnNextAsync(turn);
            State.Turns++;
            if (State.Turns > 40)
            {
                State.Turns = 0;
                combatTimer.Dispose();
            }
        }

        private string fight(CharacterState attacker, CharacterState defender)
        {
            var deltaDodge = attacker.Dodge - defender.Dodge;
            var deltaDamage = attacker.Damage - defender.Defence;
            var deltaSpeed = attacker.Speed - defender.Speed;
            var result = "";
            //如果防守的闪避比进攻的高，有可能闪开
            if(deltaDodge>0 && random.Next(0,deltaDodge)>attacker.Dodge)
            {
                result = $"{defender.Name}轻轻一跃躲开了{attacker.Name}的攻击";
                
            }
            int damage = 1;
            if(deltaDamage>0)
             damage = random.Next(0, deltaDamage);
            result = $"{attacker.Name}攻击，导致{defender.Name}{AnsiConst.HIR}{damage}{AnsiConst.NOR}伤害";
            return result;
        }
        public Task Stop()
        {
            throw new NotImplementedException();
        }

        public async Task Watch(string p)
        {
          if(!State.Watcher.Contains(p))
            {
                State.Watcher.Add(p);
            }
        }
    }
}
