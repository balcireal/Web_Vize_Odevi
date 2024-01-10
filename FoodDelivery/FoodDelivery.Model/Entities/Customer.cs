using Infrastructure.Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodDelivery.Model.Entities
{
    public class Customer : IEntity
    {
        public int CustomerId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public string? City { get; set; }
        public byte[]? Picture { get; set; }
        public string? PicturePath { get; set; }

        //[NotMapped]
        //public string? FullName
        //{
        //    get
        //    {
        //        return $"{FirstName} {LastName}";
        //    }
        //}

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
                        int offset = 0;
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


        public List<CustomerAddress>? CustomerAddresses { get; set; }
        public List<FoodOrder>? FoodOrders { get; set; }
    }
}
