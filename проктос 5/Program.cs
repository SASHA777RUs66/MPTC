using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        OrderMenu.StartMenu();
    }
}

class OrderMenu
{
    static List<Cake> cakes = new List<Cake>();
    static List<CakeOption> flavors = new List<CakeOption>()
    {
        new CakeOption("Vanilla", 10),
        new CakeOption("Chocolate", 15),
        new CakeOption("Strawberry", 12)
    };

    static List<CakeOption> sizes = new List<CakeOption>()
    {
        new CakeOption("Small", 20),
        new CakeOption("Medium", 30),
        new CakeOption("Large", 40)
    };

    static List<CakeOption> glazes = new List<CakeOption>()
    {
        new CakeOption("Buttercream", 5),
        new CakeOption("Chocolate", 7),
        new CakeOption("Fondant", 10)
    };

    static List<CakeOption> decorations = new List<CakeOption>()
    {
        new CakeOption("Sprinkles", 2),
        new CakeOption("Fruit", 3),
        new CakeOption("Edible Flowers", 4)
    };

    static int currentMenuLevel = 0;

    public static void StartMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("************ Cake Order System ************");
            Console.WriteLine("1. Order a Cake");
            Console.WriteLine("2. Show Order History");
            Console.WriteLine("3. Exit");

            var key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.D1:
                    OrderCake();
                    break;
                case ConsoleKey.D2:
                    ShowOrderHistory();
                    break;
                case ConsoleKey.D3:
                    Environment.Exit(0);
                    break;
            }
        }
    }

    static void OrderCake()
    {
        Console.Clear();
        Console.WriteLine("************ Order a Cake ************");

        Cake cake = new Cake();

        cake.Flavor = GetSelectedOption(flavors, "Flavor");
        cake.Size = GetSelectedOption(sizes, "Size");
        cake.Glaze = GetSelectedOption(glazes, "Glaze");
        cake.Decoration = GetSelectedOption(decorations, "Decoration");

        Console.Write("Enter quantity: ");
        int quantity = int.Parse(Console.ReadLine());
        cake.Quantity = quantity;

        cakes.Add(cake);

        Console.WriteLine("\nCake added to the order successfully!");

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey(true);
    }

    static CakeOption GetSelectedOption(List<CakeOption> options, string optionName)
    {
        Console.Clear();
        Console.WriteLine($"************ Select {optionName} ************");

        int selectedIndex = 0;
        while (true)
        {
            for (int i = 0; i < options.Count; i++)
            {
                if (i == selectedIndex)
                    Console.Write("> ");
                else
                    Console.Write("  ");

                Console.WriteLine($"{options[i].Description} - ${options[i].Price}");
            }

            var key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    selectedIndex = (selectedIndex - 1 + options.Count) % options.Count;
                    break;
                case ConsoleKey.DownArrow:
                    selectedIndex = (selectedIndex + 1) % options.Count;
                    break;
                case ConsoleKey.Enter:
                    return options[selectedIndex];
                case ConsoleKey.Escape:
                    return null;
            }
        }
    }

    static void ShowOrderHistory()
    {
        Console.Clear();
        Console.WriteLine("************ Order History ************");

        if (cakes.Count == 0)
        {
            Console.WriteLine("No orders found.");
        }
        else
        {
            foreach (var cake in cakes)
            {
                Console.WriteLine($"Flavor: {cake.Flavor.Description} - ${cake.Flavor.Price}");
                Console.WriteLine($"Size: {cake.Size.Description} - ${cake.Size.Price}");
                Console.WriteLine($"Glaze: {cake.Glaze.Description} - ${cake.Glaze.Price}");
                Console.WriteLine($"Decoration: {cake.Decoration.Description} - ${cake.Decoration.Price}");
                Console.WriteLine($"Quantity: {cake.Quantity}");
                Console.WriteLine($"Total Price: ${cake.TotalPrice}");
                Console.WriteLine("--------------------------------------");
            }
        }

        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey(true);
    }

    static void SaveOrderHistory()
    {
        using (StreamWriter writer = new StreamWriter("OrderHistory.txt", true))
        {
            foreach (var cake in cakes)
            {
                writer.WriteLine($"Flavor: {cake.Flavor.Description} - ${cake.Flavor.Price}");
                writer.WriteLine($"Size: {cake.Size.Description} - ${cake.Size.Price}");
                writer.WriteLine($"Glaze: {cake.Glaze.Description} - ${cake.Glaze.Price}");
                writer.WriteLine($"Decoration: {cake.Decoration.Description} - ${cake.Decoration.Price}");
                writer.WriteLine($"Quantity: {cake.Quantity}");
                writer.WriteLine($"Total Price: ${cake.TotalPrice}");
                writer.WriteLine("--------------------------------------");
            }
        }
    }
}

class Cake
{
    public CakeOption Flavor { get; set; }
    public CakeOption Size { get; set; }
    public CakeOption Glaze { get; set; }
    public CakeOption Decoration { get; set; }
    public int Quantity { get; set; }

    public decimal TotalPrice
    {
        get { return Quantity * (Flavor.Price + Size.Price + Glaze.Price + Decoration.Price); }
    }
}

class CakeOption
{
    public string Description { get; }
    public decimal Price { get; }

    public CakeOption(string description, decimal price)
    {
        Description = description;
        Price = price;
    }
}