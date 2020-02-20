using System;

namespace Bitmex.NET.Models.Socket.Responses.RawResponses
{
    public class PongResponse
    {
        private const string Pong = "pong";
        public string Message => Pong;

        internal static bool TryParse(string response, Action<PongResponse> action)
        {
            if (response == "pong")
            {
                var pongResponse = new PongResponse();
                action?.Invoke(pongResponse);
                return true;
            }
            return false;
        }
    }
}