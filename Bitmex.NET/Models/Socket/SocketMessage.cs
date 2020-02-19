using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Bitmex.NET.Models.Socket
{
    public interface ISocketRequestMessage
    {
        string GetContent();
    }

    public abstract class SocketMessage : ISocketRequestMessage
    {
        [JsonPropertyName("op")]
        public string Operation { get; }

        [JsonPropertyName("args")]
        public object[] Arguments { get; }

        protected SocketMessage(OperationType operation, params object[] args)
        {
            Operation = Enum.GetName(typeof(OperationType), operation);
            Arguments = args;
        }

        public string GetContent() => BitmexJsonSerializer.Serialize(this);
    }
}