using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.MvcUI.Controllers
{
    public class UserLogInController : Controller
    {
        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }
    }
}
