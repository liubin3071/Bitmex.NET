using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Bitmex.NET.Models.Socket.Responses
{
    /// <summary>
    /// 欢迎信息，连接后返回第一条消息
    /// </summary>
    public class WelcomeInfoResponse
    {
        //public override ResponseType Op => ResponseType.WelcomeInfo;

        public string Info { get; set; }
        public DateTime Version { get; set; }
        public DateTime Timestamp { get; set; }
        public string Docs { get; set; }
        public Dictionary<string, object> Limit { get; set; }

        internal static bool TryParse(JsonElement response, Action<WelcomeInfoResponse> action)
        {
            if (response.TryGetProperty("info", out _) && response.TryGetProperty("version", out _))
            {
                var welcomeInfoResponse = BitmexJsonSerializer.Deserialize<WelcomeInfoResponse>(response);
                action?.Invoke(welcomeInfoResponse);
                return true;
            }
            return false;
        }
    }
}