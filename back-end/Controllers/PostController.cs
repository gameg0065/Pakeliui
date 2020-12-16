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

        [HttpGet("AllPosts")]
        public async Task<ActionResult<List<Post>>> Get()
        {
            var postsDatabase = new PostDataBase(_dbContext);
            var items = await postsDatabase.GetPosts();

            if (items.Count < 1)
            {
                return NotFound();
            }

            return items;
        }
        [HttpGet]
        public async Task<ActionResult<Post>> GetById(int id)
        {
            var postsDatabase = new PostDataBase(_dbContext);
            var item = await postsDatabase.GetPost(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }
        [HttpGet("GetPostsByPassengerId")]
        public async Task<ActionResult<List<Post>>> GetByPassengerId(int id)
        {
            var postsDatabase = new PostDataBase(_dbContext);
            var items = await postsDatabase.GetPostsByPassengerId(id);

            if (items.Count < 1)
            {
                return NotFound();
            }

            return items;
        }
        [HttpPost]
        public bool Create(Post model)
        {

            var postsDatabase = new PostDataBase(_dbContext);
            var items = postsDatabase.CreatePost(model);

            return items;
        }
        [HttpPut]
        public bool Update(Post model)
        {
            var postsDatabase = new PostDataBase(_dbContext);
            var item = postsDatabase.UpdatePost(model);

            return item;
        }
        [HttpDelete]
        public bool Detete(Post model)
        {
            var postsDatabase = new PostDataBase(_dbContext);
            var item = postsDatabase.RemovePost(model);

            return item;
        }
    }
}