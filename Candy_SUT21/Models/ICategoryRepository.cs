using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candy_SUT21.Models
{
   public interface ICategoryRepository
    {
        IEnumerable<Category> GetAllCategory { get; }
    }
}
