using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Core.Interface
{
    public class Constants
    {
        public const string ChatStreamProvider = "ChatStreamProvider";
        public const string ChatStreamNamespace = "Chat";
        public static readonly Guid PublicChannelId = Guid.Parse("ECA180C0-E7B1-4BB9-8D3C-5B1F18D61A1C");

        public const string NotifyStreamProvider = "NotifyStreamProvider";
        public const string NotifyStreamNamespace = "Notify";

        public const string MudLibKey = "MudLibPath";
    }
}
