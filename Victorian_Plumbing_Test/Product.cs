using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Victorian_Plumbing_Test
{
    public class Product
    {
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
        public void Dispense()
        {
            Console.WriteLine("Dispensing {0}", Name);
        }
    }
}
