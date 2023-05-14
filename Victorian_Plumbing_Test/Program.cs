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
            IVendingMachine machine;

            var inventory = new List<Product>
            {
                new Product("cola", 1.00m),
                new Product("crisps", 0.50m),
                new Product("chocolate", 0.65m)
            };
            machine = new VendingMachine(inventory);
            machine.Display();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "quit")
                {
                    break;
                }
                machine.ProcessInput(input);
            }
        }
    }
}
