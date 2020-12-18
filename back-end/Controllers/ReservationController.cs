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
    public class ReservationController : ControllerBase
    {

        private readonly ILogger<ReservationController> _logger;
        private readonly BackEndContext _dbContext;
        private readonly IConfiguration Configuration;

        public ReservationController(ILogger<ReservationController> logger, IConfiguration configuration, BackEndContext dbContext)
        {
            _logger = logger;
            Configuration = configuration;
            _dbContext = dbContext;
        }

        [HttpGet("AllReservations")]
        public async Task<ActionResult<List<Reservation>>> Get()
        {
            var reservationsDatabase = new ReservationsDataBase(_dbContext);
            var items = await reservationsDatabase.GetReservations();

            if (items.Count < 1)
            {
                return NotFound();
            }

            return items;
        }
        [HttpPost]
        public Reservation Create(Reservation model)
        {

            var reservationsDatabase = new ReservationsDataBase(_dbContext);
            var item = reservationsDatabase.CreateReservation(model);

            return item;
        }
        [HttpPut]
        public Reservation Update(Reservation model)
        {
            var reservationsDatabase = new ReservationsDataBase(_dbContext);
            var item = reservationsDatabase.UpdateReservation(model);

            return item;
        }
        [HttpDelete]
        public bool Detete(Reservation model)
        {
            var reservationsDatabase = new ReservationsDataBase(_dbContext);
            var item = reservationsDatabase.RemoveReservation(model);

            return item;
        }
    }
}