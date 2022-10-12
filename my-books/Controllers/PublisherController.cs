using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;
using my_books.Data.VeiwModels;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private PublisherService _PublisherService;

        public PublishersController(PublisherService publisherService)
        {
            _PublisherService = publisherService;
        }

        [HttpPost]
        public IActionResult AddPublisher([FromBody] PublisherVm publisher)
        {
            _PublisherService.AddPusblisher(publisher);
            return Ok();
        }

        [HttpGet("get-Publisher-books-with-authors/{id}")]
        public IActionResult GetPublisherData(int id)
        {
            var _response = _PublisherService.GetPublisherData(id);
            return Ok(_response);  
        }

        [HttpDelete("delete-publisher-by-id{id}")]
        public IActionResult DeletePublisherById(int id)
        {
            _PublisherService.DeletePublisherById(id);
            return Ok();
        }
    }
}
