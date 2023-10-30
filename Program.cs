namespace Shopping_Lab;

using System;
using System.Linq;

class Program
{
    static void Main()
    {
        Dictionary<string, decimal> menu = new Dictionary<string, decimal>
        {
            { "a", 0.99m },
            { "b", 0.59m },
            { "c", 1.59m },
            { "d", 2.19m },
            { "e", 1.79m },
            { "f", 2.09m },
            { "g", 1.99m },
            { "h", 3.49m }
        };

        List<string> shoppingList = new List<string>();

        Console.WriteLine("Welcome to Kumes KuckHut!\n");
        Console.WriteLine("Item            Price\n==============================");

        foreach (var item in menu)
        {
            Console.WriteLine($"{item.Key,-15} ${item.Value:F2}");
        }

        bool continueShopping = true;

        while (continueShopping)
        {
            Console.Write("\nWhat item would you like to order? ");
            string userInput = Console.ReadLine().ToLower();

            string itemName = menu.ContainsKey(userInput) ? userInput : menu.FirstOrDefault(item => item.Key == userInput).Key;

            if (!string.IsNullOrEmpty(itemName))
            {
                shoppingList.Add(itemName);
                Console.WriteLine($"Adding {menu[itemName]} to cart at ${menu[itemName]:F2}");
            }
            else
            {
                Console.WriteLine("Sorry, we don't have those. Please try again.");
            }

            Console.Write("\nWould you like to order anything else (y/n)? ");
            continueShopping = (Console.ReadLine().ToLower() == "y");
        }

        Console.WriteLine("\nThanks for your order! Here's what you got:");
        decimal total = 0;

        foreach (var item in shoppingList)
        {
            Console.WriteLine($"{item,-15} ${menu[item]:F2}");
            total += menu[item];
        }

        Console.WriteLine($"\nTotal: ${total:F2}");

        if (shoppingList.Count > 0)
        {
            var mostExpensiveItem = shoppingList.OrderByDescending(item => menu[item]).First();
            var leastExpensiveItem = shoppingList.OrderBy(item => menu[item]).First();

            Console.WriteLine($"\nMost Expensive Item: {mostExpensiveItem} (${menu[mostExpensiveItem]:F2})");
            Console.WriteLine($"Least Expensive Item: {leastExpensiveItem} (${menu[leastExpensiveItem]:F2})");

            Console.WriteLine("\nItems Ordered by Price:");
            foreach (var item in shoppingList.OrderBy(item => menu[item]))
            {
                Console.WriteLine($"{item,-15} ${menu[item]:F2}");
            }
        }
    }
}
