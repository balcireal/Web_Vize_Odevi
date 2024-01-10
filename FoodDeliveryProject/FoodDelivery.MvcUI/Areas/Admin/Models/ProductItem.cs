namespace FoodDelivery.MvcUI.Areas.Admin.Models
{

    public class ProductItem
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public decimal Price { get; set; }
       
        public string? ProductPicture { get; set; }
        public string? PicturePath { get; set; }
    }
}
