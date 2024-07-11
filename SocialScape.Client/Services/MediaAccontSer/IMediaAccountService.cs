using SocialScape.Shared.Models.MediaAccountFold;
using SocialScape.Shared.Result.MediaAccountRes;

namespace SocialScape.Client.Services.MediaAccontSer
{
    public interface IMediaAccountService
    {
        Task<(MediaAccount? mediaAccount, bool Successfull)> GetMediaAccountByEmail(string email);
        Task<bool> UpdateMediaAccount(int id, MediaAccount mediaAccountUpdated);
    }
}
