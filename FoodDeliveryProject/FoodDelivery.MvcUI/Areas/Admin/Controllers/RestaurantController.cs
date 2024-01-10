using FoodDelivery.MvcUI.Areas.Admin.Filters;
using FoodDelivery.MvcUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FoodDelivery.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [SessionAspect]
    public class RestaurantController : Controller
    {
        public async Task<IActionResult> Index()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5137/api");

                var httpResponseMessage = await client.GetAsync($"{client.BaseAddress}/restaurants");

                var jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();

                var response =
                  JsonSerializer.Deserialize<ResponseBody<List<RestaurantItem>>>(jsonResponse,
                  new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                return View(response.Data);
            }
        }
    }
}
