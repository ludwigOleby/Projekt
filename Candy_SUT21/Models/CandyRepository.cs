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

        public async Task<Candy> GetCandyById(int? candyId)
        {
            return await _appDbContext.Candies.Include(c => c.Category).Include(d => d.Discount).FirstOrDefaultAsync(c => c.CandyId == candyId);
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
        public async Task<Candy> CreateCandy(Candy candy)
        {
            var candyToCreate = await _appDbContext.Candies.AddAsync(candy);
            await _appDbContext.SaveChangesAsync();
            return candyToCreate.Entity;
        }

        public async Task<Candy> UpdateCandy(Candy candy)
        {
            var candyToUpdate = await _appDbContext.Candies.FirstOrDefaultAsync(c => c.CandyId == candy.CandyId);
            if(candyToUpdate != null)
            {
                candyToUpdate.Name = candy.Name;
                candyToUpdate.CategoryId = candy.CategoryId;
                candyToUpdate.Price = candy.Price;
                candyToUpdate.Description = candy.Description;
                candyToUpdate.ImageUrl = candy.ImageUrl;
                candyToUpdate.ImageThumbnailUrl = candy.ImageThumbnailUrl;
                candyToUpdate.StockAmount = candy.StockAmount;
                candyToUpdate.DiscountId = candy.DiscountId;
                
                await _appDbContext.SaveChangesAsync();
                return candyToUpdate;
            }
            return null;
        }

        public async Task<Candy> DeleteCandy(int candyId)
        {
            var candyToDelete = await _appDbContext.Candies.FirstOrDefaultAsync(c => c.CandyId == candyId);
            if(candyToDelete != null)
            {
                _appDbContext.Candies.Remove(candyToDelete);
                await _appDbContext.SaveChangesAsync();
                return candyToDelete;
            }
            return null;
        }

        public IEnumerable<Candy> GetCandiesWithStockUnder(int stockBelow)
        {
            return _appDbContext.Candies.Where(c => c.StockAmount < stockBelow);
        }
    }
}
