using System.Collections.Generic;
using System.Threading.Tasks;

namespace Candy_SUT21.Models
{
    public interface IDiscountRepository
    {
        Task<IEnumerable<Discount>> GetDiscounts();
        Task<Discount> GetDiscountById(int id);
        Task<Discount> UpdateDiscount(Discount discount);
        Task<Discount> CreateDiscount(Discount discount);
        Task<Discount> DeleteDiscount(int id);
        CouponCode CreateCouponCode(CouponCode couponCode);
        Task<IEnumerable<CouponCode>> GetCouponCodes();
    }
}
