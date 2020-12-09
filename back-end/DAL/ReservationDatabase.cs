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

        public bool CreateReservation(Reservation reservation)
        {
            var created = _dbContext.Reservations.Add(reservation);
            if (created != null)
            {
                _dbContext.SaveChanges();
            }

            return created != null;
        }

        public bool UpdateReservation(Reservation reservation)
        {
            var updated = _dbContext.Reservations.Update(reservation);
            if (updated != null)
            {
                _dbContext.SaveChanges();
            }
            return updated != null;
        }

        public bool RemoveReservation(Reservation reservation)
        {
            var removed = _dbContext.Reservations.Remove(reservation);
            if (removed != null)
            {
                _dbContext.SaveChanges();
            }
            return removed != null;
        }

    }
}
