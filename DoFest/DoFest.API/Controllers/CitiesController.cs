using System.Threading.Tasks;
using DoFest.Business.Places.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoFest.API.Controllers
{
    [Route("/api/v1/cities")]
    [ApiController]
    public class CitiesController:ControllerBase
    {
        private readonly ICityService _cityService;
        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllCities()
        {
            var result = await _cityService.GetAllCities();
            return Ok(result);
        }
    }
}