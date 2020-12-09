using System.Collections.Generic;
using System.Linq;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class CarsDataBase
    {
        private readonly BackEndContext _dbContext;

        public CarsDataBase(BackEndContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Car>> GetCars()
        {
            var list = new List<Car>();
            var result = await _dbContext.Cars.ToListAsync();
            if (result.Count() <= 0)
            {
                return list;
            }
            list = result;
            return list;
        }

        public bool CreateCar(Car car)
        {
            var created = _dbContext.Cars.Add(car);
            if (created != null)
            {
                _dbContext.SaveChanges();
            }

            return created != null;
        }

        public bool UpdateCar(Car car)
        {
            var updated = _dbContext.Cars.Update(car);
            if (updated != null)
            {
                _dbContext.SaveChanges();
            }
            return updated != null;
        }

        public bool RemoveCar(Car car)
        {
            var removed = _dbContext.Cars.Remove(car);
            if (removed != null)
            {
                _dbContext.SaveChanges();
            }
            return removed != null;
        }
    }
}
