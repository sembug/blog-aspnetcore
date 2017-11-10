using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Blog.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BlogContext(
                serviceProvider.GetRequiredService<DbContextOptions<BlogContext>>()))
            {
                if (context.Categories.Any())
                {
                    return;   // DB has been seeded
                }

                context.Categories.Add(
                     new Category
                     {
                         Title = "Sports"
                     }
                );

                context.Tags.Add(
                     new Tag
                     {
                         Title = "Idea"
                     }
                );

                context.SaveChanges();

                var category = context.Categories.First();                          

                context.Posts.Add(
                     new Post
                     {
                        Title  = "View Components",
                        Slug = "post",
                        Author = "Roberto",
                        Publish = DateTime.Now,
                        Body  = @"New to ASP.NET Core MVC, view components are similar to partial views, but they are much more powerful. View components don’t use model binding, and only depend on the data you provide when calling into it. A view component:+
Renders a chunk rather than a whole response
Includes the same separation-of-concerns and testability benefits found between a controller and view
Can have parameters and business logic
Is typically invoked from a layout page",
                        CategoryId  = category.ID
                     }
                );

                context.SaveChanges();

                var tag = context.Tags.First();
                var post = context.Posts.First();  

                post.PostTags.Add(new PostTag
                {
                    PostId = post.ID,
                    TagId = tag.ID
                });

            }
        }
    }
}