using System.Text;

namespace Parviz.JwtApp.Back.Infrastucture.Tools
{
    public class JwtTokenDefaults
    {
        /*
         ValidIssuer = "http://localhost",
        ValidAudience = "http://localhost",
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("pervizpervizperviz1_")),
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true, // Token zamanini yoxlayir ki, vaxti kecib ya nece
        ClockSkew = TimeSpan.Zero, //server ile klient arasinda gecikmeni sifira endirir
         */

        public const string ValidIssuer = "http://localhost";
        public const string ValidAudience = "http://localhost";
        public const string SigningKey = "admin";
        public const int ExpireTime = 5;
    }
}
