using Candy_SUT21.Models;
using Candy_SUT21.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http;
using Candy_SUT21.Models.APIModels;
using System.Net.Http.Json;

namespace Candy_SUT21.Controllers
{
    public class AdminController : Controller
    {
        private readonly ICandyRepository _candyRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IDiscountRepository _discountRepository;
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminController(ICandyRepository candyRepository, ICategoryRepository categoryRepository, IOrderRepository orderRepository, IDiscountRepository discountRepository, IHttpClientFactory httpClientFactory)
        {
            _candyRepository = candyRepository;
            _categoryRepository = categoryRepository;
            _orderRepository = orderRepository;
            _discountRepository = discountRepository;
            _httpClientFactory = httpClientFactory;
        }
        

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> OrderManagement(string Currency = "SEK")
        {
            IEnumerable<Order> orders = _orderRepository.OrderList().OrderBy(o => o.OrderId);

            ExchangeRateApiModels exchangeRate;


            if (Currency != "SEK")
            {
                var request = new HttpRequestMessage(HttpMethod.Get, "https://api.exchangerate.host/convert?from=SEK&to=" + Currency);
                request.Headers.Add("Accept", "application/json");

                var client = _httpClientFactory.CreateClient();
                try
                {
                    var response = await client.SendAsync(request);

                    if (response.IsSuccessStatusCode)
                    {
                        exchangeRate = await response.Content.ReadFromJsonAsync<ExchangeRateApiModels>();

                        foreach (var order in orders)
                        {
                            var total = order.OrderTotal * Convert.ToDecimal(exchangeRate.info.rate);

                            order.OrderTotal = Math.Round(total, 2);
                        }

                        var OrderManagmentViewModel = new OrderManagmentViewModel
                        {
                            Order = orders,
                            CurrencyName = Currency,
                        };

                        return View(OrderManagmentViewModel);
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                catch (Exception)
                {
                    var OrderManagmentViewModel = new OrderManagmentViewModel
                    {
                        Order = orders,
                        CurrencyName = "SEK",
                        //ExchangeRateList = exchangeRateList
                    };

                    return View(OrderManagmentViewModel);
                }

            }
            else
            {
                var OrderManagmentViewModel = new OrderManagmentViewModel
                {
                    Order = orders,
                    CurrencyName = "SEK",
                    //ExchangeRateList = exchangeRateList
                };

                return View(OrderManagmentViewModel);
            }
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Statistics()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Discount()
        {
            var discounts = await _discountRepository.GetDiscounts();
            return View(discounts);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddOrEditDiscount(int? id)
        {
            var allCandies = _candyRepository.GetAllCandy;
            if(id == null)
            {
                return View(new AddOrEditDiscountViewModel(
                    new Discount {
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddMonths(1),
                        Candies = new List<Candy>()},
                     allCandies));
            }
            var discount = await _discountRepository.GetDiscountById((int)id);
            if(discount == null)
            {
                return NotFound();
            }
            return View(new AddOrEditDiscountViewModel( discount, allCandies ));
            
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddOrEditDiscount(AddOrEditDiscountViewModel discountVM)
        {
            if(ModelState.IsValid)
            {
                if (discountVM.Discount.Id == 0)
                {
                    await _discountRepository.CreateDiscount(discountVM.Discount);
                }
                else
                {
                    await _discountRepository.UpdateDiscount(discountVM.Discount);
                }
                return RedirectToAction("Discount");
            }                
            return View(discountVM);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteDiscount(int discountId)
        {
            if (await _discountRepository.DeleteDiscount(discountId) == null)
                return NotFound();
            else
                return RedirectToAction(nameof(Discount));
        }
    }
}
