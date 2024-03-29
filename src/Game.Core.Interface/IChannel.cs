﻿
using Orleans;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Game.Core.Interfaces
{
    public interface IChannel:IGrainWithGuidKey
    {
        Task<Guid> Join(string nickname);
        Task<Guid> Leave(string nickname);
        Task<bool> Message(ChatMsg msg);
        Task<ChatMsg[]> ReadHistory(int numberOfMessages);
        Task<string[]> GetMembers();
    }
}
