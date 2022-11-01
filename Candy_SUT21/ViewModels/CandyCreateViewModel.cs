using Candy_SUT21.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Candy_SUT21.ViewModels
{
    public class CandyCreateViewModel
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Price is required!")]
        [Range(0.01, double.MaxValue, ErrorMessage = "The price must be more than zero!")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Stockamount is required!")]
        [Range(0, 10000, ErrorMessage = "The stock amount must be between 0 and 10 000!")]
        public int StockAmount { get; set; }
        [Required(ErrorMessage = "Category is required!")]
        public int CategoryId { get; set; }

#nullable enable
        public string? CurrentCategory { get; set; }
        public int? DiscountId { get; set; }
        public string? CurrentDiscount { get; set; }
        public IEnumerable<Discount>? Discounts { get; set; }
        public IFormFile? FileImage { get; set; }
        public IFormFile? FileImageThumbnail { get; set; }
#nullable disable
    }
}
