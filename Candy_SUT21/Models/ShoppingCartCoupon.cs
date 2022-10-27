namespace Candy_SUT21.Models
{
    public class ShoppingCartCoupon
    {
        public int ShoppingCartCouponId { get; set; }
        public string ShoppingCartId { get; set; }
        public int CouponCodeId { get; set; }
        public CouponCode CouponCode { get; set; }
    }
}
