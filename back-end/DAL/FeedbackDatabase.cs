using System;
using System.Collections.Generic;
using System.Linq;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class FeedbackDataBase
    {
        private readonly BackEndContext _dbContext;

        public FeedbackDataBase(BackEndContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Feedback>> GetFeedbacks()
        {
            var list = new List<Feedback>();
            var result = await _dbContext.Feedbacks.ToListAsync();
            if (result.Count() <= 0)
            {
                return list;
            }
            list = result;
            return list;
        }

        public bool CreateFeedback(Feedback feedback)
        {
            var created = _dbContext.Feedbacks.Add(feedback);
            if (created != null)
            {
                _dbContext.SaveChanges();
            }

            return created != null;
        }

        public bool UpdateFeedback(Feedback feedback)
        {
            var updated = _dbContext.Feedbacks.Update(feedback);
            if (updated != null)
            {
                _dbContext.SaveChanges();
            }
            return updated != null;
        }

        public bool RemoveFeedback(Feedback feedback)
        {
            var removed = _dbContext.Feedbacks.Remove(feedback);
            if (removed != null)
            {
                _dbContext.SaveChanges();
            }
            return removed != null;
        }

    }
}
