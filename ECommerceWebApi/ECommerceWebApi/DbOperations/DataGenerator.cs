using System;
using ECommerceWebApi.Model;
using Microsoft.EntityFrameworkCore;

namespace ECommerceWebApi.DbOperations
{
	public class DataGenerator
	{
		public static void Initialize(IServiceProvider serviceProvider)
		{
			using( var context = new ECommerceDbContext(serviceProvider.GetRequiredService<DbContextOptions<ECommerceDbContext>>()))
			{
                if (context.Products.Any())
                {
                    return;
                }
				context.AddRange(
					new Product
					{
						Name = "iPhone 11 64 Gb Beyaz",
						CategoryId = 2,
						Price = 11999.99,
						PublishDate = new DateTime(2022, 08, 25)

					},
					new Product
					{
						Name = "Samsung S21 Ultra",
						CategoryId = 1,
						Price = 21999.99,
						PublishDate = new DateTime(2022, 08, 23)

					});
				context.SaveChanges();
            }

			using (var context = new ECommerceDbContext(serviceProvider.GetRequiredService<DbContextOptions<ECommerceDbContext>>()))
			{
                if (context.Categories.Any())
                {
                    return;
                }
                context.AddRange(
                    new Category
					{
						Title = "Cleaning"
					},
					new Category
					{
						Title = "Smart Phone"
					},
					new Category
					{
						Title = "Clothes"
					}
                );
            }
		}
	}
}

