
using Game.Core.Interface;
using Game.Facility.Interface;
using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Concurrency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Game.Facility.Grains
{
  
    public class WorldService:Grain,IWorld
    {
        ILogger log;
        RoomFactory roomFactory;
        public WorldService(RoomFactory factory,ILogger<WorldService> logger)
        {
            roomFactory = factory;
            log = logger;
        }
        public static List<PlayerState> players = new List<PlayerState>()
        {
             new PlayerState()
                {
                    Short = "wing",
                    Long = "天神",
                    PasswordHash = "Pass@word0"

                },
             new PlayerState()
                {
                    Short = "sample",
                    Long = "普通百姓",
                    PasswordHash = "12345"

                }

    };
   

        //public async Task<RoomState> GetRoom(string id)
        //{
        //    try
        //    {
        //        if (string.IsNullOrWhiteSpace(id))
        //        {
        //            id = roomFactory.BornRoom;
        //        }
        //        var room = GrainFactory.GetGrain<IRoom>(id);
        //        return await room.Get();
        //    }catch(Exception err)
        //    {
        //        log.LogError($"Get Room{id} State Error!", err);
        //    }
        //    return null;
        //}

        public async Task<string> GetBornplaceId()
        {
            return roomFactory.BornRoom;
        }

        public async Task<bool> PlayerLogin(string account, string password)
        {

            //foreach (var p in players)
            //{
            //    if(string.Equals(account,"wing"))
            //        return true;
            //    if (string.Equals(p.Name, account) && string.Equals(p.PasswordHash, password))
            //        return true;
            //}
            try
            {
                var player = GrainFactory.GetGrain<IPlayer>(account);
                if (await player.CheckPassword(password))
                {
                    var pState = await player.Get();
                    var roomId = pState.RoomId ?? roomFactory.BornRoom;

                    await player.EnterRoom("", roomId);
                    await player.Login();
                    return true;
                }
            }
            catch (Exception err)
            {
                log.LogError(err, $"User {account} Login Fail!");
            }
            return false;
        }

        public Task<bool> Register(string account, string Password)
        {
            throw new NotImplementedException();
        }

        public async Task Reset(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                RoomFactory.RoomScripts.Clear();
            else
                RoomFactory.RoomScripts.Remove(id);
        }
    }
}
