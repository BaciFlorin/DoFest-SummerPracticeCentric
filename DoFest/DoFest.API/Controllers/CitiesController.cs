using System;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using DoFest.Business.Activities.Models.Places;
using DoFest.Business.Activities.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        public async Task<IActionResult> CreateCity([FromBody] CreateCityModel cityModel)
        {
            var (_, isFailure, value, error) = await _cityService.CreateCity(cityModel);

            if (isFailure)
            {
                return BadRequest(error);
            }

            return Ok(value);
        }

        [HttpDelete("{cityId}")]
        [Authorize]
        public async Task<IActionResult> DeleteCity([FromRoute] Guid cityId)
        {
            var (_, isFailure, value, error) = await _cityService.DeleteCity(cityId);
            if (isFailure)
            {
                return BadRequest(error);
            }

            return Ok(new { value });
        }
    }
}