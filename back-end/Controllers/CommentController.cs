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
    public class CommentController : ControllerBase
    {

        private readonly ILogger<CommentController> _logger;
        private readonly BackEndContext _dbContext;
        private readonly IConfiguration Configuration;

        public CommentController(ILogger<CommentController> logger, IConfiguration configuration, BackEndContext dbContext)
        {
            _logger = logger;
            Configuration = configuration;
            _dbContext = dbContext;
        }

        [HttpGet("AllComments")]
        public async Task<ActionResult<List<Comment>>> Get()
        {
            var commentsDatabase = new CommentsDataBase(_dbContext);
            var items = await commentsDatabase.GetComments();

            if (items.Count < 1)
            {
                return NotFound();
            }

            return items;
        }
        [HttpPost]
        public Comment Create(Comment model)
        {

            var commentsDatabase = new CommentsDataBase(_dbContext);
            var item = commentsDatabase.CreateComment(model);

            return item;
        }

        [HttpPut]
        public Comment Update(Comment model)
        {
            var commentsDatabase = new CommentsDataBase(_dbContext);
            var item = commentsDatabase.UpdateComment(model);

            return item;
        }
        [HttpDelete]
        public bool Detete(Comment model)
        {
            var commentsDatabase = new CommentsDataBase(_dbContext);
            var item = commentsDatabase.RemoveComment(model);

            return item;
        }
    }
}