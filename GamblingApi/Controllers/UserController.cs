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
    public class UserController : ControllerBase
    {
        // GET: api/<UserController>
        private readonly IUserService userService;
        private readonly DbContextModel dbContext;
        public UserController(IUserService userService,
            DbContextModel dbContext)
        {
            this.userService = userService;
            this.dbContext = dbContext;
        }

        [HttpGet("ViewUsers")]
        public async Task<List<UserModel>> Get()
        {
            return  await dbContext.Users.Include(a => a.Account).ToListAsync();
        }

        // POST api/<UserController>
        [HttpPost("AddUser")]
        public async Task<ActionResult> Post([FromBody] UserModel user)
        {
            if (user == null || dbContext.Users.Any(x => x.Name == user.Name))
                return BadRequest();
            await userService.AddUser(user);
            return Ok("User added successfully.");
        }
    }
}
