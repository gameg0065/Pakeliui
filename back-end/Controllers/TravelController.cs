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
    public class TravelController : ControllerBase
    {

        private readonly ILogger<TravelController> _logger;
        private readonly BackEndContext _dbContext;
        private readonly IConfiguration Configuration;

        public TravelController(ILogger<TravelController> logger, IConfiguration configuration, BackEndContext dbContext)
        {
            _logger = logger;
            Configuration = configuration;
            _dbContext = dbContext;
        }

        [HttpGet("AllTravels")]
        public async Task<ActionResult<List<Travel>>> Get()
        {
            var travelsDatabase = new TravelsDataBase(_dbContext);
            var items = await travelsDatabase.GetTravels();

            if (items.Count < 1)
            {
                return NotFound();
            }

            return items;
        }
        [HttpPost]
        public bool Create(Travel model)
        {

            var travelsDatabase = new TravelsDataBase(_dbContext);
            var items = travelsDatabase.CreateTravel(model);

            return items;
        }
    }
}