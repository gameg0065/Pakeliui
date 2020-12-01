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
    public class UserPreferenceController : ControllerBase
    {

        private readonly ILogger<UserPreferenceController> _logger;
        private readonly BackEndContext _dbContext;
        private readonly IConfiguration Configuration;

        public UserPreferenceController(ILogger<UserPreferenceController> logger, IConfiguration configuration, BackEndContext dbContext)
        {
            _logger = logger;
            Configuration = configuration;
            _dbContext = dbContext;
        }

        [HttpGet("AllUserPreferences")]
        public async Task<ActionResult<List<UserPreference>>> Get()
        {
            var userPreferencesDatabase = new UserPreferencesDataBase(_dbContext);
            var items = await userPreferencesDatabase.GetUserPreferences();

            if (items.Count < 1)
            {
                return NotFound();
            }

            return items;
        }
        [HttpPost]
        public bool Create(UserPreference model)
        {

            var userPreferencesDatabase = new UserPreferencesDataBase(_dbContext);
            var items = userPreferencesDatabase.CreateUserPreference(model);

            return items;
        }
    }
}