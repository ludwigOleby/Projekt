using Candy_SUT21.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Candy_SUT21.ViewModels
{
    public class AddOrEditDiscountViewModel
    {
        
        public Discount Discount { get; set; }
        public IEnumerable<Candy> AllCandies { get; set; }
        public IEnumerable<Candy> CandiesNotInDiscount { get; set; }
        //public IEnumerable<Candy> selectInDiscount { get; set; }
        //public IEnumerable<Candy> selectNotInDiscount { get; set; }
        public AddOrEditDiscountViewModel()
        {

        }
        public AddOrEditDiscountViewModel(Discount discount, IEnumerable<Candy> allCandies)
        {
            Discount = discount;
            AllCandies = allCandies;
            CandiesNotInDiscount = allCandies.Except(discount.Candies);
        }

        public static void MoveItems()
        {

        }

    }
}
