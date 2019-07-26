using Game.Core.Interface;
using Game.Facility.Interface;
using Microsoft.Extensions.Logging;
using Orleans;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Facility.Grains
{
    public class Room :Grain<RoomState>, IRoom
    {
        ILogger logger;
        RoomFactory _factory;
        public Room(RoomFactory factory,ILogger<Room> logger)
        {
            _factory = factory;
            this.logger = logger;
        }
        public async override Task OnActivateAsync()
        {
            if (State == null || string.IsNullOrWhiteSpace(State.Short))
            {
                try
                {
                    var tmpState = await _factory.GetRoom(this.GetPrimaryKeyString());
                    State = tmpState;
                }
                catch(Exception err)
                {
                    logger.LogError(err, $"Active Room ({this.GetPrimaryKeyString()}) Error!");
                }
            }
           await base.OnActivateAsync();
        }
        public  async Task<RoomState> Enter(string player)
        {
            IPlayer me = GrainFactory.GetGrain<IPlayer>(player);
            if (!State.Players.Contains(player))
            {
                State.Players.Add(player);
                
                await me.Notify(await GetText());
                //知会房间的人
                foreach (var p in State.Players)
                {
                    if (string.Equals(p, player)) continue;

                    IPlayer op = GrainFactory.GetGrain<IPlayer>(p);
                    await op.Notify($"{player}进来了");
                }
            }
            return State;
        }

        public async Task<RoomState> Get()
        {
            return State;
        }

        public async Task<bool> Leave(string player,string dir)
        {
            IPlayer me = GrainFactory.GetGrain<IPlayer>(player);
            if (State.validate_leave(me, dir))
            {

                //知会房间的人
                foreach (var p in State.Players)
                {
                    if (string.Equals(p, player)) continue;

                    IPlayer op = GrainFactory.GetGrain<IPlayer>(p);
                    await op.Notify($"{player}向{dir}离开了");
                }

                if (State.Players.Contains(player))
                    State.Players.Remove(player);
                return true;
            }
            else
                return false;
        }

        public async Task<string> GetText()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(State.Short);
            sb.AppendLine(State.Long);
            if (State.Exits.Count == 0)
            {
                sb.AppendLine("    这里没有任何明显的出路。\n");
            }
            else if (State.Exits.Count == 1)
            {
                sb.AppendLine($"这里唯一的出口是{AnsiConst.BOLD} {State.Exits.Keys.First<string>()}。{AnsiConst.NOR}\n");
            }
            else
            {
                sb.Append("    这里明显的出口有  ");
                foreach (var e in State.Exits)
                {
                    sb.Append($"{AnsiConst.BOLD}{e.Key}{AnsiConst.NOR}  ");
                }
                sb.AppendLine("。");
            }
            //list players
            int j = 0;
            foreach (var i in State.Players)
            {
                sb.AppendLine("  " + i);
                j++;
                if (j > 10) //超过10人在房间时就不列出来了；
                    break;
            }

            foreach (var id in State.NPCs)
            {
                var npc = GrainFactory.GetGrain<INPC>(id);
                var s = await npc.Get();
                sb.AppendLine($"  {s.Title}     {s.Name}");
            }
           return sb.ToString();
        }
        public Task<List<KeyValuePair<string, string>>> QueryEntry()
        {
            throw new NotImplementedException();
        }

        public Task<string> QueryPlayer(string name)
        {
            throw new NotImplementedException();
        }
    }
}
