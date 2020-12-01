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
    public class CountryController : ControllerBase
    {

        private readonly ILogger<CountryController> _logger;
        private readonly BackEndContext _dbContext;
        private readonly IConfiguration Configuration;

        public CountryController(ILogger<CountryController> logger, IConfiguration configuration, BackEndContext dbContext)
        {
            _logger = logger;
            Configuration = configuration;
            _dbContext = dbContext;
        }

        [HttpGet("AllCountries")]
        public async Task<ActionResult<List<Country>>> Get()
        {
            var countriesDatabase = new CountriesDataBase(_dbContext);
            var items = await countriesDatabase.GetCountries();

            if (items.Count < 1)
            {
                return NotFound();
            }

            return items;
        }
        [HttpPost]
        public bool Create(Country model)
        {

            var countriesDatabase = new CountriesDataBase(_dbContext);
            var items = countriesDatabase.CreateCountry(model);

            return items;
        }
    }
}