using Infrastructure.Model;

namespace FoodDelivery.Model.Dtos.Category
{
    public class CategoryPostDto : IDto
    {
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
        public string? PictureBase64 { get; set; }
        public string? PicturePath { get; set; }

    }
}
