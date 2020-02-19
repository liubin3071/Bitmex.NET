using System.Text.Json;
using System.Text.Json.Serialization;

namespace Bitmex.NET.Models
{
    public abstract class QueryJsonParams : IJsonQueryParams
    {
        public string ToJson()
        {
            return BitmexJsonSerializer.Serialize(this, GetType());
        }
    }
}