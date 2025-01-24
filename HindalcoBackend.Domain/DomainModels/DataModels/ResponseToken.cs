using HindalcoBackend.Business;

namespace HindalcoBackend.Domain
{
    public class ResponseToken
    {
        public string? JwtToken { get; set; }
        public string? RefreshToken { get; set; }
    }
}
