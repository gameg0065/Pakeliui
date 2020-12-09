using System;
using System.Collections.Generic;
using System.Linq;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class PostDataBase
    {
        private readonly BackEndContext _dbContext;

        public PostDataBase(BackEndContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Post>> GetTravels()
        {
            var list = new List<Post>();
            var result = await _dbContext.Posts.ToListAsync();
            if (result.Count() <= 0)
            {
                return list;
            }
            list = result;
            return list;
        }

        public bool CreateTravel(Post Travel)
        {
            var created = _dbContext.Posts.Add(Travel);
            if (created != null)
            {
                _dbContext.SaveChanges();
            }

            return created != null;
        }

    }
}
