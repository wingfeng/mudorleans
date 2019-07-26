using System;
using System.Collections.Generic;
using System.Text;

namespace Game.Core.Interfaces
{
    [Serializable]
    public class ChatMsg
    {
        public DateTimeOffset Created { get; set; } = DateTimeOffset.Now;
        public string Author { get; set; } = "Alexey";
        public string Text { get; set; }
        public string ChannelName { get; set; }

        public ChatMsg()
        {
        }

        public ChatMsg(string author, string msg)
        {
            Author = author;
            Text = msg;
        }
    }
}
