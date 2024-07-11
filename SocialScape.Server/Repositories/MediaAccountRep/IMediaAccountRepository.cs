using SocialScape.Shared.Models.MediaAccountFold;

namespace SocialScape.Server.Repositories.MediaAccountRep
{
    public interface IMediaAccountRepository:IRepository<MediaAccount>
    {
        Task<MediaAccount> GetMediaAccountByEmail(string email);

        Task<MediaAccount> GetMediaAccountById(int id);
    }
}
