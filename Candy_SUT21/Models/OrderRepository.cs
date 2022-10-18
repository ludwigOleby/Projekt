using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candy_SUT21.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ShoppingCart _shoppingCart;

        public OrderRepository(AppDbContext appDbContext, ShoppingCart shoppingCart)
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
        }


        public void CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();
            _appDbContext.Orders.Add(order);
            


            _appDbContext.SaveChanges();

           var shoppingCartItems = _shoppingCart.GetShoppingCartItems();


            foreach (var shoppigCartItem in shoppingCartItems)
            {
                var orderDetails = new OrderDetail
                {
                      Amount = shoppigCartItem.Amount,
                      Price = shoppigCartItem.Candy.Price,
                      CandyId = shoppigCartItem.Candy.CandyId,
                      OrderId = order.OrderId,
                };

                _appDbContext.OrderDetails.Add(orderDetails);
            }
            _appDbContext.SaveChanges();
        }

        public IEnumerable<Order> OrderList()
        {
            return _appDbContext.Orders.ToList();
        }
    }
}
