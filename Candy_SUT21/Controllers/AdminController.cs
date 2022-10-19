﻿using Candy_SUT21.Models;
using Candy_SUT21.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Candy_SUT21.Controllers
{
    public class AdminController : Controller
    {
        private readonly ICandyRepository _candyRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IDiscountRepository _discountRepository;

        public AdminController(
            ICandyRepository candyRepository,
            ICategoryRepository categoryRepository,
            IOrderRepository orderRepository,
            IDiscountRepository discountRepository)
        {
            _candyRepository = candyRepository;
            _categoryRepository = categoryRepository;
            _orderRepository = orderRepository;
            _discountRepository = discountRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Discount()
        {
            var discounts = await _discountRepository.GetDiscounts();
            return View(discounts);
        }
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
        public async Task<IActionResult> DeleteDiscount(int discountId)
        {
            if (await _discountRepository.DeleteDiscount(discountId) == null)
                return NotFound();
            else
                return RedirectToAction(nameof(Discount));
        }
    }
}
