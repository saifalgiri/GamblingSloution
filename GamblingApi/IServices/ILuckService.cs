using GamblingApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamblingApi.IServices
{
    public interface ILuckService
    {
        Task<Status> Play(int point);
        int SumOfDice();
    }
}
