using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candy_SUT21.Models
{
    public interface ICandyRepository
    {
        IEnumerable<Candy> GetAllCandy { get; }
        IEnumerable<Candy> GetCandiesWithStockUnder(int stockBelow);
        IEnumerable<Candy> GetCandyOnSale { get; }

        Task<Candy> GetCandyById(int? candyId);

        void DecreaseStock(int candyId, int amount);
        void AddStock(int candyId, int amount);
        Task <Candy> CreateCandy(Candy candy);
        Task <Candy> UpdateCandy (Candy candy);
        Task <Candy> DeleteCandy(int candyId);
    }
}
