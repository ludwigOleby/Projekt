﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candy_SUT21.Models
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);

        IEnumerable<Order> GetOrdersByDate(DateTime from, DateTime? to);

        IEnumerable<Order> OrderList();
    }
}
