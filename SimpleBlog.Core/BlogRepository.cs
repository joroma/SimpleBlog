using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using SimpleBlog.Core.Mappings;
using SimpleBlog.Core.Objects;


namespace SimpleBlog.Core
{
    public class BlogRepository : IBlogRepository
    {
        private readonly SimpleBlogContext db = new SimpleBlogContext();
        
        public IList<Post> Posts (int pageNo, int pageSize)
        {
            var posts = db.Posts
                            .Where(p => p.Published)
                            .OrderByDescending(p => p.PostedOn)
                            .Skip(pageNo * pageSize)
                            .Take(pageSize)
                            .Include(p => p.Category)
                            .ToList();
            var PostIDs = posts.Select(p => p.ID).ToList();

            return db.Posts.Where(p => PostIDs.Contains(p.ID))
                            .OrderByDescending(p => p.PostedOn)
                            .Include(p => p.Tags)
                            .ToList();
        }

        public int TotalPosts()
        {
            return db.Posts.Where(p => p.Published).Count();
        }         
    }
}
