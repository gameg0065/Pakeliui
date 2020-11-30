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
    public class CityController : ControllerBase
    {

        private readonly ILogger<CityController> _logger;
        private readonly BackEndContext _dbContext;
        private readonly IConfiguration Configuration;

        public CityController(ILogger<CityController> logger, IConfiguration configuration, BackEndContext dbContext)
        {
            _logger = logger;
            Configuration = configuration;
            _dbContext = dbContext;
        }

        [HttpGet("AllCities")]
        public async Task<ActionResult<List<City>>> Get()
        {
            var citiesDatabase = new CitiesDataBase(_dbContext);
            var items = await citiesDatabase.GetCities();

            if (items.Count < 1)
            {
                return NotFound();
            }

            return items;
        }
        [HttpPost]
        public bool Create(City model)
        {

            var citiesDatabase = new CitiesDataBase(_dbContext);
            var items = citiesDatabase.CreateCity(model);

            return items;
        }
    }
}