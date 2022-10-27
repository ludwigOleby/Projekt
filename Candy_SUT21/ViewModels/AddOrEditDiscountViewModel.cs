using Candy_SUT21.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Candy_SUT21.ViewModels
{
    public class AddOrEditDiscountViewModel
    {
        public int DiscountId { get; set; }
        [Required(ErrorMessage = "Discount name is required!")]
        [StringLength(25, MinimumLength = 2, ErrorMessage = "Name must be more than 2 characters and less than 25!")]
        public string DiscountName { get; set; }
        [Required(ErrorMessage = "Percentage is required!")]
        [Range(1, 100, ErrorMessage = "Percentage must be between 0 and 100!")]
        public int Percentage { get; set; }
        [Required(ErrorMessage = "Start date is required!")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "End date is required!")]
        public DateTime EndDate { get; set; }
        public IEnumerable<Candy> AllCandies { get; set; }
        public IEnumerable<Candy> CandiesInDiscount { get; set; }
        public IEnumerable<Candy> CandiesNotInDiscount { get; set; }
        public List<string> CouponCodes { get; set; }
        public AddOrEditDiscountViewModel()
        {
            
        }
    }
}
