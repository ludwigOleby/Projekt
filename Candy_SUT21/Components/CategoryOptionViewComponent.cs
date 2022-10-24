using Candy_SUT21.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Candy_SUT21.Components
{
    public class CategoryOptionViewComponent : ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryOptionViewComponent(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryRepository.GetAllCategory.OrderBy(c => c.CategoryName);

            return View(categories);
        }
    }
}
