using GamblingApi.IServices;
using GamblingApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace GamblingTestProject.Services
{
    [TestClass]
    public class LuckServiceTest
    {
        private readonly ILuckService luckService;
        public LuckServiceTest()
        {
            this.luckService = new Mock<LuckService>().Object;
        }

        [TestMethod]
        public async Task TestRollDiceAsync()
        {
            //act
            var play = await luckService.Play(5);
            //assert 
            Assert.IsTrue(play == Status.WON || play == Status.LOST);
        }
    }
}
