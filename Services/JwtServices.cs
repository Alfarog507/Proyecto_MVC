

namespace MVCCRUD2.Services
{
    public class JwtServices
    {
        public string SecretKey { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
