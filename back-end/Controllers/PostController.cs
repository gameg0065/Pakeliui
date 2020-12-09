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
    public class PostController : ControllerBase
    {

        private readonly ILogger<PostController> _logger;
        private readonly BackEndContext _dbContext;
        private readonly IConfiguration Configuration;

        public PostController(ILogger<PostController> logger, IConfiguration configuration, BackEndContext dbContext)
        {
            _logger = logger;
            Configuration = configuration;
            _dbContext = dbContext;
        }

        [HttpGet("AllTravels")]
        public async Task<ActionResult<List<Post>>> Get()
        {
            var travelsDatabase = new PostDataBase(_dbContext);
            var items = await travelsDatabase.GetTravels();

            if (items.Count < 1)
            {
                return NotFound();
            }

            return items;
        }
        [HttpPost]
        public bool Create(Post model)
        {

            var travelsDatabase = new PostDataBase(_dbContext);
            var items = travelsDatabase.CreateTravel(model);

            return items;
        }
    }
}