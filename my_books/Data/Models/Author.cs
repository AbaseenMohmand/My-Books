namespace my_books.Data.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        //Navigation

        public List<Book_Author> book_Authors { get; set; }
    }
}
