using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Bitmex.NET.Models.Socket.Responses.OperationResponses
{
    public class AuthenticationResponse : OperationResponseBase
    {
        //{"op":"authKeyExpires","success":true,"request":{"op":"authKeyExpires","args":["Pywfl2NBw1I8akGBWR-s8nzJ",8976439215417044,"5d0da8e54eef0418e393f3879ca4f6c7706eefae4bfbab0449b4124756197d3c"]}}
        //public override OperationType Operation => OperationType.authKeyExpires;
        [JsonPropertyName("op")]
        public virtual string? Operation { get; set; }

        [JsonPropertyName("success")]
        public bool? Success { get; set; }

        internal static bool TryParse(JsonElement response, Action<AuthenticationResponse> action)
        {
            if (response.TryGetProperty("request", out var request)
                && request.TryGetProperty("op", out var op)
                && op.GetString() == "authKeyExpires")
            {
                var authenticationResponse = BitmexJsonSerializer.Deserialize<AuthenticationResponse>(response);
                action?.Invoke(authenticationResponse);
                return true;
            }
            return false;
        }
    }
}