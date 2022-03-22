using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Entity
{
    public class Category
    {
        public int CID { get; set; } 
        public int ParentID { get; set; }
        public string  Name { get; set; }
        public  bool IsActive { get; set; } 

    }
}
