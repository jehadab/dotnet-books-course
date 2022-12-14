using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using my_books.Data.Models;

namespace my_books.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Publishers.Any())
                {
                    context.Publishers.Add(
                        new Publisher()
                        {
                            Name = "marly manson",
                        });
                    context.SaveChanges();
                }

                if (!context.Books.Any())
                {
                    context.Books.AddRange(new Book()
                    {
                        Title = "first book",
                        Description = "first des",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Genre = "Bio",
                        CoverUrl = "https....",
                        DateAdded = DateTime.Now,
                        PublisherId = 1
                      

                    },
                    new Book()
                    {
                        Title = "second book",
                        Description = "second des",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-20),
                        Genre = "historical",
                        CoverUrl = "https....",
                        DateAdded = DateTime.Now,
                        PublisherId = 1
                        

                    }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}
