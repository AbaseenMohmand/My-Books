using my_books.Data.Models;
using my_books.Data.Models.ViewModels;

namespace my_books.Data.Services
{
    public class BooksService
    {
        private AppDbContext _context;

        public BooksService(AppDbContext context)
        {
            _context = context;              
        }

        public void AddBook(BookVM bookVM)
        {
            var book = new Book()
            {
                Title = bookVM.Title,
                Description = bookVM.Description,
                IsRead = bookVM.IsRead,
                DateRead = bookVM.DateRead,
                Rate = bookVM.Rate,
                Genre = bookVM.Genre,
                CoverUrl = bookVM.CoverUrl,
                Author = bookVM.Author,
                DateAdded = DateTime.Now
            };
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public List<Book> GetAllBooks()
        {
            return _context.Books.ToList();

        }

        public Book GetBookById(int id)
        {
           
                return _context.Books.FirstOrDefault(x => x.Id == id);

            
            
        }

        public Book UpdateBookById(int id, BookVM bookVM)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == id);

            if (book != null)
            {
                book.Title = bookVM.Title;
                book.Description = bookVM.Description;
                book.IsRead = bookVM.IsRead;
                book.DateRead = bookVM.DateRead;
                book.Rate = bookVM.Rate;
                book.Genre = bookVM.Genre;
                book.CoverUrl = bookVM.CoverUrl;
                book.Author = bookVM.Author;

                _context.SaveChanges();
            }

            return book;
        }
    }
}
