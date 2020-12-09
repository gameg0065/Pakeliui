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

        // [HttpGet("AllPreferences")]
        // public async Task<ActionResult<List<Feedback>>> Get()
        // {
        //     var preferencesDatabase = new FeedbackDataBase(_dbContext);
        //     var items = await preferencesDatabase.GetPreferences();

        //     if (items.Count < 1)
        //     {
        //         return NotFound();
        //     }

        //     return items;
        // }
        // [HttpPost]
        // public bool Create(Feedback model)
        // {

        //     var preferencesDatabase = new FeedbackDataBase(_dbContext);
        //     var items = preferencesDatabase.CreatePreference(model);

        //     return items;
        // }
    }
}