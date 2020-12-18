using System;
using System.Collections.Generic;
using System.Linq;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public class CommentsDataBase
    {
        private readonly BackEndContext _dbContext;

        public CommentsDataBase(BackEndContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Comment>> GetComments()
        {
            var list = new List<Comment>();
            var result = await _dbContext.Comments.ToListAsync();
            if (result.Count() <= 0)
            {
                return list;
            }
            list = result;
            return list;
        }

        public Comment CreateComment(Comment comment)
        {
            var created = _dbContext.Comments.Add(comment);
            if (created != null)
            {
                _dbContext.SaveChanges();
            }

            return comment;
        }

        public Comment UpdateComment(Comment comment)
        {
            var updated = _dbContext.Comments.Update(comment);
            if (updated != null)
            {
                _dbContext.SaveChanges();
            }
            return comment;
        }

        public bool RemoveComment(Comment comment)
        {
            var removed = _dbContext.Comments.Remove(comment);
            if (removed != null)
            {
                _dbContext.SaveChanges();
            }
            return removed != null;
        }

    }
}
