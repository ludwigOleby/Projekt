using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candy_SUT21.Models.Statistics
{
    public class SalesAmountChartModel
    {
        public string Label { get; set; }
        public DateTime DateGroup { get; set; }
        public Decimal SalesAmount { get; set; }
        public int ProductSalesCount { get; set; }
        public int OrderCount { get; set; }
    }
}
