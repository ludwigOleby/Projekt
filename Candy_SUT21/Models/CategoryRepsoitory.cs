using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candy_SUT21.Models
{
    public class CategoryRepsoitory : ICategoryRepository
    {
        public IEnumerable<Category> GetAllCategory => new List<Category> 
        
        {
            new Category{ CategoryId = 1, CategoryName = "Hard Candy", CategoryDescription = "Awesome Hard Candy"},
            new Category{ CategoryId = 2, CategoryName = "Chocolate Candy", CategoryDescription = "Awesome Chocolate Candy"},
            new Category{ CategoryId = 3, CategoryName = "Fruit Candy", CategoryDescription = "Awesome Fruit Candy"},
        
        };
    }
}
