using Candy_SUT21.Models;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult EditDiscount(int candyId)
        {
            var candy = _candyRepository.GetCandyById(candyId);
            if (candy == null || candy.Discount == null)
                return NotFound();
            return View(candy);
        }
        //[HttpPost]
        //public IActionResult EditDiscount(Candy candy)
        //{

        //}
    }
}
