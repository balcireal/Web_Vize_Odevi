using FoodDelivery.Business.Interfaces;
using FoodDelivery.Model.Dtos.OrderStatus;
using FoodDelivery.Model.Dtos.Product;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderStatusesController : BaseController
    {
        private readonly IOrderStatusBs _orderStatusBs;

        public OrderStatusesController(IOrderStatusBs orderStatusBs)
        {
            _orderStatusBs = orderStatusBs;
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<OrderStatusGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<OrderStatusGetDto>))]
        #endregion
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await _orderStatusBs.GetByIdAsync(id);
            return await SendResponseAsync(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<OrderStatusGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<List<OrderStatusGetDto>>))]
        #endregion
        [HttpGet]
        public async Task<IActionResult> GetOrderStatuses()
        {
            var response = await _orderStatusBs.GetOrderStatusesAsync();
            return await SendResponseAsync(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<OrderStatusGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<List<OrderStatusGetDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<List<OrderStatusGetDto>>))]
        #endregion
        [HttpGet("getbycity")]
        public async Task<IActionResult> GetOrderStatusesByStatusValue([FromQuery] string status)
        {
            var response = await _orderStatusBs.GetOrderStatusesByStatusValueAsync(status);
            return await SendResponseAsync(response);
        }


        [HttpPost]
        public async Task<IActionResult> SaveNewOrderStatus([FromBody] OrderStatusPostDto dto)
        {

            var response = await _orderStatusBs.InsertAsync(dto);
            if (response.ErrorMessages != null && response.ErrorMessages.Count > 0)
            {
                return await SendResponseAsync(response);
            }
            else
                return CreatedAtAction(nameof(GetById), new { id = response.Data.OrderStatusId }, response.Data);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        #endregion 
        [HttpPut]
        public async Task<IActionResult> UpdateOrderStatus([FromBody] OrderStatusPutDto dto)
        {

            var response = await _orderStatusBs.UpdateAsync(dto);
            return await SendResponseAsync(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderStatus(int id)
        {
            var response = await _orderStatusBs.DeleteAsync(id);
            return await SendResponseAsync(response);
        }
    }
}
