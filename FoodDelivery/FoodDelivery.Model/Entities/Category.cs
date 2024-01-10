using Infrastructure.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodDelivery.Model.Entities
{
    public class Category : IEntity
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
        public byte[]? Picture { get; set; }
        public string? PicturePath { get; set; }


        [NotMapped] // bu propertynin veritabanındaki ilgili tabloyla bir alakası yok bunula ilgili birşey yapma çalışma
        public string Base64Picture
        {
            get
            {
                if (Picture != null)
                {
                    var base64Str = string.Empty;
                    using (var ms = new MemoryStream())
                    {
                        int offset =  0; 
                        ms.Write(Picture, offset, Picture.Length - offset);
                        var bmp = new System.Drawing.Bitmap(ms);
                        using (var jpegms = new MemoryStream())
                        {
                            bmp.Save(jpegms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            base64Str = Convert.ToBase64String(jpegms.ToArray());
                        }
                    }

                    return base64Str;
                }

                return string.Empty;
            }
        }


        public List<Product>? Products { get; set; }
    }
}
