using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Candy_SUT21.Models
{
    public class DiscountRepository : IDiscountRepository
    {
        private readonly AppDbContext _context;
        public DiscountRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Discount> CreateDiscount(Discount discount)
        {
            var result = await _context.Discounts.AddAsync(discount);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Discount> DeleteDiscount(int id)
        {
            var toRemove = await GetDiscountById(id);
            if(toRemove != null)
            {
                var result = _context.Discounts.Remove(toRemove);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            return null;
        }

        public async Task<Discount> GetDiscountById(int id)
        {
            var result = await _context.Discounts.FirstOrDefaultAsync(d => d.Id == id);           
            if (result != null)
                return result;
            return null;
        }

        public async Task<IEnumerable<Discount>> GetDiscounts()
        {
            return await _context.Discounts.ToListAsync();
        }

        public async Task<Discount> UpdateDiscount(Discount discount)
        {
            if(GetDiscountById(discount.Id) != null)
            {
                var result = _context.Discounts.Update(discount);
                await _context.SaveChangesAsync();
                return result.Entity;
            }
            return null;
        }
    }
}
