using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Models.ViewModels;
using my_books.Data.Services;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private PublishersService _service;
        public PublishersController(PublishersService service)
        {
            _service = service;

        }
        [HttpPost("add-publisher")]
        public IActionResult AddPublisher([FromBody]PublisherVM publisherVM)
        {
            _service.AddPublisher(publisherVM);
            return Ok();
        }
    }
}
