using FoodDelivery.MvcUI.Areas.Admin.Models;
using FoodDelivery.MvcUI.Areas.Admin.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;

namespace FoodDeliveryProject.MvcUI.Areas.Admin.ViewComponents
{
  public class SideBarViewComponent:ViewComponent
  {
    public ViewViewComponentResult Invoke()
    {
      var adminUser = HttpContext.Session.GetObject<AdminUserItem>("ActiveAdminUser");

      return View(adminUser);
    }
  }
}
