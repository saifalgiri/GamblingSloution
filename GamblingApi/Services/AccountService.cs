using GamblingApi.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace GamblingApi.IServices
{
    public class AccountService : IAccountService
    {
        private readonly DbContextModel dbContext;
        private readonly ILogger<AccountService> logger;
        public AccountService(DbContextModel dbContext, ILogger<AccountService> logger)
        {
            this.dbContext = dbContext;
            this.logger = logger;
        }
        async Task<AccountModel> IAccountService.AddBalance(Guid userId, int newPoints)
        {
            var account = dbContext.Accounts.Where(x => x.UserId == userId).FirstOrDefault();
            try
            {
                if (account == null)
                {
                    await dbContext.Accounts.AddAsync(account);
                    await dbContext.SaveChangesAsync();
                }
                else
                {
                    account.Balance = account.Balance + newPoints;
                    dbContext.Accounts.Update(account);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
            }
            return account;
        }
    }
}
