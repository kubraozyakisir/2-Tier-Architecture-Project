using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Entity
{
    public class Order
    {
        public int OID { get; set; }    
        public int UserID { get; set; }
        public string UserAddress { get; set; }
        public DateTime CreateDate { get; set; }  
        public decimal TotalPrice { get; set; }
        public int Order_detay_id { get; set; }

    }
}
