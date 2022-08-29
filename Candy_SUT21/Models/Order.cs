using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candy_SUT21.Models
{
    public class Order
    {

        public int OrderId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string Phone { get; set; }
        public decimal OrderTotal { get; set; }
        public DateTime OrderPlaced { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }


    }
}
