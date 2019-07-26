using Game.Core.Interface;
using Game.Core.Interface.Enum;
using Game.Core.Interface.Model;
using Game.Core.Interfaces;
using Game.Facility.Interface;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Concurrency;
using Orleans.Streams;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Reflection.Metadata;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Grains
{

    public class Player : Grain<PlayerState>, IPlayer
    {

        ILogger logger;
        public Player(ILogger<Player> logger)
        {

            this.logger = logger;
        }
        private IAsyncStream<PlayerNotifyMsg> stream;
        public async override Task OnActivateAsync()
        {
            if (string.IsNullOrWhiteSpace(State.Short))
            {
                State.id = this.GetPrimaryKeyString();
                State.Short = State.id;
                State.create();
            }
            var streamProvider = GetStreamProvider(Constants.NotifyStreamProvider);
            if (State.guid == Guid.Empty)
                State.guid = Guid.NewGuid();

            stream = streamProvider.GetStream<PlayerNotifyMsg>(State.guid, Constants.NotifyStreamNamespace);



            base.OnActivateAsync();
        }



        public async Task<PlayerState> Get()
        {

            return State;
        }

        public Task Kill(string target)
        {
            throw new NotImplementedException();
        }
        public async Task Set(string prop,object value)
        {
            State[prop] = value;
        }
        public async Task Look(string target)
        {
            var room = GrainFactory.GetGrain<IRoom>(State.RoomId);

            var roomState = await room.Get();
          
            var msg = "房间里有:\r\n";
            foreach (var s in roomState.Players)
            {
                msg += s + "\n\r";
            }
            await Notify(msg);
        }

        public async Task Notify(string msg, NotifyType type = NotifyType.Message)
        {
            PlayerNotifyMsg notify = new PlayerNotifyMsg()
            {
                Message = msg,
                Type = type
            };
            await stream.OnNextAsync(notify);
        }
        public async Task EnterRoom(string dir,string newRoom)
        {
            var curRoom = await getCurrentRoom();
            if (curRoom != null)
            {
                bool canLeave = await curRoom.Leave(State.Short, dir);
               if(!canLeave)
                    return;
            }

            var room = GrainFactory.GetGrain<IRoom>(newRoom);

            await room.Enter(State.Short);
            State.RoomId = newRoom;
        }

        private async Task<IRoom> getCurrentRoom()
        {
            if (!string.IsNullOrWhiteSpace(State.RoomId))
            {
                var currRoom = GrainFactory.GetGrain<IRoom>(State.RoomId);
                return currRoom;
            }
            return null;
        }

        public async Task Login()
        {
            State.Status = PlayerStatus.Active;

        }
        public async Task<bool> CheckPassword(string pwd)
        {
            //ToDo:Check the user password hash;
            return true;
        }
        List<string> _commands = new List<string>()
        {
            "look",
            "say",
            "kill"

        };

        public async Task<T> Query<T>(string prop)
        {
            if (State.ContainsKey(prop))
                return (T)State[prop];

            return default(T);
        }
        public async Task Quit()
        {
            State.Status = PlayerStatus.Offline;
            var curRoom = await getCurrentRoom();
            if (curRoom != null)
                await curRoom.Leave(State.Short,"");
            await Notify($"{AnsiConst.YEL}再见，欢迎下次再来!");
            await Notify("exit", NotifyType.System);
        }
        #region useless code
        public async Task<List<string>> GetCommands()
        {
            return _commands;
        }



        #endregion
        public Task<bool> ChangePassword(string newPwd, string oldPwd)
        {
            throw new NotImplementedException();
        }
    }
}
