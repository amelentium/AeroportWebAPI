using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Token
{
    public class AeroTokenOptions
    {
        public const string ISSUER = "AeroServer"; // издатель токена
        public const string AUDIENCE = "AeroClient"; // потребитель токена
        const string KEY = "aerosecrettoken_ultrasecret";   // ключ для шифрации
        public const int LIFETIME = 300; // время жизни токена - 1 минута
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }

    }
}
