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
    public class CarController : ControllerBase
    {

        private readonly ILogger<CarController> _logger;
        private readonly BackEndContext _dbContext;
        private readonly IConfiguration Configuration;

        public CarController(ILogger<CarController> logger, IConfiguration configuration, BackEndContext dbContext)
        {
            _logger = logger;
            Configuration = configuration;
            _dbContext = dbContext;
        }

        [HttpGet("AllCars")]
        public async Task<ActionResult<List<Car>>> Get()
        {
            var carsDatabase = new CarsDataBase(_dbContext);
            var items = await carsDatabase.GetCars();

            if (items.Count < 1)
            {
                return NotFound();
            }

            return items;
        }
        [HttpPost]
        public bool Create(Car model)
        {
            var carsDatabase = new CarsDataBase(_dbContext);
            var item = carsDatabase.CreateCar(model);

            return item;
        }

        [HttpPut]
        public bool Update(Car model)
        {
            var carsDatabase = new CarsDataBase(_dbContext);
            var item = carsDatabase.UpdateCar(model);

            return item;
        }
        [HttpDelete]
        public bool Detete(Car model)
        {
            var carsDatabase = new CarsDataBase(_dbContext);
            var item = carsDatabase.RemoveCar(model);

            return item;
        }
    }
}