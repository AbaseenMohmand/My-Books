namespace my_books.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Books.Any())
                {
                    context.Books.AddRange(new Models.Book()
                    {
                        Title ="1st BookName",
                        Description ="This is the 1st book description",
                        IsRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 4,
                        Genre ="Biography",
                       
                        CoverUrl = "http......",
                        DateAdded = DateTime.Now,
                        
                    },
                    new Models.Book()
                    {
                        Title = "2nd BookName",
                        Description = "This is the 2nd book description",
                        IsRead = false,
                      
                        Rate = 4,
                        Genre = "Biography",
                        
                        CoverUrl = "http......",
                        DateAdded = DateTime.Now,

                    });
                }
                context.SaveChanges();
            }
        }
    }
}
