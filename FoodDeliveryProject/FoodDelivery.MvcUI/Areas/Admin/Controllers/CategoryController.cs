using FoodDelivery.MvcUI.Areas.Admin.Extensions;
using FoodDelivery.MvcUI.Areas.Admin.Filters;
using FoodDelivery.MvcUI.Areas.Admin.HttpApiServices;
using FoodDelivery.MvcUI.Areas.Admin.Models;
using FoodDelivery.MvcUI.Areas.Admin.Models.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FoodDelivery.MvcUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [SessionAspect]
    public class CategoryController : Controller
    {
        private readonly IWebHostEnvironment _webHost;
        private readonly IHttpApiService _httpApiService;

        public CategoryController(IWebHostEnvironment webHost, IHttpApiService httpApiService)
        {
            _webHost = webHost;
            _httpApiService = httpApiService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var token = HttpContext.Session.GetObject<AccessTokenItem>("AccessToken");

            var response = await _httpApiService.GetData<ResponseBody<List<CategoryItem>>>("/categories",token.Token);

            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> GetCategory(int id)
        {
            var response =
              await _httpApiService.GetData<ResponseBody<CategoryItem>>($"/categories/{id}");

            return Json(new { CategoryName = response.Data.CategoryName, Description = response.Data.Description, PicturePath = response.Data.PicturePath });
        }

        [HttpPost]
        public async Task<IActionResult> Save(NewCategoryDto dto, IFormFile categoryPhoto)
        {
            if (categoryPhoto != null)
            {
                // ContentType : Dosyanın MIME TYPE'ını verir.
                // Length : Dosyanın büyüklüğünü verir (byte cinsinden verir)
                // FileName : Dosyanın adını verir (uzantısıyla birlikte)

                if (!categoryPhoto.ContentType.StartsWith("image/"))
                    return Json(new { IsSuccess = false, Message = "Kategori için sadece resim dosyası seçilmelidir." });

                if (categoryPhoto.Length > 500 * 1024)
                    return Json(new { IsSuccess = false, Message = "Kategori için seçilen resim dosyası maksimum 500 KB olabilir." });

                // MVC SUNUCUSUNA DOSYA UPLOAD
                //----------------------------------------------------------------
                // NOT : Dosyayı sunucudaki klasöre upload ederken dosyanın isminin unique bir değere sahip olduğundan emin olmak lazım çünkü klasörde aynı isimli dosya varsa onun üzerine yazacaktır. 

                // jpg
                // jpeg
                // bm
                // png
                // gif

                //"6F523896-2835-421D-A02A-59A21E8F7BE2.jpg"

                var randomFileName = $"{Guid.NewGuid().ToString()}{Path.GetExtension(categoryPhoto.FileName)}";
                var picturePath = $@"/admin/categoryImages/{randomFileName}";
                var uploadPath = $@"{_webHost.ContentRootPath}/wwwroot{picturePath}";

                using (var fs = new FileStream(uploadPath, FileMode.Create))
                {
                    categoryPhoto.CopyTo(fs);
                }
                //----------------------------------------------------------------

                // WEB SERVICE ILE HABERLESME
                //--------------------------------------

                var postObj = new
                {
                    CategoryName = dto.CategoryName,
                    Description = dto.Description,
                    PicturePath = picturePath,
                    PictureBase64 = Convert.ToBase64String(System.IO.File.ReadAllBytes(uploadPath))
                };

                var response = await _httpApiService.PostData<ResponseBody<CategoryItem>>("/categories", JsonSerializer.Serialize(postObj));


                if (response.StatusCode == 201)
                {
                    return Json(
                      new
                      {
                          IsSuccess = true,
                          Message = "Kategori Başarıyla Kaydedildi",
                          CategoryPicture = response.Data.CategoryPicture,
                          PicturePath = response.Data.PicturePath,
                          CategoryId = response.Data.CategoryId
                      });
                }
                else
                {
                    return Json(new { IsSuccess = false, Messages = response.ErrorMessages });
                }


            }
            else
            {
                return Json(new { IsSuccess = false, Message = "Kategori için dosya seçilmelidir." });
            }


        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _httpApiService.DeleteData<ResponseBody<NoData>>($"/categories/{id}");

            if (response.StatusCode == 200)
                return Json(new { IsSuccess = true, Message = "Kayıt Başarıyla Silindi" });

            return Json(new { IsSuccess = false, Message = "Kayıt Silinemedi", ErrorMessages = response.ErrorMessages });
        }

    }
}

