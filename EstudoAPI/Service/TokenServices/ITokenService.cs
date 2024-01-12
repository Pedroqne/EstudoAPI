using EstudoAPI.Models;

namespace EstudoAPI.Service.JwtService
{
    public interface ITokenService
    {
        string GetToken(string key, string issuer, string audience, UserModel user);
    }
}
