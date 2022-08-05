using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace HelloWebApi.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }

                context.Books.AddRange(
                    new Book
                    {
                        //Id = 1,
                        Title = "Lean startup",
                        GenreId = 1,
                        PageCount = 200,
                        PublishDate = new DateTime(2001, 06, 12)
                    },
                    new Book
                    {
                        //Id = 2,
                        Title = "Hearland",
                        GenreId = 2,
                        PageCount = 230,
                        PublishDate = new DateTime(2010, 03, 11)
                    },
                      new Book
                      {
                         // Id = 3,
                          Title = "Dune",
                          GenreId = 3,
                          PageCount = 530,
                          PublishDate = new DateTime(2014, 12, 11)
                      });
                context.SaveChanges();
                
            }
        }
    }
}
