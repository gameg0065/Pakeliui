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

        public async Task<List<Post>> GetPosts()
        {
            var list = new List<Post>();
            var result = await _dbContext.Posts.Include(x => x.Comments).Include(x => x.Passengers).Include(x => x.User).ToListAsync();
            if (result.Count() <= 0)
            {
                return list;
            }
            list = result;
            return list;
        }

        public async Task<List<Post>> GetPostsByPassengerId(int id)
        {
            var list = new List<Post>();
            var result = await _dbContext.Posts.Include(x => x.Comments).Include(x => x.Passengers).Include(x => x.User).Where(x => x.Passengers.Any(y => y.PassengerId == id)).ToListAsync();
            if (result.Count() <= 0)
            {
                return list;
            }
            list = result;
            return list;
        }

        public async Task<Post> GetPost(int id)
        {
            return await _dbContext.Posts.Include(x => x.Comments).Include(x => x.Passengers).Include(x => x.User).Where(x => x.ID == id).FirstOrDefaultAsync();
        }

        public Post CreatePost(Post post)
        {
            var created = _dbContext.Posts.Add(post);
            if (created != null)
            {
                _dbContext.SaveChanges();
            }

            return post;
        }
        public bool UpdatePost(Post post)
        {
            var updated = _dbContext.Posts.Update(post);
            if (updated != null)
            {
                _dbContext.SaveChanges();
            }
            return updated != null;
        }

        public bool RemovePost(Post post)
        {
            var removed = _dbContext.Posts.Remove(post);
            if (removed != null)
            {
                _dbContext.SaveChanges();
            }
            return removed != null;
        }

    }
}
