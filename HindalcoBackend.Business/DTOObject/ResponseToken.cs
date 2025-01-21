using HindalcoBackend.Business;

namespace HindalcoBackend.Business
{
    public class ResponseToken
    {
        public string? JwtToken { get; set; }
        public string? RefreshToken { get; set; }
    }
}
