using FoodDelivery.MvcUI.Areas.Admin.Filters;
using Microsoft.AspNetCore.Mvc;

namespace FoodDelivery.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [SessionAspect]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
