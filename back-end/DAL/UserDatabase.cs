using System;
using System.Collections.Generic;
using System.Linq;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class UsersDataBase
    {
        private readonly BackEndContext _dbContext;

        public UsersDataBase(BackEndContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<User>> GetUsers()
        {
            var list = new List<User>();
            var result = await _dbContext.Users.Include(x => x.Car).Include(x => x.Posts).Include(x => x.Feedbacks).ToListAsync();
            if (result.Count() <= 0)
            {
                return list;
            }
            list = result;
            return list;
        }

        public bool CreateUser(User user)
        {
            var created = _dbContext.Users.Add(user);
            if (created != null)
            {
                _dbContext.SaveChanges();
            }

            return created != null;
        }

        public bool UpdateUser(User user)
        {
            var updated = _dbContext.Users.Update(user);
            if (updated != null)
            {
                _dbContext.SaveChanges();
            }
            return updated != null;
        }

        public bool RemoveUser(User user)
        {
            var removed = _dbContext.Users.Remove(user);
            if (removed != null)
            {
                _dbContext.SaveChanges();
            }
            return removed != null;
        }

    }
}
