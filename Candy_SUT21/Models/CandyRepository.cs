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
                return _appDbContext.Candies.Include(c => c.Category );
            }
        }

        public IEnumerable<Candy> GetCandyOnSale
        {
            get
            {
                return _appDbContext.Candies.Include(c => c.Category).Where(p => p.IsOnSale);
            }
        }

        public Candy GetCandyById(int? candyId)
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
        public void CreateCandy(Candy candy)
        {
            var candyToCreate = _appDbContext.Candies.Add(candy);
            _appDbContext.SaveChanges();            
        }

        public Candy UpdateCandy(Candy candy)
        {
            var candyToUpdate = _appDbContext.Candies.FirstOrDefault(c => c.CandyId == candy.CandyId);
            if(candyToUpdate != null)
            {
                candyToUpdate.Name = candy.Name;
                candyToUpdate.CategoryId = candy.CategoryId;
                candyToUpdate.Price = candy.Price;
                candyToUpdate.Description = candy.Description;
                candyToUpdate.ImageUrl = candy.ImageUrl;
                candyToUpdate.ImageThumbnailUrl = candy.ImageThumbnailUrl;
                candyToUpdate.StockAmount = candy.StockAmount;
                candyToUpdate.IsOnSale = candy.IsOnSale;

                _appDbContext.SaveChanges();
                return candyToUpdate;
            }
            return null;
        }
    }
}
