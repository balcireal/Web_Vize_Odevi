using AutoMapper;
using FoodDelivery.Business.Interfaces;
using FoodDelivery.Model.Dtos.CustomerAddress;
using FoodDelivery.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using FoodDelivery.WebAPI.Controllers;
using FoodDelivery.Model.Dtos.Product;
using Infrastructure.Utilities.ApiResponses;

namespace FoodDelivery.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerAddressesController : BaseController
    {
        private readonly ICustomerAddressBs _customerAddressBs;
        public CustomerAddressesController(ICustomerAddressBs customerAddressBs)
        {
            _customerAddressBs = customerAddressBs;
        }
        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<CustomerAddressGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<CustomerAddressGetDto>))]
        #endregion
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await _customerAddressBs.GetByIdAsync(id, "Customer", "Address");
            return await SendResponseAsync(response);
        }
        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<CustomerAddressGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<List<CustomerAddressGetDto>>))]
        #endregion
        [HttpGet]
        public async Task<IActionResult> GetCustomerAddresses()
        {
            var response = await _customerAddressBs.GetCustomerAddressesAsync("Customer", "Address");
            return await SendResponseAsync(response);
        }


        [HttpPost]
        public async Task<IActionResult> SaveNewCustomerAddress([FromBody] CustomerAddressPostDto dto)
        {
            var response = await _customerAddressBs.InsertAsync(dto);
            if (response.ErrorMessages != null && response.ErrorMessages.Count > 0)
            {
                return await SendResponseAsync(response);
            }
            else
                return CreatedAtAction(nameof(GetById), new { id = response.Data.CustomerAddressId }, response.Data);
        }
        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        #endregion
        [HttpPut]
        public async Task<IActionResult> UpdateCustomerAddress([FromBody] CustomerAddressPutDto dto)
        {
            var response = await _customerAddressBs.UpdateAsync(dto);

            return await SendResponseAsync(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerAddress(int id)
        {
            var response = await _customerAddressBs.DeleteAsync(id);

            return await SendResponseAsync(response);
        }
    }
}
