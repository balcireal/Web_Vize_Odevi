using AutoMapper;
using FoodDelivery.Business.Interfaces;
using FoodDelivery.Model.Dtos.OrderProduct;
using FoodDelivery.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using FoodDelivery.WebAPI.Controllers;
using FoodDelivery.Model.Dtos.Product;
using Infrastructure.Utilities.ApiResponses;

namespace FoodDelivery.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderProductsController : BaseController
    {
        private readonly IOrderProductBs _orderProductBs;
        public OrderProductsController(IOrderProductBs orderProductBs)
        {
            _orderProductBs = orderProductBs;
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<OrderProductGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<OrderProductGetDto>))]
        #endregion
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await _orderProductBs.GetByIdAsync(id, "Product", "FoodOrder");
            return await SendResponseAsync(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<OrderProductGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<List<OrderProductGetDto>>))]
        #endregion
        [HttpGet]
        public async Task<IActionResult> GetOrderProducts()
        {
            var response = await _orderProductBs.GetOrderProductsAsync("Product", "FoodOrder");
            return await SendResponseAsync(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<OrderProductGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<List<OrderProductGetDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<List<OrderProductGetDto>>))]
        #endregion
        [HttpGet("getbyquantity")]
        public async Task<IActionResult> GetOrderProductsByQtyOrdered([FromQuery] decimal min, [FromQuery] decimal max)
        {
            var response = await _orderProductBs.GetOrderProductsByQtyOrderedAsync(min, max, "Product", "FoodOrder");
            return await SendResponseAsync(response);
        }

        [HttpPost]
        public async Task<IActionResult> SaveNewOrderProduct([FromBody] OrderProductPostDto dto)
        {
            var response = await _orderProductBs.InsertAsync(dto);
            if (response.ErrorMessages != null && response.ErrorMessages.Count > 0)
            {
                return await SendResponseAsync(response);
            }
            else
                return CreatedAtAction(nameof(GetById), new { id = response.Data.OrderProductId }, response.Data);

        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        #endregion 
        [HttpPut]
        public async Task<IActionResult> UpdateOrderProduct([FromBody] OrderProductPutDto dto)
        {
            var response = await _orderProductBs.UpdateAsync(dto);
            return await SendResponseAsync(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderProduct(int id)
        {
            var response = await _orderProductBs.DeleteAsync(id);
            return await SendResponseAsync(response);
        }
    }
}
