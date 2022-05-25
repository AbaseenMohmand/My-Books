using my_books.Data.Models;
using my_books.Data.Models.ViewModels;

namespace my_books.Data.Services
{
    public class AuthorsService
    {
        private AppDbContext _context;

        public AuthorsService(AppDbContext context)
        {
            _context = context;
        }

        public void AddAuthor(AuthorVM authorVM)
        {
            var author = new Author()
            {
               FullName = authorVM.FullName,
            };
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public AuthorWithBooksVM GetAuthorWithBooksVM(int authorId)
        {
            var authorWithBooks = _context.Authors.Where(x => x.Id == authorId).Select(n => new AuthorWithBooksVM()
            {
                FullName = n.FullName,
                BookTitles = _context.Book_Authors.Select(x => x.Book.Title).ToList()
            }).FirstOrDefault();

            return authorWithBooks;
        }

       
    }
}
