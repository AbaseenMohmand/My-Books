using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Models;
using my_books.Data.Models.ViewModels;
using my_books.Data.Services;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BooksService _service;

        public BooksController(BooksService service)
        {
            _service = service;
        }

        [HttpPost("add-book")]
        public IActionResult AddBook([FromBody]BookVM bookVM)
        {
            _service.AddBook(bookVM);
            return Ok();
        }
        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks()
        {
            var getBooks = _service.GetAllBooks();
            return Ok(getBooks);
        }

        [HttpGet("get-book-by-id/{id}")]
        public IActionResult GetBookById(int id)
        {
            var getBookbyId = _service.GetBookById(id);
            return Ok(getBookbyId);
        }

        [HttpPut("update-book-by-id/{id}")]
        public IActionResult UpdateBook(int id, BookVM bookVM)
        {
            var updateBook = _service.UpdateBookById(id, bookVM);
            return Ok(updateBook);

        }



    }
}
