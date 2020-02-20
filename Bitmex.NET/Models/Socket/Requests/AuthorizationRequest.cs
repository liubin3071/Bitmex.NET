namespace Bitmex.NET.Models.Socket
{
    public sealed class AuthorizationRequest : OperationRequest
    {
        public AuthorizationRequest(string apiKey, long expiresTime, string sign) : base(OperationType.authKeyExpires, apiKey, expiresTime, sign)
        {
        }
    }
}