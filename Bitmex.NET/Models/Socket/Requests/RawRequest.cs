namespace Bitmex.NET.Models.Socket
{
    internal sealed class RawRequest : SocketRequest
    {
        private readonly string _rawText;

        public RawRequest(string rawText)
        {
            _rawText = rawText;
        }

        public override string GetContent()
        {
            return _rawText;
        }
    }
}