using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Candy_SUT21.Models
{

    public class Candy
    {        
        public int CandyId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsOnSale
        {
            get
            {
                return Discount?.IsActive() == true;
            }
        }
#nullable enable
        public string? ImageUrl { get; set; }
        public string? ImageThumbnailUrl { get; set; }
        public int? DiscountId { get; set; }
        public Discount? Discount { get; set; }
#nullable disable
        public bool IsInStock => StockAmount > 0;
        public int StockAmount { get; set; }
        [Required(ErrorMessage = "You must select a category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public decimal GetDiscountPrice()
        {
            if (this.IsOnSale)
            {
                return Math.Round(this.Price - (this.Price * (Convert.ToDecimal(this.Discount.Percentage) / 100M)), 2);
            }
            return this.Price;
        }
    }

    
}
