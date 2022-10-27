using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candy_SUT21.Models
{
    public interface IOrderRepository
    {
        Task CreateOrder(Order order);
        IEnumerable<Order> GetOrderWithWeatherByDate(DateTime from, DateTime? to);

        Order GetOrderDetails(int id);


        IEnumerable<Order> GetOrdersByDate(DateTime from, DateTime? to);


        IEnumerable<Order> OrderList();
    }
}
