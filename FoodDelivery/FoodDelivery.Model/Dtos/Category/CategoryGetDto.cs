﻿using Infrastructure.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDelivery.Model.Dtos.Category
{
    public class CategoryGetDto : IDto
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
        public string CategoryPicture { get; set; }
        public string? PicturePath { get; set; }

    }
}
