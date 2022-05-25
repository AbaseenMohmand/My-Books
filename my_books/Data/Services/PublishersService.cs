using my_books.Data.Models;
using my_books.Data.Models.ViewModels;

namespace my_books.Data.Services
{
    public class PublishersService
    {
        private AppDbContext _context;

        public PublishersService(AppDbContext context)
        {
            _context = context;
        }

        public void AddPublisher(PublisherVM publisherVM)
        {
            var publisher = new Publisher()
            {
                Name = publisherVM.Name,
            };
            _context.Publishers.Add(publisher);
            _context.SaveChanges();
        }
    }
}
