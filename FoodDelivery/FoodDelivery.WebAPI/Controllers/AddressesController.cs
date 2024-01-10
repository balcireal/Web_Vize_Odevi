using FoodDelivery.Business.Interfaces;
using FoodDelivery.Model.Dtos.Address;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : BaseController
    {
        private readonly IAddressBs _addressBs;

        public AddressesController(IAddressBs addressBs)
        {
            _addressBs = addressBs;
        }
        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<AddressGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<AddressGetDto>))]
        #endregion
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await _addressBs.GetByIdAsync(id);
            return await SendResponseAsync(response);
        }
        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<AddressGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<List<AddressGetDto>>))]
        #endregion
        [HttpGet]
        public async Task<IActionResult> GetAddresses()
        {
            var response = await _addressBs.GetAddressesAsync();
            return await SendResponseAsync(response);
        }
        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<AddressGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<List<AddressGetDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<List<AddressGetDto>>))]
        #endregion
        [HttpGet("getbycity")]
        public async Task<IActionResult> GetAddressesByCity([FromQuery] string city)
        {
            var response = await _addressBs.GetAddressesByCityAsync(city);
            return await SendResponseAsync(response);
        }
        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<AddressGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<List<AddressGetDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<List<AddressGetDto>>))]
        #endregion
        [HttpGet("getbyregion")]
        public async Task<IActionResult> GetAddressesByRegion([FromQuery] string region)
        {
            var response = await _addressBs.GetAddressesByRegionAsync(region);
            return await SendResponseAsync(response);
        }

        [HttpPost]
        public async Task<IActionResult> SaveNewAddress([FromBody] AddressPostDto dto)
        {
            var response = await _addressBs.InsertAsync(dto);

            if (response.ErrorMessages != null && response.ErrorMessages.Count > 0)
            {
                return await SendResponseAsync(response);
            }
            else
                return CreatedAtAction(nameof(GetById), new { id = response.Data.AddressId }, response.Data);

        }
        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        #endregion 
        [HttpPut]
        public async Task<IActionResult> UpdateAddress([FromBody] AddressPutDto dto)
        {
            var response = await _addressBs.UpdateAsync(dto);

            return await SendResponseAsync(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddress(int id)
        {
            var response = await _addressBs.DeleteAsync(id);

            return await SendResponseAsync(response);
        }

    }
}
