using System;
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
    }
}