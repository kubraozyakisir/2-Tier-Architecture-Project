using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Entity
{
    public class Order_detail
    {
        public int OrderDetayID { get; set; }
        public int ProductID { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal Number { get; set; }
        public int UserID { get; set; }
    }
}
