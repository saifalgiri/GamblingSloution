using GamblingApi.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace GamblingApi.IServices
{
    public class LuckService : ILuckService
    {
        public async Task<Status> Play(int point)
        {
            Status status = Status.CONTINUE;
            while (status == Status.CONTINUE)
            {
                int sum = SumOfDice();
                if (sum == point || sum == (int)DiceType.SEVEN || sum == (int)DiceType.ELEVEN)
                    status = Status.WON;
                if (sum == (int)DiceType.BOX_CARS || sum == (int)DiceType.SNAKE_EYES || sum == (int)DiceType.TREY)
                    status = Status.LOST;
            }
            return status;
        }

        public int SumOfDice()
        {
            var randomNumber = new Random();
            int dice1 = randomNumber.Next(0, 9);
            int dice2 = randomNumber.Next(0, 9);

            return dice1 + dice2;
        }
    }
}
