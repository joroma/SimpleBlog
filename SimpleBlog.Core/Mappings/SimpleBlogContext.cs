using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SimpleBlog.Core.Objects;

namespace SimpleBlog.Core.Mappings
{
    public class SimpleBlogContext : DbContext
    {
        
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasMany(up => up.Tags)
                .WithMany(tag => tag.Posts)
                .Map(mc =>
                {
                    mc.ToTable("PostTagMap");
                    mc.MapLeftKey("PostID");
                    mc.MapRightKey("TagID");
                });

            modelBuilder.Entity<Category>()
                .HasMany(up => up.Posts)
                
                
                ;


            base.OnModelCreating(modelBuilder);

        }
    }
   

}
