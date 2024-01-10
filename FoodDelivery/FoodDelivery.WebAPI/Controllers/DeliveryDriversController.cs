using AutoMapper;
using FoodDelivery.Business.Interfaces;
using FoodDelivery.Model.Dtos.DeliveryDriver;
using FoodDelivery.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using FoodDelivery.WebAPI.Controllers;
using FoodDelivery.Model.Dtos.Product;
using Infrastructure.Utilities.ApiResponses;

namespace FoodDelivery.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryDriversController : BaseController
    {
        private readonly IDeliveryDriverBs _deliveryDriverBs;

        public DeliveryDriversController(IDeliveryDriverBs deliveryDriverBs)
        {
            _deliveryDriverBs = deliveryDriverBs;
        }
        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<DeliveryDriverGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<DeliveryDriverGetDto>))]
        #endregion
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await _deliveryDriverBs.GetByIdAsync(id);
            return await SendResponseAsync(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<DeliveryDriverGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<List<DeliveryDriverGetDto>>))]
        #endregion
        [HttpGet]
        public async Task<IActionResult> GetDeliveryDrivers()
        {
            var response = await _deliveryDriverBs.GetDeliveryDriversAsync();
            return await SendResponseAsync(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<DeliveryDriverGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<List<DeliveryDriverGetDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<List<DeliveryDriverGetDto>>))]
        #endregion
        [HttpGet("getbyname")]
        public async Task<IActionResult> GetDeliveryDriversByFirstName([FromQuery] string firstName)
        {
            var response = await _deliveryDriverBs.GetDeliveryDriversByFirstNameAsync(firstName);
            return await SendResponseAsync(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<DeliveryDriverGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<List<DeliveryDriverGetDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<List<DeliveryDriverGetDto>>))]
        #endregion
        [HttpGet("getbyphone")]
        public async Task<IActionResult> GetDeliveryDriversByPhone([FromQuery] string phone)
        {
            var response = await _deliveryDriverBs.GetDeliveryDriversByPhoneAsync(phone);
            return await SendResponseAsync(response);
        }

        [HttpPost]
        public async Task<IActionResult> SaveNewDeliveryDriver([FromBody] DeliveryDriverPostDto dto)
        {

            var response = await _deliveryDriverBs.InsertAsync(dto);
            if (response.ErrorMessages != null && response.ErrorMessages.Count > 0)
            {
                return await SendResponseAsync(response);
            }
            else
                return CreatedAtAction(nameof(GetById), new { id = response.Data.DeliveryDriverId }, response.Data);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        #endregion 
        [HttpPut]
        public async Task<IActionResult> UpdateDeliveryDriver([FromBody] DeliveryDriverPutDto dto)
        {
            var response = await _deliveryDriverBs.UpdateAsync(dto);
            return await SendResponseAsync(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeliveryDriver(int id)
        {
            var response = await _deliveryDriverBs.DeleteAsync(id);
            return await SendResponseAsync(response);
        }
    }
}
