using FoodDelivery.Business.Interfaces;
using FoodDelivery.Model.Dtos.Restaurant;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : BaseController
    {
        private readonly IRestaurantBs _restaurantBs;

        public RestaurantsController(IRestaurantBs restaurantBs)
        {
            _restaurantBs = restaurantBs;
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<RestaurantGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<RestaurantGetDto>))]
        #endregion
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await _restaurantBs.GetByIdAsync(id, "Address");
            return await SendResponseAsync(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<RestaurantGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<List<RestaurantGetDto>>))]
        #endregion  
        [HttpGet]
        public async Task<IActionResult> GetRestaurants()
        {
            var response = await _restaurantBs.GetRestaurantsAsync("Address");
            return await SendResponseAsync(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<RestaurantGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<List<RestaurantGetDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<List<RestaurantGetDto>>))]
        #endregion
        [HttpGet("getbyname")]
        public async Task<IActionResult> GetRestaurantsByRestaurantName([FromQuery] string name)
        {
            var response = await _restaurantBs.GetRestaurantsByRestaurantNameAsync(name, "Address");
            return await SendResponseAsync(response);
        }

        [HttpPost]
        public async Task<IActionResult> SaveNewRestaurant([FromBody] RestaurantPostDto dto)
        {
            var response = await _restaurantBs.InsertAsync(dto);
            if (response.ErrorMessages != null && response.ErrorMessages.Count > 0)
            {
                return await SendResponseAsync(response);
            }
            else
                return CreatedAtAction(nameof(GetById), new { id = response.Data.RestaurantId }, response.Data);

        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        #endregion 
        [HttpPut]
        public async Task<IActionResult> UpdateRestaurant([FromBody] RestaurantPutDto dto)
        {
            var response = await _restaurantBs.UpdateAsync(dto);
            return await SendResponseAsync(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurant(int id)
        {
            var response = await _restaurantBs.DeleteAsync(id);
            return await SendResponseAsync(response);
        }
    }
}
