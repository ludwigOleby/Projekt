using Candy_SUT21.Models;
using Candy_SUT21.Models.Statistics;
using Candy_SUT21.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Candy_SUT21.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICandyRepository _candyRepository;
        private readonly IOrderRepository _orderRepository;

        public HomeController(ICandyRepository candyRepository, IOrderRepository orderRepository)
        {
            _candyRepository = candyRepository;
            _orderRepository = orderRepository;

        }

        public async Task<IActionResult> Index()
        {

            List<Candy> bestSellingCandies = new List<Candy>();

            IEnumerable<Order> orders = _orderRepository.GetOrdersByDate(DateTime.Today.AddDays(-6), DateTime.Now);

            if (orders != null)
            {
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

                soldProducts = soldProducts.OrderByDescending(s => s.SalesCount).ToList();


                if (soldProducts.Count > 0)
                {
                    bestSellingCandies.Add(await _candyRepository.GetCandyById(soldProducts[0].ProductId));
                    if (soldProducts.Count > 1)
                    {
                        bestSellingCandies.Add(await _candyRepository.GetCandyById(soldProducts[1].ProductId));
                        if (soldProducts.Count > 2) bestSellingCandies.Add(await _candyRepository.GetCandyById(soldProducts[2].ProductId));
                    }
                }

            }


            var homeViewModel = new HomeViewModel
            {
                CandyOnSale = _candyRepository.GetCandyOnSale,
                BestSelling = bestSellingCandies
            };



            return View(homeViewModel);
        }
        public IActionResult OnSale()
        {
            var homeViewModel = new HomeViewModel
            {
                CandyOnSale = _candyRepository.GetCandyOnSale
            };
            return View(homeViewModel);
        }


    }
}
