using System;

namespace Bitmex.NET
{
    public class BitmexSocketMessageEventArgs : EventArgs
    {
        public BitmexSocketMessageEventArgs(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
}