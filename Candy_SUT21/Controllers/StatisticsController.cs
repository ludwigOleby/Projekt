using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Candy_SUT21.Models;
using Candy_SUT21.Models.Statistics;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace Candy_SUT21.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IOrderRepository _orderRepository;

        public StatisticsController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public JsonResult SalesAmount(string period = "days")
        {

            if (period == "days")
            {
                DateTime today = DateTime.Today;
                var orders = _orderRepository.GetOrdersByDate(DateTime.Today.AddDays(-6), DateTime.Now);

                List<SalesAmountChartModel> data = new List<SalesAmountChartModel>()
                {
                    new SalesAmountChartModel { DateGroup = today.AddDays(-6), Label = today.AddDays(-6).ToShortDateString() },
                    new SalesAmountChartModel { DateGroup = today.AddDays(-5), Label = today.AddDays(-5).ToShortDateString() },
                    new SalesAmountChartModel { DateGroup = today.AddDays(-4), Label = today.AddDays(-4).ToShortDateString() },
                    new SalesAmountChartModel { DateGroup = today.AddDays(-3), Label = today.AddDays(-3).ToShortDateString() },
                    new SalesAmountChartModel { DateGroup = today.AddDays(-2), Label = today.AddDays(-2).ToShortDateString() },
                    new SalesAmountChartModel { DateGroup = today.AddDays(-1), Label = today.AddDays(-1).ToShortDateString() },
                    new SalesAmountChartModel { DateGroup = today, Label=today.ToShortDateString() } 
                };




                foreach (var order in orders)
                {
                    var saleCategory = data.Find(s => s.DateGroup == order.OrderPlaced.Date);
                    if(saleCategory!=null)
                    {
                        saleCategory.OrderCount++;
                        saleCategory.ProductSalesCount += order.OrderDetails.Count;
                        saleCategory.SalesAmount += order.OrderTotal;

                    }                  

                }

                return Json(new { JSONList = data });

            }

            else if (period == "weeks")
            {


                CultureInfo cul = CultureInfo.CurrentCulture;

                int currentWeek = cul.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);


                //var orders = _orderRepository.GetOrdersByDate(DateTime.Today.add(-7), DateTime.Now);
            }

            else if (period == "months")
            {
                var orders = _orderRepository.GetOrdersByDate(DateTime.Today.AddMonths(-5), DateTime.Now);
            }



            return new JsonResult(null);



        }

    }
}
