using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.EntityLayer.Concrete
{
    public class Category
    {
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public bool CategoryStatus { get; set; }
        public List<Product> Products { get; set; }
    }
}
