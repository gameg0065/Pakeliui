using System;
using System.Collections.Generic;
using System.Linq;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class ReservationsDataBase
    {
        private readonly BackEndContext _dbContext;

        public ReservationsDataBase(BackEndContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Reservation>> GetReservations()
        {
            var list = new List<Reservation>();
            var result = await _dbContext.Reservations.ToListAsync();
            if (result.Count() <= 0)
            {
                return list;
            }
            list = result;
            return list;
        }

        public bool CreateReservation(Reservation Reservation)
        {
            var created = _dbContext.Reservations.Add(Reservation);
            if (created != null)
            {
                _dbContext.SaveChanges();
            }

            return created != null;
        }

    }
}
