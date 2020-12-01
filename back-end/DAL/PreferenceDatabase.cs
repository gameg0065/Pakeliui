using System;
using System.Collections.Generic;
using System.Linq;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class PreferencesDataBase
    {
        private readonly BackEndContext _dbContext;

        public PreferencesDataBase(BackEndContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Preference>> GetPreferences()
        {
            var list = new List<Preference>();
            var result = await _dbContext.Preferences.ToListAsync();
            if (result.Count() <= 0)
            {
                return list;
            }
            list = result;
            return list;
        }

        public bool CreatePreference(Preference Preference)
        {
            var created = _dbContext.Preferences.Add(Preference);
            if (created != null)
            {
                _dbContext.SaveChanges();
            }

            return created != null;
        }

    }
}
