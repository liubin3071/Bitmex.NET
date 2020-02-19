using Bitmex.NET.Dtos.Socket;
using System;
using System.Buffers;
using System.Linq;
using System.Text.Json;

namespace Bitmex.NET.Models.Socket
{
    public abstract class BitmexApiSubscriptionInfo
    {
        public string SubscriptionName { get; }

        public object[] Args { get; protected set; }

        public string SubscriptionWithArgs => (Args?.Any() ?? false) ? $"{SubscriptionName}:{string.Join(",", Args)}" : SubscriptionName;

        protected BitmexApiSubscriptionInfo(string subscriptionName)
        {
            SubscriptionName = subscriptionName;
        }

        public abstract void Execute(JsonElement data, BitmexActions action);
    }

    public class BitmexApiSubscriptionInfo<TResult> : BitmexApiSubscriptionInfo
        where TResult : class
    {
        public Action<BitmexSocketDataMessage<TResult>> Act { get; }

        public BitmexApiSubscriptionInfo(SubscriptionType subscriptionType, Action<BitmexSocketDataMessage<TResult>> act) : base(Enum.GetName(typeof(SubscriptionType), subscriptionType))
        {
            Act = act;
        }

        public BitmexApiSubscriptionInfo<TResult> WithArgs(params object[] args)
        {
            Args = args;
            return this;
        }

        public static BitmexApiSubscriptionInfo<TResult> Create(SubscriptionType subscriptionType, Action<BitmexSocketDataMessage<TResult>> act)
        {
            return new BitmexApiSubscriptionInfo<TResult>(subscriptionType, act);
        }

        public override void Execute(JsonElement data, BitmexActions action)
        {
#if  NETSTANDARD2_0
            var dataObj = JsonSerializer.Deserialize<TResult>(data.GetRawText());
#elif NETSTANDARD2_1
            var bufferWriter = new ArrayBufferWriter<byte>();
            using (var writer = new Utf8JsonWriter(bufferWriter))
                data.WriteTo(writer);
            var dataObj = BitmexJsonSerializer.Deserialize<TResult>(bufferWriter.WrittenSpan);
#endif

            Act?.Invoke(new BitmexSocketDataMessage<TResult>(action, dataObj));
        }
    }
}