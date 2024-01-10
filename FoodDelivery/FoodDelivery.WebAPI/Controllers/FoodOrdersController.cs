using FoodDelivery.Business.Interfaces;
using FoodDelivery.Model.Dtos.FoodOrder;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodOrdersController : BaseController
    {
        private readonly IFoodOrderBs _foodOrderBs;

        public FoodOrdersController(IFoodOrderBs foodOrderBs)
        {
            _foodOrderBs = foodOrderBs;
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<FoodOrderGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<FoodOrderGetDto>))]
        #endregion
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await _foodOrderBs.GetByIdAsync(id);
            return await SendResponseAsync(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<FoodOrderGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<List<FoodOrderGetDto>>))]
        #endregion
        [HttpGet]
        public async Task<IActionResult> GetFoodOrders()
        {
            var response = await _foodOrderBs.GetFoodOrdersAsync();
            return await SendResponseAsync(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<FoodOrderGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<List<FoodOrderGetDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<List<FoodOrderGetDto>>))]
        #endregion
        [HttpGet("getbyamount")]
        public async Task<IActionResult> GetFoodOrdersByTotalAmount([FromQuery] decimal min, [FromQuery] decimal max)
        {
            var response = await _foodOrderBs.GetFoodOrdersByTotalAmountAsync(min, max);
            return await SendResponseAsync(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<FoodOrderGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<List<FoodOrderGetDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<List<FoodOrderGetDto>>))]
        #endregion
        [HttpGet("getbyfee")]
        public async Task<IActionResult> GetFoodOrdersByDeliveryFee([FromQuery] decimal min, [FromQuery] decimal max)
        {
            var response = await _foodOrderBs.GetFoodOrdersByDeliveryFeeAsync(min, max);
            return await SendResponseAsync(response);
        }

        [HttpPost]
        public async Task<IActionResult> SaveNewFoodOrder([FromBody] FoodOrderPostDto dto)
        {
            var response = await _foodOrderBs.InsertAsync(dto);
            if (response.ErrorMessages != null && response.ErrorMessages.Count > 0)
            {
                return await SendResponseAsync(response);
            }
            else
                return CreatedAtAction(nameof(GetById), new { id = response.Data.FoodOrderId }, response.Data);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        #endregion 
        [HttpPut]
        public async Task<IActionResult> UpdateFoodOrder([FromBody] FoodOrderPutDto dto)
        {
            var response = await _foodOrderBs.UpdateAsync(dto);

            return await SendResponseAsync(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFoodOrder(int id)
        {
            var response = await _foodOrderBs.DeleteAsync(id);

            return await SendResponseAsync(response);
        }
    }
}
