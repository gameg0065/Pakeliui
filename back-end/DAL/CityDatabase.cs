using System;
using System.Collections.Generic;
using System.Linq;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class CitiesDataBase
    {
        private readonly BackEndContext _dbContext;

        public CitiesDataBase(BackEndContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<City>> GetCities()
        {
            var list = new List<City>();
            var result = await _dbContext.Cities.ToListAsync();
            if (result.Count() <= 0)
            {
                return list;
            }
            list = result;
            return list;
        }

        public bool CreateCity(City City)
        {
            var created = _dbContext.Cities.Add(City);
            if (created != null)
            {
                _dbContext.SaveChanges();
            }

            return created != null;
        }

    }
}
