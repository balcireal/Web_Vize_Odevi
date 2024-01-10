using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.MvcUI.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult About()
        {
            return View();
        }
    }
}
