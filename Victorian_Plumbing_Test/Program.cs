using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Victorian_Plumbing_Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IVendingMachine vendingMachine;
            var products = new List<Product>
            {
                new Product("cola", 1.00m, 5),
                new Product("crisps", 0.50m, 10),
                new Product("chocolate", 0.65m, 3)
            };

            vendingMachine = new VendingMachine(products);
            vendingMachine.Display();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "quit")
                {
                    break;
                }
                vendingMachine.ProcessInput(input);
            }
        }
    }
}
