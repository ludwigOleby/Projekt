using Candy_SUT21.Models;
using Candy_SUT21.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candy_SUT21.Controllers
{
    public class ShoppingCartController : Controller
    {

        private readonly ICandyRepository _candyRepository;
        private readonly ShoppingCart _shoppingCart;
        private readonly IDiscountRepository _discountRepository;

        public ShoppingCartController(ICandyRepository candyRepository,
            ShoppingCart shoppingCart,
            IDiscountRepository discountRepository)
        {
            _candyRepository = candyRepository;
            _shoppingCart = shoppingCart;
            _discountRepository = discountRepository;
        }

        public IActionResult Index()
        { 
            _shoppingCart.ShoppingCartItems = _shoppingCart.GetShoppingCartItems();
            var shoppigCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal(),
                ShoppingCartDiscount = _shoppingCart.GetShoppingCartDiscount(),
                CouponCode = _shoppingCart.GetCouponCode()
            };
            return View(shoppigCartViewModel);
        }

        public async Task<RedirectToActionResult> AddToShoppingCart(int candyId)
        {
            var candies = await _candyRepository.GetAllCandy();
            var selectedCandy = candies.FirstOrDefault(c => c.CandyId == candyId);

            if (selectedCandy != null)
            {
                _shoppingCart.AddToCart(selectedCandy, 1);
            }
            return RedirectToAction("Index");
        }


        public async Task<RedirectToActionResult> RemoveFromShoppingCart(int candyId)
        {
            var candies = await _candyRepository.GetAllCandy();
            var selectedCandy = candies.FirstOrDefault(c => c.CandyId == candyId);

            if (selectedCandy != null)
            {
                _shoppingCart.RemoveFromCart(selectedCandy);
            }

            return RedirectToAction("Index");

        }

        public RedirectToActionResult ClearCart()
        {
            _shoppingCart.ClearCart();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> AddCouponCode(string codeInput)
        {
            var couponCodes = await _discountRepository.GetCouponCodes();
            if (couponCodes != null)
            {
                var result = couponCodes.FirstOrDefault(c => c.Code == codeInput);
                if (result != null)
                {
                    _shoppingCart.AddCouponCode(result.Id);
                }
                else
                    TempData["CouponError"] = "Coupon-Code is invalid!";
            }
            else
                TempData["CouponError"] = "Unable to register Coupon-Codes at the moment!";

            return RedirectToAction(nameof(Index));
        }
    }
}
