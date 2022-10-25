using Candy_SUT21.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Candy_SUT21.ViewModels
{
    public class CandyCreateViewModel
    {  
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int StockAmount { get; set; }
        public int CategoryId { get; set; }
        public string CurrentCategory { get; set; }
        public IFormFile? FileImage { get; set; }
        public IFormFile? FileImageThumbnail { get; set; }
    }
}
