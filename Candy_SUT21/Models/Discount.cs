using System;
using System.Collections.Generic;

namespace Candy_SUT21.Models
{
    public class Discount
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Percentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IEnumerable<Candy> Candies { get; set; }

        public bool IsActive()
        {
            return StartDate >= DateTime.Now && EndDate <= DateTime.Now; 
        }
    }
}
