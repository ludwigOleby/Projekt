using Candy_SUT21.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Candy_SUT21.Components
{
    public class DiscountOptionViewComponent : ViewComponent
    {
        private readonly IDiscountRepository _discountRepository;

        public DiscountOptionViewComponent(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var discounts = await _discountRepository.GetDiscounts();

            return View(discounts);
        }
    }
}
