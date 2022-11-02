using Candy_SUT21.Models.Statistics;
using Candy_SUT21.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Candy_SUT21.Models
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly ShoppingCart _shoppingCart;
        private readonly WeatherApiService _weatherService;
        private readonly GeocodingApiService _geocodingService;

        public OrderRepository(AppDbContext appDbContext, ShoppingCart shoppingCart, WeatherApiService weatherService, GeocodingApiService geocodingService )
        {
            _appDbContext = appDbContext;
            _shoppingCart = shoppingCart;
            _weatherService = weatherService;
            _geocodingService = geocodingService;
        }


        public async Task CreateOrder(Order order)
        {
            order.OrderPlaced = DateTime.Now;
            order.OrderTotal = _shoppingCart.GetShoppingCartTotal();
            order.OrderDiscount = _shoppingCart.GetShoppingCartDiscount();
            _appDbContext.Orders.Add(order);

            await _appDbContext.SaveChangesAsync();


            //double lat = 56.65377;
            //double lon = 12.78671;
            var coordinates = await _geocodingService.GetCoordinatesByZipcodeAndCity(order.ZipCode, order.City);

            if (coordinates != null)
            {
                var orderWeather = await _weatherService.GetOrderWeatherByLatLon(coordinates[0], coordinates[1], order);

                if (orderWeather != null)
                {
                    _appDbContext.OrderWeathers.Add(orderWeather);
                }
            }






            var shoppingCartItems = _shoppingCart.GetShoppingCartItems();

            foreach (var shoppigCartItem in shoppingCartItems)
            {
                var orderDetails = new OrderDetail
                {
                    Amount = shoppigCartItem.Amount,

                    Price = shoppigCartItem.Candy.IsOnSale ?
                    shoppigCartItem.Candy.GetDiscountPrice() : 
                    shoppigCartItem.Candy.Price,
                    
                    CandyId = shoppigCartItem.Candy.CandyId,
                    OrderId = order.OrderId,
                };
               
                _appDbContext.OrderDetails.Add(orderDetails);
            }
            await _appDbContext.SaveChangesAsync();
        }


        public Order GetOrderDetails(int id)
        {
            var order = _appDbContext.Orders.Include(x => x.OrderDetails)
                .ThenInclude(x => x.Candy)
                .FirstOrDefault(x => x.OrderId == id);
            return order;
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserId(string userId)
        {
            var orders = await _appDbContext.Orders.Include(d => d.OrderDetails).Where(u => u.ApplicationUserId == userId).ToListAsync();
            return orders;
        }

        public IEnumerable<Order> GetOrdersByDate(DateTime from, DateTime? to)
        {
            if (to == null)
            {
                to = DateTime.Now;
            }

            return _appDbContext.Orders.Include(o => o.OrderDetails).ThenInclude(od=>od.Candy).Where(o => o.OrderPlaced > from & o.OrderPlaced < to);

        }

        public IEnumerable<Order> GetOrderWithWeatherByDate(DateTime from, DateTime? to)
        {
            if (to == null)
            {
                to = DateTime.Now;
            }

            return _appDbContext.Orders.Include(o => o.OrderWeather).Where(o => o.OrderPlaced > from & o.OrderPlaced < to);
        }

        public IEnumerable<Order> OrderList()
        {
            return _appDbContext.Orders.ToList();
        }
    }
}
