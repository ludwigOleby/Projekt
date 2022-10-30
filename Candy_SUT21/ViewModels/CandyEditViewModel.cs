using Candy_SUT21.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Candy_SUT21.ViewModels
{
    public class CandyEditViewModel 
    {
        public int CandyId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage ="Price is required!")]
        [Range(0.01, double.MaxValue, ErrorMessage ="The price must be more than zero!")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Stockamount is required!")]
        [Range(0, 10000, ErrorMessage = "The maximum stock amount is 10 000!")]
        public int StockAmount { get; set; }
        [Required(ErrorMessage = "Category is required!")]
        public int CategoryId { get; set; }
        public string? CurrentCategory { get; set; }
        public int? DiscountId { get; set; }
        public string? CurrentDiscount { get; set; }
        public IEnumerable<Discount>? Discounts { get; set; }
        public IFormFile? FileImage { get; set; }
        public IFormFile? FileImageThumbnail { get; set; }
        public string ExistingImagePath { get; set; }
        public string ExistingImageThumbnailPath { get; set; }   
    }
}
