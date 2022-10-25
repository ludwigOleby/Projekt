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
    }
}
