using FoodDelivery.MvcUI.Areas.Admin.Filters;
using FoodDelivery.MvcUI.Areas.Admin.Models;
using FoodDelivery.MvcUI.Areas.Admin.Models.Dtos.CustomerDtos;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FoodDelivery.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [SessionAspect]
    public class CustomerController : Controller
    {
        private readonly IWebHostEnvironment _webHost;

        public CustomerController(IWebHostEnvironment webHost)
        {
            _webHost = webHost;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5137/api");

                var httpResponseMessage = await client.GetAsync($"{client.BaseAddress}/customers");

                var jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();

                var response =
                  JsonSerializer.Deserialize<ResponseBody<List<CustomerItem>>>(jsonResponse,
                  new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                return View(response.Data);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Save(NewCustomerDto dto, IFormFile customerPhoto)
        {
            if (customerPhoto != null)
            {
                // ContentType : Dosyanın MIME TYPE'ını verir.
                // Length : Dosyanın büyüklüğünü verir (byte cinsinden verir)
                // FileName : Dosyanın adını verir (uzantısıyla birlikte)

                if (!customerPhoto.ContentType.StartsWith("image/"))
                    return Json(new { IsSuccess = false, Message = "Müşteri için sadece resim dosyası seçilmelidir." });

                if (customerPhoto.Length > 500 * 1024)
                    return Json(new { IsSuccess = false, Message = "Müşteri için seçilen resim dosyası maksimum 500 KB olabilir." });

                // MVC SUNUCUSUNA DOSYA UPLOAD
                //----------------------------------------------------------------
                // NOT : Dosyayı sunucudaki klasöre upload ederken dosyanın isminin unique bir değere sahip olduğundan emin olmak lazım çünkü klasörde aynı isimli dosya varsa onun üzerine yazacaktır. 

                // jpg
                // jpeg
                // bm
                // png
                // gif

                //"6F523896-2835-421D-A02A-59A21E8F7BE2.jpg"

                var randomFileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(customerPhoto.FileName)}";
                var picturePath = $@"/admin/customerImages/{randomFileName}";
                var uploadPath = $@"{_webHost.ContentRootPath}/wwwroot{picturePath}";

                using (var fs = new FileStream(uploadPath, FileMode.Create))
                {
                    customerPhoto.CopyTo(fs);
                }
                //----------------------------------------------------------------

                // WEB SERVICE ILE HABERLESME
                //--------------------------------------

                var postObj = new
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    City= dto.City,
                    Phone = dto.Phone,
                    PicturePath = picturePath,
                    PictureBase64 = Convert.ToBase64String(System.IO.File.ReadAllBytes(uploadPath))

                };

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5137/api");

                    var httpResponseMessage = await client.PostAsync($"{client.BaseAddress}/customers",
                      new StringContent(JsonSerializer.Serialize(postObj), System.Text.Encoding.UTF8, "application/json"));

                    var jsonResponse = await httpResponseMessage.Content.ReadAsStringAsync();

                    var response =
                      JsonSerializer.Deserialize<ResponseBody<CustomerItem>>(jsonResponse,
                      new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        return Json(new { IsSuccess = true, Message = "Müşteri Başarıyla Kaydedildi" });
                    }
                    else
                    {
                        return Json(new { IsSuccess = false, Messages = response.ErrorMessages });
                    }
                }

                //---------------------------------------

            }
            else
            {
                return Json(new { IsSuccess = false, Message = "Müşteri için dosya seçilmelidir." });
            }


        }

    }
}
