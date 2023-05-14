using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Victorian_Plumbing_Test
{
    public class VendingMachine : IVendingMachine
    {
        private decimal currentAmount;
        private Dictionary<string, Product> inventory;

        public VendingMachine(IEnumerable<Product> inventory)
        {
            currentAmount = 0;
            this.inventory = inventory.ToDictionary(p => p.Name, p => p);
        }

        public void Display()
        {
            Console.WriteLine(currentAmount == 0 ? "INSERT COIN" : $"£{currentAmount:0.00}");
        }

        public void ProcessInput(string input)
        {
            var coinValues = new Dictionary<string, decimal>
            {
                ["1p"] = 0.01m,
                ["2p"] = 0.02m,
                ["5p"] = 0.05m,
                ["10p"] = 0.10m,
                ["20p"] = 0.20m,
                ["50p"] = 0.50m,
                ["£1"] = 1.00m,
                ["£2"] = 2.00m,
            };

            var selectedProduct = inventory.Values.FirstOrDefault(p => p.Name == input);
            if (selectedProduct != null)
            {
                if (currentAmount >= selectedProduct.Price)
                {
                    currentAmount -= selectedProduct.Price;
                    selectedProduct.Dispense();
                    Display();
                    Console.WriteLine("THANK YOU");
                }
                else
                {
                    Console.WriteLine($"PRICE £{selectedProduct.Price:0.00}");
                }
            }
            else if (coinValues.ContainsKey(input))
            {
                currentAmount += coinValues[input];
                Display();
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid coin or product.");
            }
        }
    }
}