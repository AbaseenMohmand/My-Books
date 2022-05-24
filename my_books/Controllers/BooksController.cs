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

        [HttpPost]
        public IActionResult AddBook([FromBody]BookVM bookVM)
        {
            _service.AddBook(bookVM);
            return Ok();
        }
        

      
    }
}
