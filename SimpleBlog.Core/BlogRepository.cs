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

        public IList<Post> PostsForCategory(string categorySlug, int pageNo, int pageSize)
        {
            var posts = db.Posts
                .Where(p => p.Published && p.Category.UrlSlug.Equals(categorySlug))
                .OrderByDescending(p => p.PostedOn)
                .Skip(pageNo * pageSize)
                .Take(pageSize)
                .Include(p => p.Category)
                .ToList();
            var postIds = posts.Select(p => p.ID).ToList();
            return db.Posts
                .Where(p => postIds.Contains(p.ID))
                .OrderByDescending(p => p.PostedOn)
                .Include(p => p.Tags)
                .ToList();

        }

        public int TotalPostsForCategory(string categorySlug)
        {
            return db.Posts.Where(p => p.Published && p.Category.UrlSlug.Equals(categorySlug))
                .Count();
        }

        public Category Category(string categorySlug)
        {
            return db.Categories.FirstOrDefault(t => t.UrlSlug.Equals(categorySlug));
        }

        public IList<Post> PostsForTag(string tagSlug, int pageNo, int pageSize)
        {
            var posts = db.Posts
                .OrderByDescending(p => p.PostedOn)
                .Where(p => p.Published && p.Tags.Any(t => t.UrlSlug.Equals(tagSlug)))
                .Skip(pageNo * pageSize)
                .Take(pageSize)
                .Include(p => p.Category)
                .ToList();

            var postIds = posts.Select(p => p.ID).ToList();

            return db.Posts
                .Where(p => postIds.Contains(p.ID))
                .OrderByDescending(p => p.PostedOn)
                .Include(p => p.Tags)
                .ToList();
        }

        public int TotalPostsForTag(string tagSlug)
        {
            return db.Posts.Where(p => p.Published && p.Tags.Any(t => t.UrlSlug.Equals(tagSlug)))
                .Count();

        }

        public Tag Tag(string tagSlug)
        {
            return db.Tags.FirstOrDefault(t => t.UrlSlug.Equals(tagSlug));
        }

        public IList<Post> PostsForSearch(string search, int pageNo, int pageSize)
        {
            var posts = db.Posts
                .Where(p => p.Published && (p.Title.Contains(search) || p.Category.Name.Equals(search) || p.Tags.Any(t => t.Name.Equals(search))))
                .OrderByDescending(p => p.PostedOn)
                .Skip(pageNo * pageSize)
                .Take(pageSize)
                .Include(p => p.Category)
                .ToList();

            var postIds = posts.Select(p => p.ID).ToList();

            return db.Posts
                .Where(p => postIds.Contains(p.ID))
                .OrderByDescending(p => p.PostedOn)
                .Include(p => p.Tags)
                .ToList();
        }

        public int TotalPostsForSearch(string search)
        {
            return db.Posts.Where(p => p.Published && (p.Title.Contains(search) || p.Category.Name.Equals(search) || p.Tags.Any(t => t.Name.Equals(search))))
                .Count();
        }

    }
}
