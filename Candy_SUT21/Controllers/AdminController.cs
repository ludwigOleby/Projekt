using Candy_SUT21.Models;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Campaign()
        {
            return View();
        }
    }
}
