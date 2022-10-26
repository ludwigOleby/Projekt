namespace Candy_SUT21.Models
{
    public class CouponCode
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int DiscountId { get; set; }
        public Discount Discount { get; set; }
    }
}
