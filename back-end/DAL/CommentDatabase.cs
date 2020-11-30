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

        public bool CreateComment(Comment Comment)
        {
            var created = _dbContext.Comments.Add(Comment);
            if (created != null)
            {
                _dbContext.SaveChanges();
            }

            return created != null;
        }

    }
}
