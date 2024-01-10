using FoodDelivery.Business.Interfaces;
using FoodDelivery.Model.Dtos.Product;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Mvc;
using FoodDelivery.WebAPI.Controllers;
using Microsoft.AspNetCore.Authorization;

namespace FoodDelivery.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        private readonly IProductBs _productBs;

        public ProductsController(IProductBs productBs)
        {
            _productBs = productBs;
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<ProductGetDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<ProductGetDto>))]
        #endregion
        [HttpGet("{id}")]
        //[Authorize]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var response = await _productBs.GetByIdAsync(id, "Category", "Restaurant", "OrderProducts");
            return await SendResponseAsync(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<ProductGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<List<ProductGetDto>>))]
        #endregion
        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> GetProducts()
        {
            var response = await _productBs.GetProductsAsync("Category", "Restaurant", "OrderProducts");
            return await SendResponseAsync(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<ProductGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<List<ProductGetDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<List<ProductGetDto>>))]
        #endregion
        [HttpGet("getbyname")]
        //[Authorize]
        public async Task<IActionResult> GetProductsByProductName([FromQuery] string productName)
        {
            var response = await _productBs.GetProductsByProductNameAsync(productName, "Category", "Restaurant", "OrderProducts");
            return await SendResponseAsync(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<ProductGetDto>>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<List<ProductGetDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<List<ProductGetDto>>))]
        #endregion
        [HttpGet("getbyprice")]
        //[Authorize]
        public async Task<IActionResult> GetProductsByPriceRange([FromQuery] int min, [FromQuery] int max)
        {
            var response = await _productBs.GetProductsByPriceRangeAsync(min, max, "Category", "Restaurant", "OrderProducts");
            return await SendResponseAsync(response);
        }

        [HttpPost]
        public async Task<IActionResult> SaveNewProduct([FromBody] ProductPostDto dto)
        {
            var response = await _productBs.InsertAsync(dto);

            if (response.ErrorMessages != null && response.ErrorMessages.Count > 0)
            {
                return await SendResponseAsync(response);
            }
            else
                return CreatedAtAction(nameof(GetById), new { id = response.Data.ProductId }, response.Data);

        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        #endregion
        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductPutDto dto)
        {
            var response = await _productBs.UpdateAsync(dto);
            return await SendResponseAsync(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var response = await _productBs.DeleteAsync(id);
            return await SendResponseAsync(response);
        }
    }
}
