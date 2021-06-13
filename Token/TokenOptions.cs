using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AeroportWebApi.Token
{
    public class AeroTokenOptions
    {
        public const string ISSUER = "AeroServer";
        public const string AUDIENCE = "AeroClient";
        const string KEY = "aerosecrettoken_ultrasecret";
        public const int LIFETIME = 300;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }

    }
}
