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
        private static readonly Dictionary<string, decimal> CoinValues = new Dictionary<string, decimal>
        {
            ["1p"] = 0.01m,
            ["2p"] = 0.02m,
            ["5p"] = 0.05m,
            ["10p"] = 0.10m,
            ["20p"] = 0.20m,
            ["50p"] = 0.50m,
            ["£1"] = 1.00m,
            ["£2"] = 2.00m
        };

        public void Display()
        {
            if (!CanMakeChange())
            {
                Console.WriteLine("EXACT CHANGE ONLY");
            }
            else if (currentAmount == 0)
            {
                Console.WriteLine("INSERT COIN");
            }
            else
            {
                Console.WriteLine($"£{currentAmount:0.00}");
            }
        }

        public void ProcessInput(string input)
        {
            if (input == "return")
            {
                ReturnCoins();
                return;
            }

            var selectedProduct = inventory.Values.FirstOrDefault(p => p.Name == input);
            if (selectedProduct != null)
            {
                ProcessProductSelection(selectedProduct);
            }
            else if (CoinValues.ContainsKey(input))
            {
                AcceptCoin(input);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid coin or product.");
            }
        }

        private bool CanMakeChange()
        {
            foreach (var product in inventory.Values)
            {
                if (product.Quantity > 0 && currentAmount > product.Price)
                {
                    decimal change = currentAmount - product.Price;
                    if (HasSufficientChange(change))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool HasSufficientChange(decimal amount)
        {
            foreach (var coinValue in CoinValues.Values.OrderByDescending(v => v))
            {
                if (amount >= coinValue)
                {
                    int numberOfCoins = (int)(amount / coinValue);
                    amount -= numberOfCoins * coinValue;

                    if (amount == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void AcceptCoin(string coin)
        {
            if (CoinValues.TryGetValue(coin, out decimal coinValue))
            {
                currentAmount += coinValue;
                Display();
            }
        }

        private void ProcessProductSelection(Product product)
        {
            if (product.Quantity == 0)
            {
                Console.WriteLine("SOLD OUT");
            }
            else if (currentAmount >= product.Price)
            {
                if (currentAmount == product.Price)
                {
                    Console.WriteLine("Exact change received.");
                }
                else
                {
                    Console.WriteLine("Change dispensed.");
                }

                currentAmount -= product.Price;
                product.Dispense();
                Display();
                Console.WriteLine("THANK YOU");
            }
            else
            {
                Console.WriteLine($"PRICE £{product.Price:0.00}");
            }
        }

        private void ReturnCoins()
        {
            Console.WriteLine($"Returned: £{currentAmount:0.00}");
            currentAmount = 0;
            Display();
        }
    }
}