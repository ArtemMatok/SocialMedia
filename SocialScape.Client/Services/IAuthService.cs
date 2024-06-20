using SocialScape.Shared.Models.AccountAuthntication;
using SocialScape.Shared.Result;

namespace SocialScape.Client.Services
{
    public interface IAuthService
    {
        Task<RegisterResult> Register(RegisterModel registerModel);
        Task<LoginResult> Login(LoginModel loginModel);
        Task Logout();
    }
}
