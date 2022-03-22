using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Entity
{
    public class EProduct
    {
        public int PID { get; set; }
        public string PName { get; set; }
        public int CategoryID { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string PDescription { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
