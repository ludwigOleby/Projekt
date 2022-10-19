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
            DateTime today = DateTime.Today;

            if (period == "days")
            {
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

                var monday = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);
                var checkFrom = monday.AddDays(-21);

                var orders = _orderRepository.GetOrdersByDate(checkFrom, DateTime.Now);

                List<SalesAmountChartModel> data = new List<SalesAmountChartModel>()
                {
                    new SalesAmountChartModel { DateGroup = monday.AddDays(-21), Label ="Week "+ cul.Calendar.GetWeekOfYear(monday.AddDays(-21), CalendarWeekRule.FirstDay, DayOfWeek.Monday) },
                    new SalesAmountChartModel { DateGroup = monday.AddDays(-14), Label = "Week "+ cul.Calendar.GetWeekOfYear(monday.AddDays(-14), CalendarWeekRule.FirstDay, DayOfWeek.Monday) },
                    new SalesAmountChartModel { DateGroup = monday.AddDays(-7), Label = "Week "+ cul.Calendar.GetWeekOfYear(monday.AddDays(-7), CalendarWeekRule.FirstDay, DayOfWeek.Monday) },
                    new SalesAmountChartModel { DateGroup = monday, Label = "Week "+ cul.Calendar.GetWeekOfYear(monday, CalendarWeekRule.FirstDay, DayOfWeek.Monday)  }
                };

                foreach (var order in orders)
                {
                    var saleCategory = data.Find(s => cul.Calendar.GetWeekOfYear(s.DateGroup, CalendarWeekRule.FirstDay, DayOfWeek.Monday) == cul.Calendar.GetWeekOfYear(order.OrderPlaced.Date, CalendarWeekRule.FirstDay, DayOfWeek.Monday));
                    if (saleCategory != null)
                    {
                        saleCategory.OrderCount++;
                        saleCategory.ProductSalesCount += order.OrderDetails.Count;
                        saleCategory.SalesAmount += order.OrderTotal;
                    }
                }
                return Json(new { JSONList = data });

            }

            else if (period == "months")
            {
                var firstDayOfCurrMonth = today.AddDays(-(today.Day - 1));
                var orders = _orderRepository.GetOrdersByDate(firstDayOfCurrMonth.AddMonths(-5), DateTime.Now);

                List<SalesAmountChartModel> data = new List<SalesAmountChartModel>()
                {
                    new SalesAmountChartModel { DateGroup = firstDayOfCurrMonth.AddMonths(-5), Label = firstDayOfCurrMonth.AddMonths(-5).ToString("MMMM yyyy")},
                    new SalesAmountChartModel { DateGroup = firstDayOfCurrMonth.AddMonths(-4), Label = firstDayOfCurrMonth.AddMonths(-4).ToString("MMMM yyyy")},
                    new SalesAmountChartModel { DateGroup = firstDayOfCurrMonth.AddMonths(-3), Label = firstDayOfCurrMonth.AddMonths(-3).ToString("MMMM yyyy")},
                    new SalesAmountChartModel { DateGroup = firstDayOfCurrMonth.AddMonths(-2), Label = firstDayOfCurrMonth.AddMonths(-2).ToString("MMMM yyyy")},
                    new SalesAmountChartModel { DateGroup = firstDayOfCurrMonth.AddMonths(-1), Label = firstDayOfCurrMonth.AddMonths(-1).ToString("MMMM yyyy")},
                    new SalesAmountChartModel { DateGroup = firstDayOfCurrMonth, Label = firstDayOfCurrMonth.ToString("MMMM yyyy")},
                };

                foreach (var order in orders)
                {
                    var saleCategory = data.Find(s => s.DateGroup.Month == order.OrderPlaced.Date.Month);
                    if (saleCategory != null)
                    {
                        saleCategory.OrderCount++;
                        saleCategory.ProductSalesCount += order.OrderDetails.Count;
                        saleCategory.SalesAmount += order.OrderTotal;
                    }
                }
                return Json(new { JSONList = data });

            }
            return new JsonResult(null);
        }

        public JsonResult ProductSalesShare(string period = "days")
        {
            DateTime today = DateTime.Today;

            IEnumerable<Order> orders;
            string fromDate;

            if (period == "days")
            {
                fromDate = DateTime.Today.AddDays(-6).ToShortDateString();
                orders = _orderRepository.GetOrdersByDate(DateTime.Today.AddDays(-6), DateTime.Now);

            }

            else if (period == "weeks")
            {
                CultureInfo cul = CultureInfo.CurrentCulture;

                var monday = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);
                var checkFrom = monday.AddDays(-21);
                fromDate = checkFrom.ToShortDateString();

                orders = _orderRepository.GetOrdersByDate(checkFrom, DateTime.Now);


            }

            else if (period == "months")
            {
                var firstDayOfCurrMonth = today.AddDays(-(today.Day - 1));

                fromDate = firstDayOfCurrMonth.AddMonths(-5).ToShortDateString();
                orders = _orderRepository.GetOrdersByDate(firstDayOfCurrMonth.AddMonths(-5), DateTime.Now);

            }

            else
            {
                return new JsonResult(null);
            }

            var soldProducts = new List<ProductSalesShareChartModel>();

            foreach (var order in orders)
            {
                foreach (var orderDetail in order.OrderDetails)
                {
                    var sP = soldProducts.FirstOrDefault(s => s.ProductId == orderDetail.CandyId);
                    if (sP == null)
                    {
                        soldProducts.Add(new ProductSalesShareChartModel { ProductId = orderDetail.CandyId, ProductName = orderDetail.Candy.Name, SalesCount = orderDetail.Amount });
                    }
                    else
                    {
                        sP.SalesCount += orderDetail.Amount;
                    }
                }
            }
            return Json(new { JSONList = soldProducts, fromDate });

        }

    }
}
