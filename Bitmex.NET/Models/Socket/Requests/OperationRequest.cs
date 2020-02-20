using System.Text.Json.Serialization;

namespace Bitmex.NET.Models.Socket
{
    public class OperationRequest : JsonRequest
    {
        [JsonPropertyName("op")]
        public OperationType Operation { get; protected set; }

        [JsonPropertyName("args")]
        public object[] Arguments { get; protected set; }

        public OperationRequest(OperationType operation, params object[] args)
        {
            Operation = operation;// Enum.GetName(typeof(OperationType), operation);
            Arguments = args;
        }
    }
}