using Microsoft.AspNetCore.Mvc.Filters;

namespace FoodDelivery.MvcUI.Areas.Admin.Filters
{
    public class LogAspect : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            // Bu metod, bu classın attribute olarak uygulandığı action metod çalışmaya başlar başlamaz otomatik olarak tetiklenecektir. 
        }
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            // Bu metod, bu classın attribute olarak uygulandığı action metod sonuç döndürmeden hemen önce otomatik olarak tetiklenecektir. 
        }
    }
}
