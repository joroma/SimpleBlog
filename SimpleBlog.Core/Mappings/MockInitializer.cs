using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using SimpleBlog.Core.Objects;

namespace SimpleBlog.Core.Mappings
{
    public class MockInitializer : DropCreateDatabaseAlways<SimpleBlogContext>
    {
        protected override void Seed(SimpleBlogContext context)
        {
            base.Seed(context);

            var category1 = new Category { ID = 1, Name = "Personal", Description = "Personal", UrlSlug = "Personal" };
            var category2 = new Category { ID = 2, Name = "Tech", Description = "Tech", UrlSlug = "Tech" };

            context.Categories.Add(category1);
            context.Categories.Add(category2);

            var tag1 = new Tag { ID = 1, Name = "tag1", Description = "Tag One", UrlSlug = "Tagone" };
            var tag2 = new Tag { ID = 2, Name = "tag2", Description = "Tag Two", UrlSlug = "Tagtwo" };

            context.Tags.Add(tag1);
            context.Tags.Add(tag1);

            List<Tag> vtags = new List<Tag>();

            vtags.Add(tag1);
            vtags.Add(tag2);

            var post1 = new Post
            {
                ID = 1,
                Category = category1,
                PostedOn = DateTime.UtcNow,
                Modified = DateTime.UtcNow,
                ShortDescription = "Now that there is the Tec-9, a crappy spray gun from South Miami. This gun is advertised as the most popular gun in "
                            + "American crime. Do you believe that shit? It actually says that in the little book that comes with it: the most popular "
                            + "gun in American crime. Like they're actually proud of that shit. " ,
                Title = "First Post",
                UrlSlug = "FirstPost",
                Published = true,
                Description = "Now that there is the Tec-9, a crappy spray gun from South Miami. This gun is advertised as the most popular gun in "
                            + "American crime. Do you believe that shit? It actually says that in the little book that comes with it: the most popular "
                            + "gun in American crime. Like they're actually proud of that shit. " 
                            + System.Environment.NewLine + "Well, the way they make shows is, they make one show. That show's called a pilot. Then "
                            + "they show that show to the people who make shows, and on the strength of that one show they decide if they're going to "
                            + "make more shows. Some pilots get picked and become television programs. Some don't, become nothing. She starred in one "
                            + "of the ones that became nothing.",
                Tags = vtags

            };

            var post2 = new Post
            {
                ID = 2,
                Category = category2,
                PostedOn = DateTime.UtcNow,
                Modified = DateTime.UtcNow,
                ShortDescription = "The path of the righteous man is beset on all sides by the iniquities of the selfish and the tyranny of evil men. "
                            + "Blessed is he who, in the name of charity and good will, shepherds the weak through the valley of darkness, for "
                            + "he is truly his brother's keeper and the finder of lost children. And I will strike down upon thee with great "
                            + "vengeance and furious anger those who would attempt to poison and destroy My brothers. And you will know My name is "
                            + "the Lord when I lay My vengeance upon thee.",
                Title = "Second Post",
                UrlSlug = "SecondPost",
                Published = true,                
                Description = "The path of the righteous man is beset on all sides by the iniquities of the selfish and the tyranny of evil men. "
                            + "Blessed is he who, in the name of charity and good will, shepherds the weak through the valley of darkness, for "
                            + "he is truly his brother's keeper and the finder of lost children. And I will strike down upon thee with great "
                            + "vengeance and furious anger those who would attempt to poison and destroy My brothers. And you will know My name is "
                            + "the Lord when I lay My vengeance upon thee."
                            + System.Environment.NewLine + "You think water moves fast? You should see ice. It moves like it has a mind. Like it knows "
                            + "it killed the world once and got a taste for murder. After the avalanche, it took us a week to climb out. Now, I don't "
                            + "know exactly when we turned on each other, but I know that seven of us survived the slide... and only five made it out. "
                            + "Now we took an oath, that I'm breaking now. We said we'd say it was the snow that killed the other two, but it wasn't. "
                            + "Nature is lethal but it doesn't hold a candle to man.",
                Tags = vtags

            };

            context.Posts.Add(post1);
            context.Posts.Add(post2);



        }
    }
}
