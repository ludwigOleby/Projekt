﻿using Candy_SUT21.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Candy_SUT21.ViewModels
{
    public class CandyViewModel
    {
        public int CandyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public bool IsOnSale { get; set; }
        public bool IsInStock => StockAmount > 0;
        public int StockAmount { get; set; }
        public int CategoryId { get; set; }
        public IFormFile FileImage { get; set; }
        public IFormFile FileImageThumbnail { get; set; }
    }
}
