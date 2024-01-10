using FoodDelivery.Business.Interfaces;
using FoodDelivery.Model.Dtos.AdminUser;
using Infrastructure.Utilities.ApiResponses;
using Infrastructure.Utilities.Security.JWT;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace FoodDelivery.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : BaseController
    {
        private readonly IConfiguration _configuration;
        private readonly IAdminUserBs _adminUserBs;
        public AuthenticationController(IAdminUserBs adminUserBs, IConfiguration configuration)
        {
            _adminUserBs = adminUserBs;
            _configuration = configuration;
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<AccessToken>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpGet("gettoken")]
        public async Task<IActionResult> GetToken()
        {
            var accessToken = new JwtGenerator(_configuration).CreateAccessToken();
            ApiResponse<AccessToken> response = new ApiResponse<AccessToken>() { Data = accessToken, StatusCode = 200 };

            return await SendResponseAsync(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<List<AdminUserGetDto>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse<NoData>))]
        #endregion
        [HttpGet("logIn")]
        public async Task<IActionResult> LogIn([FromQuery] string userName, [FromQuery] string password)
        {
            var response = await _adminUserBs.LogIn(userName, password);
            return await SendResponseAsync(response);
        }
    }
}
