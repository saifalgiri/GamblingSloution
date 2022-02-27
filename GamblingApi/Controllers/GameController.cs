using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamblingApi.IServices;
using GamblingApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GamblingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        // GET: api/<HomeController>
        private readonly IAccountService accountService;
        private readonly IOrderService orderService;
        private readonly ILuckService luckService;
        private readonly IUserService userService;
        private readonly DbContextModel dbContext;
        public GameController(
            IAccountService accountService,
            IOrderService orderService,
            ILuckService luckService,
            IUserService userService,
            DbContextModel dbContext)
        {
            this.accountService = accountService;
            this.orderService = orderService;
            this.luckService = luckService;
            this.userService = userService;
            this.dbContext = dbContext;
        }

        [HttpGet("Transactions/UserId")]
        public async Task<ActionResult> Get(string id)
        {
            return Ok(await dbContext.Users.Include(
                o => o.Orders.OrderByDescending( d => d.CreatedAt)).Where(u => u.UserId.ToString() == id)
                .FirstOrDefaultAsync());
        }

        // POST api/<HomeController>
        [HttpPost("Play")]
        public async Task<ActionResult> Play([FromBody] OrderModel order)
        {
            if (order == null)
                return BadRequest();

            var account = dbContext.Accounts.Where(x => x.UserId == order.UserId).FirstOrDefault();
            if (account == null) return BadRequest("User is not exist!");
            //-play
            var play = await luckService.Play(order.BetTimes);

            //-if lost,update points and balance
            if (play == Status.LOST)
            {
                //update balance in user account
                await accountService.AddBalance(order.UserId, -order.Points);
                //add order record for history tracking
                order.Status = play;
                order.Points = -order.Points;
                await orderService.PlaceOrder(order);
                return Ok(new { account = account.Balance, status = "LOST", points = order.Points });
            }

            //-if won, update points and balance
            order.Points = play == Status.WON ? order.Points * 9 : 0;

            if(play == Status.WON)
            {
                //update balance in user account
                await accountService.AddBalance(order.UserId, order.Points);
                order.Status = play;
                //add order record for history tracking
                await orderService.PlaceOrder(order);
            }

            return Ok(new { account = account.Balance, status = "WON", points = "+"+order.Points });
        }
    }
}
