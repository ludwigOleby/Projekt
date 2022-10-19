using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candy_SUT21.Models
{
    public class CategoryRepsoitory : ICategoryRepository
    {
        private readonly AppDbContext _appDbContext;

        public CategoryRepsoitory(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Category> GetAllCategory => _appDbContext.Categories;

        public Category GetCategoryById(int? categoryId)
        {
            return _appDbContext.Categories.FirstOrDefault(c => c.CategoryId == categoryId);
        }
    }
}
