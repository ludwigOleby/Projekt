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
            var allCandies = await _candyRepository.GetAllCandy();
            if(id == null)
            {
                return View(new AddOrEditDiscountViewModel
                {
                    StartDate = DateTime.Now,
                    EndDate = DateTime.Now.AddMonths(1),
                    AllCandies = allCandies,
                    CandiesInDiscount = new List<Candy>(),
                    CandiesNotInDiscount = allCandies,
                    CouponCodes = new List<string>()
                });
            }
            var discount = await _discountRepository.GetDiscountById((int)id);
            if(discount == null)
            {
                return NotFound();
            }
            return View(new AddOrEditDiscountViewModel
            {
                DiscountId = discount.Id,
                DiscountName = discount.Name,
                Percentage = discount.Percentage,
                StartDate = discount.StartDate,
                EndDate = discount.EndDate,
                AllCandies = allCandies,
                CouponCodes = discount.CouponCodes?.Select(c => c.Code).ToList(),
                CandiesInDiscount = discount.Candies,
                CandiesNotInDiscount = allCandies.Except(discount.Candies)
            });
            
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddOrEditDiscount(AddOrEditDiscountViewModel discountVM)
        {
            if(ModelState.IsValid)
            {
                var discount = new Discount
                {
                    Id = discountVM.DiscountId,
                    Name = discountVM.DiscountName,
                    StartDate = discountVM.StartDate,
                    EndDate = discountVM.EndDate,
                    Percentage = discountVM.Percentage                
                };
                if (discountVM.DiscountId == 0)
                {
                    if(discountVM.CouponCodes != null && discountVM.CouponCodes.Count > 0)
                    {
                        var couponCodes = new List<CouponCode>();
                        discountVM.CouponCodes.ForEach(c => couponCodes.Add(new CouponCode { Code = c }));
                        discount.CouponCodes = couponCodes;
                    }                   
                    var newDiscount = await _discountRepository.CreateDiscount(discount);
                }
                else
                {
                    var result = await _discountRepository.UpdateDiscount(discount);
                    if (discountVM.CouponCodes != null && discountVM.CouponCodes.Count >= 0)
                    {
                        //Deletes the removed couponCodes from DB 
                        var removedCodes = result.CouponCodes.Select(c => c.Code).Except(discountVM.CouponCodes);
                        var toDelete = result.CouponCodes.Where(c => removedCodes.Contains(c.Code)).ToList();
                        toDelete.ForEach(c => _discountRepository.DeleteCouponCode(c.Id));

                        //Adds new couponCodes to DB
                        var newCodes = discountVM.CouponCodes.Except(result.CouponCodes.Select(c => c.Code)).ToList();
                        if(newCodes != null && newCodes.Count > 0)
                        {
                            newCodes.ForEach(c =>
                            _discountRepository.CreateCouponCode(
                                new CouponCode { Code = c, DiscountId = result.Id }));
                        }
                    }
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
