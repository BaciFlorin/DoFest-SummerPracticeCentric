using System;
using System.Threading.Tasks;
using DoFest.Business.Places.Models;
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

        [HttpPost()]
        public async Task<IActionResult> CreateCity([FromBody] CreateCityModel cityModel)
        {
            var result = await _cityService.CreateCity(cityModel);

            if (result == null)
            {
                return BadRequest("City already exists!");
            }

            return Ok(result);
        }

        [HttpDelete("{cityId}")]
        public async Task<IActionResult> DeleteCity([FromRoute] Guid cityId)
        {
            var isSuccess = await _cityService.DeleteCity(cityId);
            if (!isSuccess)
            {
                return BadRequest("City doesn't exists");
            }

            return Ok();
        }
    }
}