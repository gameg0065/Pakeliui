using System;
using System.Collections.Generic;
using System.Linq;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class CountriesDataBase
    {
        private readonly BackEndContext _dbContext;

        public CountriesDataBase(BackEndContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Country>> GetCountries()
        {
            var list = new List<Country>();
            var result = await _dbContext.Countries.ToListAsync();
            if (result.Count() <= 0)
            {
                return list;
            }
            list = result;
            return list;
        }

        public bool CreateCountry(Country Country)
        {
            var created = _dbContext.Countries.Add(Country);
            if (created != null)
            {
                _dbContext.SaveChanges();
            }

            return created != null;
        }

    }
}
