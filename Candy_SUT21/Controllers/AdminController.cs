using Candy_SUT21.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Candy_SUT21.Controllers
{
    public class AdminController : Controller
    {
        private readonly ICandyRepository _candyRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IOrderRepository _orderRepository;

        public AdminController(ICandyRepository candyRepository, ICategoryRepository categoryRepository, IOrderRepository orderRepository)
        {
            _candyRepository = candyRepository;
            _categoryRepository = categoryRepository;
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public IActionResult OrderManagement()
        {
            IEnumerable<Order> orders = _orderRepository.OrderList().OrderBy(o => o.OrderId);
            return View(orders);
        }


        public IActionResult Statistics()
        {
            return View();
        }
    }
}
