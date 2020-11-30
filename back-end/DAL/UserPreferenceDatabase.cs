using System;
using System.Collections.Generic;
using System.Linq;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class UserPreferencesDataBase
    {
        private readonly BackEndContext _dbContext;

        public UserPreferencesDataBase(BackEndContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<UserPreference>> GetUserPreferences()
        {
            var list = new List<UserPreference>();
            var result = await _dbContext.UserPreferences.ToListAsync();
            if (result.Count() <= 0)
            {
                return list;
            }
            list = result;
            return list;
        }

        public bool CreateUserPreference(UserPreference UserPreference)
        {
            var created = _dbContext.UserPreferences.Add(UserPreference);
            if (created != null)
            {
                _dbContext.SaveChanges();
            }

            return created != null;
        }

    }
}
