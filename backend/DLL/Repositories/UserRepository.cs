using Data.Data;
using Data.Interfaces;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<AppUser?> GetUserByUserName(string userName)
        {
            return await _context.Users
                .Include(x=>x.Posts)
                .Include(x=>x.LikedPosts)
                .Include(x=>x.Saves)
                .FirstOrDefaultAsync(x=>x.UserName == userName);
        }
    }
}
