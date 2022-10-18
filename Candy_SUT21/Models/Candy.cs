using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candy_SUT21.Models
{

    public class Candy
    {
        public int CandyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public bool IsOnSale
        {
            get
            {
                return (Discount != null) &&
                    (Discount.StartDate < DateTime.Now &&
                    Discount.EndDate > DateTime.Now);
            }
        }      
#nullable enable
        public int? DiscountId { get; set; }
        public Discount? Discount { get; set; }
#nullable disable
        public bool IsInStock => StockAmount > 0;
        public int StockAmount { get; set; }
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
