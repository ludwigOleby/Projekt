﻿using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candy_SUT21.Models
{
    public class ShoppingCart
    {
        private readonly AppDbContext _appDbContext;

        public string ShoppingCartID { get; set; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public ShoppingCart(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContext>();

            string cartId = session.GetString("CartID") ?? Guid.NewGuid().ToString();
            session.SetString("CartID", cartId);

            return new ShoppingCart(context) { ShoppingCartID = cartId };
        }


        public void AddToCart(Candy candy , int amount)
        {
            var ShoppingCartItem = _appDbContext.ShoppingCartItems.SingleOrDefault(c => c.Candy.CandyId == candy.CandyId
            && c.ShoppingCartId == ShoppingCartID);

            if (ShoppingCartItem == null)
            {
                ShoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartID,
                    Candy = candy,
                    Amount = amount
                };
                _appDbContext.ShoppingCartItems.Add(ShoppingCartItem);
            }

            else
            {
                ShoppingCartItem.Amount++;
            }
            _appDbContext.SaveChanges();
        }

        public int RemoveFromCart(Candy candy)
        {
            var ShoppingCartItem = _appDbContext.ShoppingCartItems.SingleOrDefault(c => c.Candy.CandyId == candy.CandyId
            && c.ShoppingCartId == ShoppingCartID);

            var localAmount = 0;

            if (ShoppingCartItem != null)
            {
                if (ShoppingCartItem.Amount > 1)
                {
                    ShoppingCartItem.Amount--;
                    localAmount = ShoppingCartItem.Amount;
                }
                else
                {
                    _appDbContext.ShoppingCartItems.Remove(ShoppingCartItem);
                }
            }

            _appDbContext.SaveChanges();
            return localAmount;
        }


        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ?? (ShoppingCartItems = _appDbContext.ShoppingCartItems.
                Where(c => c.ShoppingCartId == ShoppingCartID).
                Include(s => s.Candy).ThenInclude(d => d.Discount).ToList());
        }


        public void ClearCart()
        {
            var cartItems = _appDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartID);
            _appDbContext.ShoppingCartItems.RemoveRange(cartItems);
            _appDbContext.SaveChanges();
        }


        public decimal GetShoppingCartTotal()
        {         
            var items = _appDbContext.ShoppingCartItems.
                Where(c => c.ShoppingCartId == ShoppingCartID).
                Include(c => c.Candy).
                ThenInclude(d => d.Discount).ToList();

            var ordinary = items.Where(s => !s.Candy.IsOnSale).
                Select(c => c.Candy.Price * c.Amount).Sum();

            var discount = items.Where(s => s.Candy.IsOnSale).
                Select(c => c.Candy.GetDiscountPrice() * c.Amount).Sum();

            var total = ordinary + discount;

            return total;
        }
        public decimal GetShoppingCartDiscount()
        {
            var items = _appDbContext.ShoppingCartItems.
                Where(c => c.ShoppingCartId == ShoppingCartID && c.Candy.DiscountId != null).
                Include(c => c.Candy).
                ThenInclude(d => d.Discount).ToList();

            var discount = items.Where(s => s.Candy.IsOnSale).
                Sum(d => (d.Candy.Price - d.Candy.GetDiscountPrice()) * d.Amount);
           
            return discount;
        }

    }
}
