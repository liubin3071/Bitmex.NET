using System;
using System.Text.Json;

namespace Bitmex.NET.Models.Socket
{
    public abstract class JsonRequest : SocketRequest
    {
        public override string GetContent()
        {
            return BitmexJsonSerializer.Serialize(this, GetType());
        }
    }
}