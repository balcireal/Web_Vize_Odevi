using Infrastructure.Model;

namespace FoodDelivery.Model.Dtos.Category
{
    public class CategoryPutDto : IDto
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
    }
}
