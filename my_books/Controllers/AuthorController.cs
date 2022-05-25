using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Models.ViewModels;
using my_books.Data.Services;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private AuthorsService _service;
        public AuthorController(AuthorsService service)
        {
            _service = service;

        }
        [HttpPost("add-author")]
        public IActionResult AddAuthor([FromBody] AuthorVM authorVM)
        {
            _service.AddAuthor(authorVM);
            return Ok();
        }

        [HttpGet("get-author-with-books-by-id/{id}")]
        public IActionResult GetAuthorWithBooks(int id)
        {
            var response = _service.GetAuthorWithBooksVM(id);
            return Ok(response);
        }
    }
}
