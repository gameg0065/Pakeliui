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
    public class FeedbackController : ControllerBase
    {

        private readonly ILogger<FeedbackController> _logger;
        private readonly BackEndContext _dbContext;
        private readonly IConfiguration Configuration;

        public FeedbackController(ILogger<FeedbackController> logger, IConfiguration configuration, BackEndContext dbContext)
        {
            _logger = logger;
            Configuration = configuration;
            _dbContext = dbContext;
        }

        [HttpGet("AllFeedbacks")]
        public async Task<ActionResult<List<Feedback>>> Get()
        {
            var feedbackDatabase = new FeedbackDataBase(_dbContext);
            var items = await feedbackDatabase.GetFeedbacks();

            if (items.Count < 1)
            {
                return NotFound();
            }

            return items;
        }
        [HttpPost]
        public bool Create(Feedback model)
        {

            var feedbackDatabase = new FeedbackDataBase(_dbContext);
            var items = feedbackDatabase.CreateFeedback(model);

            return items;
        }
        [HttpPut]
        public bool Update(Feedback model)
        {
            var feedbackDatabase = new FeedbackDataBase(_dbContext);
            var item = feedbackDatabase.UpdateFeedback(model);

            return item;
        }
        [HttpDelete]
        public bool Detete(Feedback model)
        {
            var feedbackDatabase = new FeedbackDataBase(_dbContext);
            var item = feedbackDatabase.RemoveFeedback(model);

            return item;
        }
    }
}