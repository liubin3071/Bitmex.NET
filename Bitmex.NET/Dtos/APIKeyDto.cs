using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Bitmex.NET.Dtos
{
    public class APIKeyDto
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("secret")]
        public string Secret { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("nonce")]
        public decimal? Nonce { get; set; }

        /// <summary>
        /// CIDR block to restrict this key to. To restrict to a single address, append "/32", e.g. 207.39.29.22/32. Leave blank or set to 0.0.0.0/0 to allow all IPs. Only one block may be set.
        /// </summary>
        [JsonPropertyName("cidr")]
        public string Cidr { get; set; }

        /// <summary>
        /// Key Permissions. All keys can read margin and position data. Additional permissions must be added. Available: ["order", "orderCancel", "withdraw"].
        /// </summary>
        [JsonPropertyName("permissions")]
        public List<string> Permissions { get; set; }

        [JsonPropertyName("enabled")]
        public bool? Enabled { get; set; }

        [JsonPropertyName("userId")]
        public decimal? UserId { get; set; }

        [JsonPropertyName("created")]
        public DateTime? Created { get; set; }
    }
}