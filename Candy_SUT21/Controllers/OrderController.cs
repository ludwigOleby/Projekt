using Candy_SUT21.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ICustomerRepository _customerRepository;

        public OrderController(IOrderRepository orderRepository,
            ShoppingCart shoppingCart,
            ICandyRepository candyRepository,
            UserManager<ApplicationUser> userManager,
            ICustomerRepository customerRepository)
        {
            _orderRepository = orderRepository;
            _shoppingCart = shoppingCart;
            _candyRepository = candyRepository;
            _userManager = userManager;
            _customerRepository = customerRepository;
        }

        public async Task<IActionResult> CheckOut()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user.CustomerId != null)
            {
                user.Customer = await _customerRepository.GetCustomerById((int)user.CustomerId);
                var order = new Order
                {
                    FirstName = user.Customer.FirstName,
                    LastName = user.Customer.LastName,
                    Address = user.Customer.Address,
                    City = user.Customer.City,
                    ZipCode = user.Customer.ZipCode,
                    Phone = user.Customer.Phone,
                    ApplicationUserId = user.Id

                };
                return View(order);
            }
            return View(new Order{ApplicationUserId = user.Id});
            
            
        }


        [HttpPost]
        public async Task<IActionResult> CheckOut(Order order)
        {
            _shoppingCart.ShoppingCartItems = _shoppingCart.GetShoppingCartItems();

            if (_shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your Cart Is Empty");
            }

            if (ModelState.IsValid)
            {
                await _orderRepository.CreateOrder(order);


                var shoppingCartItems = _shoppingCart.GetShoppingCartItems();

                foreach (var shoppigCartItem in shoppingCartItems)
                {
                    _candyRepository.DecreaseStock(shoppigCartItem.Candy.CandyId, shoppigCartItem.Amount);
                }

                _shoppingCart.ClearCart();

                return RedirectToAction("CheckoutComplete", new { id = order.OrderId });
            }

            return View(order);
        }

        public async Task<IActionResult> CheckoutComplete(int id)
        {
            var order = _orderRepository.GetOrderDetails(id);
            var user = await _userManager.GetUserAsync(User);

            if (order!=null && order.ApplicationUserId == user.Id)
            {
                return View(order);
            }

            return View("OrderError");


        }

        public async Task<IActionResult> OrderDetails(int id)
        {
            var order = _orderRepository.GetOrderDetails(id);
            var user = await _userManager.GetUserAsync(User);


            if (order != null && (order.ApplicationUserId == user.Id | User.IsInRole("Admin")))
            {
                return View(order);
            }

            return View("OrderError");

        }

        public async Task<IActionResult> OrderHistory()
        {
            var user = await _userManager.GetUserAsync(User);
            var orders = await _orderRepository.GetOrdersByUserId(user.Id);
            return View(orders);
        }


    }
}
