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

        public void AddBookWithAuthors(BookVM bookVM)
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
                
                DateAdded = DateTime.Now,
                PublisherId = bookVM.PublisherId,
                
            };
            _context.Books.Add(book);
            _context.SaveChanges();

            foreach(var id in bookVM.AuthorIds)
            {
                var _book_author = new Book_Author()
                {
                    BookId = book.Id,
                    AuthorId = id
                };
                _context.Book_Authors.Add(_book_author);
                _context.SaveChanges();
            }
        }

        public List<Book> GetAllBooks()
        {
            return _context.Books.ToList();

        }

        public BookWithAuthorsVM GetBookById(int id)
        {

            var bookWithAuthors = _context.Books.Where(n => n.Id == id).Select(book => new BookWithAuthorsVM()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.DateRead,
                Rate = book.Rate,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                PublisherName = book.Publisher.Name,
                AuthorNames = book.book_Authors.Select(x => x.Author.FullName).ToList()
            }).FirstOrDefault();

            return bookWithAuthors;

            
            
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
                

                _context.SaveChanges();
            }

            return book;
        }

        public void DeleteBookById(int id)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == id);
            if(book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }
    }
}
