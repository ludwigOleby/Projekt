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

        public ShoppingCartController(ICandyRepository candyRepository , ShoppingCart shoppingCart)
        {
            _candyRepository = candyRepository;
            _shoppingCart = shoppingCart;
        }

        public IActionResult Index()
        {
            _shoppingCart.ShoppingCartItems = _shoppingCart.GetShoppingCartItems();
            var shoppigCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()

            };

            return View(shoppigCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int candyId)
        {
            var selectedCandy = _candyRepository.GetAllCandy.FirstOrDefault(c => c.CandyId == candyId);

            if (selectedCandy != null)
            {
                _shoppingCart.AddToCart(selectedCandy, 1);
            }
            return RedirectToAction("Index");


        }


        public RedirectToActionResult RemoveFromShoppingCart(int candyId)
        {
            var selectedCandy = _candyRepository.GetAllCandy.FirstOrDefault(c => c.CandyId == candyId);

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
    }
}
