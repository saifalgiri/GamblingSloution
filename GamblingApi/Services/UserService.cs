using GamblingApi.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GamblingApi.IServices
{
    public class UserService : IUserService
    {
        private readonly DbContextModel dbContext;
        private readonly ILogger<UserService> logger;
        public UserService(DbContextModel dbContext, ILogger<UserService> logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }
        public async Task AddUser(UserModel newUser)
        {
            var user = new UserModel { Name = newUser?.Name};
            try
            {
                if (user != null || !dbContext.Users.Any(x => x.Name == user.Name))
                {
                    var newAccount = new AccountModel { Balance = newUser.Account.Balance };
                    user.Account = newAccount;
                    await dbContext.Users.AddAsync(user);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
        }
    }
}
