using Candy_SUT21.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Candy_SUT21.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {

        private readonly IOrderRepository _orderRepository;
        private readonly ShoppingCart _shoppingCart;
        private readonly ICandyRepository _candyRepository;

        public OrderController(IOrderRepository orderRepository, ShoppingCart shoppingCart, ICandyRepository candyRepository)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
            _candyRepository = candyRepository;
        }

        public IActionResult CheckOut()
        {
            return View();
        }


        [HttpPost]
        public IActionResult CheckOut(Order order)
        {
            _shoppingCart.ShoppingCartItems = _shoppingCart.GetShoppingCartItems();

            if (_shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your Cart Is Empty");
            }

            if (ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);

                var shoppingCartItems = _shoppingCart.GetShoppingCartItems();


                foreach (var shoppigCartItem in shoppingCartItems)
                {
                    var orderDetails = new OrderDetail
                    {
                        Amount = shoppigCartItem.Amount,
                        Price = shoppigCartItem.Candy.Price,
                        CandyId = shoppigCartItem.Candy.CandyId,
                        OrderId = order.OrderId,
                    };
                    _candyRepository.DecreaseStock(orderDetails.CandyId, orderDetails.Amount);
                }


                _shoppingCart.ClearCart();

                return RedirectToAction("CheckoutComplete", new { id = order.OrderId });

            }

            return View(order);
        }

        public IActionResult CheckoutComplete(int id)
        {
            var order = _orderRepository.GetOrderDetails(id);
            return View(order);
        }

        public IActionResult OrderDetails(int id)
        {
            var order = _orderRepository.GetOrderDetails(id);
            return View(order);
        }

    }
}
