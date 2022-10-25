using Candy_SUT21.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Candy_SUT21.ViewModels
{
    public class AddOrEditDiscountViewModel
    {
        //TODO Add validatioN!!!!!
        public int DiscountId { get; set; }
        public string DiscountName { get; set; }
        public int Percentage { get; set; }
        public DateTime StartDate { get; set; }
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
