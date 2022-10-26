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
            var result = await _context.Discounts.Include(c => c.Candies).Include(c => c.CouponCodes).FirstOrDefaultAsync(d => d.Id == id);           
            return result;
        }

        public async Task<IEnumerable<Discount>> GetDiscounts()
        {
            return await _context.Discounts.Include(c => c.Candies).ToListAsync();
        }

        public async Task<Discount> UpdateDiscount(Discount discount)
        {
            var toUpdate = await GetDiscountById(discount.Id);
            if (toUpdate != null)
            {
                toUpdate.Name = discount.Name;
                toUpdate.StartDate = discount.StartDate;
                toUpdate.EndDate = discount.EndDate;
                toUpdate.Percentage = discount.Percentage;
                await _context.SaveChangesAsync();
                return toUpdate;
            }
            return null;
        }

        //TODO Is it possible to make this async? Not thread safe when tried from Admin Controller
        public CouponCode CreateCouponCode(CouponCode couponCode)
        {
            var result = _context.CouponCodes.Add(couponCode);
            _context.SaveChanges();
            return result.Entity;
        }

        public async Task<IEnumerable<CouponCode>> GetCouponCodes()
        {
            return _context.CouponCodes;
        }
    }

}
