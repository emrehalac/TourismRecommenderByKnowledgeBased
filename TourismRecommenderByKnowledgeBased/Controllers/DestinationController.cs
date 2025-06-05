using Microsoft.AspNetCore.Mvc;
using TourismRecommender.Business.Services;
using TourismRecommender.Entities.Models;

namespace TourismRecommenderByKnowledgeBased.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DestinationController : ControllerBase
    {
        private readonly IDestinationService _service;

        public DestinationController(IDestinationService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<Destination> Get()
        {
            return _service.GetAll();
        }

        [HttpPost]
        public IActionResult Post(Destination destination)
        {
            _service.Add(destination);
            return CreatedAtAction(nameof(Get), new { id = destination.Id }, destination);
        }
    }
}
