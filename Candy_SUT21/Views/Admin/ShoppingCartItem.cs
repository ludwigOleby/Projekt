using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Candy_SUT21.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int ShoppingCartItemsId { get; set; }
        public string ShoppingCartId { get; set; }
        public Candy Candy { get; set; }
        public int Amount { get; set; }

    }
}
