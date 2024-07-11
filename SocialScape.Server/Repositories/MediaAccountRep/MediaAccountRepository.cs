using Microsoft.EntityFrameworkCore;
using SocialScape.Server.Data;
using SocialScape.Shared.Models.MediaAccountFold;

namespace SocialScape.Server.Repositories.MediaAccountRep
{
    public class MediaAccountRepository : IMediaAccountRepository
    {
        private readonly ApplicationDbContext _context;

        public MediaAccountRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(MediaAccount model)
        {
            _context.MediaAccounts.Add(model);
            return Save();
        }

        public bool Delete(MediaAccount model)
        {
            _context.MediaAccounts.Remove(model);
            return Save();
        }

        public async Task<MediaAccount> GetMediaAccountByEmail(string email)
        {
            return await _context.MediaAccounts.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<MediaAccount> GetMediaAccountById(int id)
        {
            return await _context.MediaAccounts.FirstOrDefaultAsync(x => x.MediaAccountId == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(MediaAccount model)
        {
            _context.MediaAccounts.Update(model);
            return Save();
        }
    }
}
