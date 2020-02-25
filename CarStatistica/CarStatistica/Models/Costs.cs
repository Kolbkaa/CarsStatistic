using System.Collections.Generic;

namespace CarStatistica.Models
{
    public class Costs
    {
        public int Id { get; set; }


        public Car Car { get; set; }

        public ICollection<Refueling> Refuelings { get; set; }
    }
}
