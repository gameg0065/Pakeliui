using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using BackEnd.Models;
using BackEnd.DAL;

namespace BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;
        private readonly BackEndContext _dbContext;
        private readonly IConfiguration Configuration;

        public UserController(ILogger<UserController> logger, IConfiguration configuration, BackEndContext dbContext)
        {
            _logger = logger;
            Configuration = configuration;
            _dbContext = dbContext;
        }

        [HttpGet("AllUsers")]
        public async Task<ActionResult<List<User>>> Get()
        {
            var usersDataBase = new UsersDataBase(_dbContext);
            var items = await usersDataBase.GetUsers();

            if (items.Count < 1)
            {
                return NotFound();
            }

            return items;
        }

        [HttpGet("UserById")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var usersDataBase = new UsersDataBase(_dbContext);
            var items = await usersDataBase.GetUserById(id);

            return items;
        }

        [HttpGet("GetUserByEmailAndPass")]
        public async Task<ActionResult<User>> GetUserByEmailAndPass(string email, string password)
        {
            var usersDataBase = new UsersDataBase(_dbContext);
            var items = await usersDataBase.GetUserByEmailAndPass(email, password);

            return items;
        }
        [HttpPost]
        public User Create(User model)
        {

            var usersDataBase = new UsersDataBase(_dbContext);
            var items = usersDataBase.CreateUser(model);

            return items;
        }
        [HttpPut]
        public User Update(User model)
        {
            var usersDataBase = new UsersDataBase(_dbContext);
            var item = usersDataBase.UpdateUser(model);

            return item;
        }
        [HttpDelete]
        public bool Detete(User model)
        {
            var usersDataBase = new UsersDataBase(_dbContext);
            var item = usersDataBase.RemoveUser(model);

            return item;
        }
    }
}