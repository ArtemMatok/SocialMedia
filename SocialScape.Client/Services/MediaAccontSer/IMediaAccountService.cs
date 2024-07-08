using SocialScape.Shared.Models.MediaAccountFold;
using SocialScape.Shared.Result.MediaAccountRes;

namespace SocialScape.Client.Services.MediaAccontSer
{
    public interface IMediaAccountService
    {
        Task<MediaAccountResult> CreateMediaAccount(MediaAccount mediaAccount);
    }
}
