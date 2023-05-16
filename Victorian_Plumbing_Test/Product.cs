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
        public int Quantity { get; private set; }

        public Product(string name, decimal price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public void Dispense()
        {
            Console.WriteLine("Dispensing {0}", Name);
            Quantity--;
        }
    }
}
