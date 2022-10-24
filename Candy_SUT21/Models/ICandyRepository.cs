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

        Candy GetCandyById(int? candyId);

        void DecreaseStock(int candyId, int amount);
        void AddStock(int candyId, int amount);
        void CreateCandy(Candy candy);
        Candy UpdateCandy (Candy candy);
        Candy DeleteCandy(int candyId);
    }
}
