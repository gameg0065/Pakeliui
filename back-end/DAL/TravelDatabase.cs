using System;
using System.Collections.Generic;
using System.Linq;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class TravelsDataBase
    {
        private readonly BackEndContext _dbContext;

        public TravelsDataBase(BackEndContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Travel>> GetTravels()
        {
            var list = new List<Travel>();
            var result = await _dbContext.Travels.ToListAsync();
            if (result.Count() <= 0)
            {
                return list;
            }
            list = result;
            return list;
        }

        public bool CreateTravel(Travel Travel)
        {
            var created = _dbContext.Travels.Add(Travel);
            if (created != null)
            {
                _dbContext.SaveChanges();
            }

            return created != null;
        }

    }
}
