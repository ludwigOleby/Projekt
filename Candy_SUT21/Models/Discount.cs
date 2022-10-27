using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Candy_SUT21.Models
{
    public class Discount
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Discount name is required!")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Name must be more than 2 characters and less than 25!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Percentage is required!")]
        [Range(0, 100, ErrorMessage = "Percentage must be between 0 and 100!")]
        public int Percentage { get; set; }
        [Required(ErrorMessage="Start date is required!")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "End date is required!")]
        public DateTime EndDate { get; set; }
#nullable enable
        public IEnumerable<Candy>? Candies { get; set; }
        public IEnumerable<CouponCode>? CouponCodes { get; set; }
#nullable disable

        public bool IsActive()
        {
            return StartDate <= DateTime.Now && EndDate >= DateTime.Now; 
        }
    }
}
