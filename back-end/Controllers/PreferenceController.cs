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
    public class PreferenceController : ControllerBase
    {

        private readonly ILogger<PreferenceController> _logger;
        private readonly BackEndContext _dbContext;
        private readonly IConfiguration Configuration;

        public PreferenceController(ILogger<PreferenceController> logger, IConfiguration configuration, BackEndContext dbContext)
        {
            _logger = logger;
            Configuration = configuration;
            _dbContext = dbContext;
        }

        [HttpGet("AllPreferences")]
        public async Task<ActionResult<List<Preference>>> Get()
        {
            var preferencesDatabase = new PreferencesDataBase(_dbContext);
            var items = await preferencesDatabase.GetPreferences();

            if (items.Count < 1)
            {
                return NotFound();
            }

            return items;
        }
        [HttpPost]
        public bool Create(Preference model)
        {

            var preferencesDatabase = new PreferencesDataBase(_dbContext);
            var items = preferencesDatabase.CreatePreference(model);

            return items;
        }
    }
}