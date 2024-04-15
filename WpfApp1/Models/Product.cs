using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Models
{
    class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public Product(string name, string category, double prince)
        {
            this.Name = name;
            this.Category = category;
            this.Price = prince;
            this.Quantity = 1;
        }
    }
}
