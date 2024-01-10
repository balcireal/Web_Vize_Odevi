using FoodDelivery.Business.Interfaces;
using FoodDelivery.Model.Dtos.Country;
using FoodDelivery.Model.Dtos.Product;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : BaseController
    {
        private readonly ICountryBs _countryBs;

        public CountriesController(ICountryBs countryBs)
        {
            _countryBs = countryBs;
        }
        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<CountryGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<CountryGetDto>))]
        #endregion
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await _countryBs.GetByIdAsync(id);
            return await SendResponseAsync(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<CountryGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<List<CountryGetDto>>))]
        #endregion
        [HttpGet]
    public async Task<IActionResult> GetCountries()
        {
            var response = await _countryBs.GetCountriesAsync();
            return await SendResponseAsync(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<CountryGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<List<CountryGetDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<List<CountryGetDto>>))]
        #endregion
        [HttpGet("getbyname")]
public async Task<IActionResult> GetCountriesByCountryName([FromQuery] string name)
        {
            var response = await _countryBs.GetCountriesByCountryNameAsync(name);
            return await SendResponseAsync(response);
        }

        [HttpPost]
public async Task<IActionResult> SaveNewCountry([FromBody] CountryPostDto dto)
        {
            var response = await _countryBs.InsertAsync(dto);
            if (response.ErrorMessages != null && response.ErrorMessages.Count > 0)
            {
                return await SendResponseAsync(response);
            }
            else
                return CreatedAtAction(nameof(GetById), new { id = response.Data.CountryId }, response.Data);

        }
        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        #endregion
        [HttpPut]
public async Task<IActionResult> UpdateCountry([FromBody] CountryPutDto dto)
        {

            var response = await _countryBs.UpdateAsync(dto);

            return await SendResponseAsync(response);
        }

        [HttpDelete("{id}")]
public async Task<IActionResult> DeleteCountry(int id)
        {

            var response = await _countryBs.DeleteAsync(id);

            return await SendResponseAsync(response);
        }
    }
}
