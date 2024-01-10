using FoodDelivery.Business.Interfaces;
using FoodDelivery.Model.Dtos.Customer;
using FoodDelivery.Model.Dtos.Product;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : BaseController
    {
        private readonly ICustomerBs _customerBs;
        public CustomersController(ICustomerBs customerBs)
        {
            _customerBs = customerBs;
        }
        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<CustomerGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<CustomerGetDto>))]
        #endregion
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await _customerBs.GetByIdAsync(id);
            return await SendResponseAsync(response);
        }
        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<CustomerGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<List<CustomerGetDto>>))]
        #endregion  
        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            var response = await _customerBs.GetCustomersAsync();
            return await SendResponseAsync(response);
        }
        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<CustomerGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<List<CustomerGetDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<List<CustomerGetDto>>))]
        #endregion
        [HttpGet("getbyfirstname")]
        public async Task<IActionResult> GetCustomersByFirstName([FromQuery] string firstName)
        {
            var response = await _customerBs.GetCustomersByFirstNameAsync(firstName);
            return await SendResponseAsync(response);
        }
        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<CustomerGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<List<CustomerGetDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<List<CustomerGetDto>>))]
        #endregion
        [HttpGet("getbylastname")]
        public async Task<IActionResult> GetCustomersByLastName([FromQuery] string lastName)
        {
            var response = await _customerBs.GetCustomersByLastNameAsync(lastName);
            return await SendResponseAsync(response);
        }
        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<CustomerGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<List<CustomerGetDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<List<CustomerGetDto>>))]
        #endregion
        [HttpGet("getbyphone")]
        public async Task<IActionResult> GetCustomersByPhone([FromQuery] string phone)
        {
            var response = await _customerBs.GetCustomersByPhoneAsync(phone);
            return await SendResponseAsync(response);
        }

        [HttpPost]
        public async Task<IActionResult> SaveNewCustomer([FromBody] CustomerPostDto dto)
        {
            var response = await _customerBs.InsertAsync(dto);
            if (response.ErrorMessages != null && response.ErrorMessages.Count > 0)
            {
                return await SendResponseAsync(response);
            }
            else
                return CreatedAtAction(nameof(GetById), new { id = response.Data.CustomerId }, response.Data);

        }
        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        #endregion 
        [HttpPut]
        public async Task<IActionResult> UpdateCustomer([FromBody] CustomerPutDto dto)
        {
            var response = await _customerBs.UpdateAsync(dto);

            return await SendResponseAsync(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var response = await _customerBs.DeleteAsync(id);

            return await SendResponseAsync(response);
        }
    }
}
