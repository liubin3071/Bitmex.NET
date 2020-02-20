using System;
using System.Buffers;
using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Bitmex.NET
{
    public static class BitmexJsonSerializer
    {
        public static readonly JsonSerializerOptions DefaultOptions = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            PropertyNameCaseInsensitive = true,
            Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) },
        };

        public static TResult Deserialize<TResult>(string json)
        {
            return JsonSerializer.Deserialize<TResult>(json, DefaultOptions);
        }

        public static TResult Deserialize<TResult>(ReadOnlySpan<byte> writtenSpan)
        {
            return JsonSerializer.Deserialize<TResult>(writtenSpan, DefaultOptions);
        }

        public static string Serialize<T>(T obj)
        {
            return JsonSerializer.Serialize(obj, DefaultOptions);
        }

        public static string Serialize(object obj, Type inputType)
        {
            return JsonSerializer.Serialize(obj, inputType, DefaultOptions);
        }

        public static TResult Deserialize<TResult>(JsonDocument jsonDocument)
        {
            return Deserialize<TResult>(jsonDocument.RootElement);
        }

        public static TResult Deserialize<TResult>(JsonElement jsonElement)
        {
#if NETSTANDARD2_0
            return JsonSerializer.Deserialize<TResult>(jsonElement.GetRawText(), DefaultOptions);
#else
            var bufferWriter = new ArrayBufferWriter<byte>();
            using var writer = new Utf8JsonWriter(bufferWriter);
            jsonElement.WriteTo(writer);
            writer.Flush();
            return JsonSerializer.Deserialize<TResult>(bufferWriter.WrittenSpan, DefaultOptions);
#endif
        }
    }
}