using GamblingApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamblingApi.IServices
{
    public interface IAccountService
    {
        Task<AccountModel> AddBalance(Guid userId,  int points);
    }
}
