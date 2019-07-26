using Game.Core.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Game.Core.Grains
{
    public class MudConsole : IConsole
    {
        MudWriter mw;
        public MudConsole(IPlayer p)
        {
            mw = new MudWriter(p);

        }
        public TextWriter Out => mw;

        public TextWriter Error => mw;

        public TextReader In => throw new NotImplementedException();

        public bool IsInputRedirected => throw new NotImplementedException();

        public bool IsOutputRedirected => throw new NotImplementedException();

        public bool IsErrorRedirected => throw new NotImplementedException();

        public ConsoleColor ForegroundColor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ConsoleColor BackgroundColor { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event ConsoleCancelEventHandler CancelKeyPress;

        public void ResetColor()
        {
            throw new NotImplementedException();
        }
    }
    internal class MudWriter : TextWriter
    {
        IPlayer player;
        public MudWriter(IPlayer p)
        {
            player = p;
        }
        public override void WriteLine(string value)
        {
            player.Notify(value);
        }
        public override Encoding Encoding => UTF8Encoding.UTF8;
    }
}
