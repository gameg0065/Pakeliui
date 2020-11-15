using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
// using BackEnd.Contracts;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class CodeFirstDataBase
    {
        private readonly BackEndContext _context;

        // public async Task<List<Car>> GetCars()
        // {
        //     var list = new List<Car>();
        //     using (var db = new BackEndContext())
        //     {
        //         var result = await db.Cars.ToListAsync();
        //         if (result.Count() <= 0)
        //         {
        //             return list;
        //         }
        //         list = result;
        //     }
        //     return list;
        // }
        public async Task<List<Car>> GetCars()
        {
            var list = new List<Car>();
            var result = await _context.Cars.ToListAsync();
            if (result.Count() <= 0)
            {
                return list;
            }
            list = result;
            return list;
        }

    }
}
