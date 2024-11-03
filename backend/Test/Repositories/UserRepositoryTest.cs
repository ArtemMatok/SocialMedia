using Data.Data;
using Data.Models;
using Data.Repositories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Repositories
{
    public class UserRepositoryTest
    {
        private async Task<ApplicationDbContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            var databaseContext = new ApplicationDbContext(options);

            databaseContext.Database.EnsureCreated();
            if(await databaseContext.Users.CountAsync() <= 0)
            {
                for(int i = 0; i<10; i++)
                {
                    databaseContext.Users.Add(new AppUser()
                    {
                        Name = "Test",
                        UserName = "Test",
                        Bio = "Test test",
                        Posts = new List<Post>(),
                        LikedPosts = new List<Post>(),
                        Saves = new List<Save>()
                    });
                }
                await databaseContext.SaveChangesAsync();
            }
            return databaseContext;
        }

        [Fact]
        public async Task UserRepository_GetUserByUserName_ReturnUser()
        {
            //Arrange
            var userName = "Test";
            var dbContext = await GetDatabaseContext();
            var userRepository = new UserRepository(dbContext);

            //Act
            var result = await userRepository.GetUserByUserName(userName);

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<AppUser>();
        }
    }
}
