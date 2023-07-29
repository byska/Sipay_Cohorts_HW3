using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sipay_Cohorts_HW3.DataAccess.Context;
using Sipay_Cohorts_HW3.Entities.DbSets;
using Sipay_Cohorts_HW3.Entities.Enums;

namespace Sipay_Cohorts_HW3.DataAccess.Seed
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
                context.Books.AddRange(new Book()
                {
                    Id = 1,
                    Title = "Lean Startup",
                    GenreId = Genre.ScienceFiction,
                    PageCount = 250,
                    PublishDate = new DateTime(2001, 10, 12)

                },
                new Book
                {
                    Id = 2,
                    Title = "Herland",
                    GenreId = Genre.PersonalGrowth,
                    PageCount = 250,
                    PublishDate = new DateTime(2011, 05, 12)
                },
                 new Book
                 {
                     Id = 3,
                     Title = "Dune",
                     GenreId = Genre.ScienceFiction,
                     PageCount = 540,
                     PublishDate = new DateTime(2001, 12, 12)
                 }
                );
                context.SaveChanges();
            }
        }
    }
}
