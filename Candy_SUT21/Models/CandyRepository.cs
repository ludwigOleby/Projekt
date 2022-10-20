using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candy_SUT21.Models
{
    public class CandyRepository : ICandyRepository
    {
        private readonly AppDbContext _appDbContext;

        public CandyRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IEnumerable<Candy> GetAllCandy 
        
        {
            get
            {
                return _appDbContext.Candies.Include(c => c.Category ).Include(d => d.Discount);
            }
        }

        public IEnumerable<Candy> GetCandyOnSale
        {
            get
            {
                //return _appDbContext.Candies.Include(c => c.Category).Where(p => p.IsOnSale);
                var candies = _appDbContext.Candies.Include(c => c.Category).Include(d => d.Discount).Where(i => i.DiscountId != null).ToList();
                return candies.Where(s => s.IsOnSale);
            }
        }

        public Candy GetCandyById(int candyId)
        {
            return _appDbContext.Candies.FirstOrDefault(c => c.CandyId == candyId);
        }

        public void AddStock(int candyId, int amount)
        {
            var candyToDecrease = _appDbContext.Candies.FirstOrDefault(c => c.CandyId == candyId);
            candyToDecrease.StockAmount = candyToDecrease.StockAmount + amount;
            _appDbContext.Candies.Update(candyToDecrease);
        }
        public void DecreaseStock(int candyId, int amount)
        {
            var candyToDecrease = _appDbContext.Candies.FirstOrDefault(c => c.CandyId == candyId);
            candyToDecrease.StockAmount = candyToDecrease.StockAmount - amount;
            _appDbContext.Candies.Update(candyToDecrease);
        }

        public IEnumerable<Candy> GetCandiesWithStockUnder(int stockBelow)
        {
            return _appDbContext.Candies.Where(c => c.StockAmount < stockBelow);
        }
    }
}
