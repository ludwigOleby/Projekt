using Candy_SUT21.Models;
using Candy_SUT21.Models.APIModels;
using System.Collections;
using System.Collections.Generic;

namespace Candy_SUT21.ViewModels
{
    public class OrderManagmentViewModel
    {
        public IEnumerable<Order> Order { get; set; }

        public string CurrencyName { get; set; }
        

        //public ExchangeRateApiModels ExchangeRateList { get; set; }

    }
}
