using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Candy_SUT21.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int CandyId { get; set; }
        public Candy Candy { get; set; }

        public int Amount { get; set; }
        public decimal Price { get; set; }
    }
}
