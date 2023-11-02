using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        bool exit = false;
        List<Order> orders = new List<Order>();

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("Главное меню:");
            Console.WriteLine("1. Выбор торта");
            Console.WriteLine("2. Просмотр итогового заказа");
            Console.WriteLine("Esc. Выйти из программы");

            ConsoleKeyInfo key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.D1:
                    Order order = new Order();
                    order.MakeOrder();
                    orders.Add(order);
                    break;
                case ConsoleKey.D2:
                    ShowOrders(orders);
                    break;
                case ConsoleKey.Escape:
                    exit = true;
                    break;
            }
        }
    }

    static void ShowOrders(List<Order> orders)
    {
        Console.Clear();
        Console.WriteLine("Итоговый заказ:");

        foreach (Order order in orders)
        {
            Console.WriteLine(order);
        }

        Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
        Console.ReadKey();
    }
}

class Order
{
    private CakeForm selectedForm;
    private CakeSize selectedSize;
    private CakeFlavor selectedFlavor;
    private int quantity;
    private CakeGlaze selectedGlaze;
    private CakeDecoration selectedDecoration;

    private static List<CakeForm> forms = new List<CakeForm>()
    {
        new CakeForm("Круглая", 10),
        new CakeForm("Прямоугольная", 15),
        new CakeForm("Сердце", 20)
    };

    private static List<CakeSize> sizes = new List<CakeSize>()
    {
        new CakeSize("Маленький", 5),
        new CakeSize("Средний", 10),
        new CakeSize("Большой", 15)
    };

    private static List<CakeFlavor> flavors = new List<CakeFlavor>()
    {
        new CakeFlavor("Шоколадный", 8),
        new CakeFlavor("Ванильный", 6),
        new CakeFlavor("Фруктовый", 7)
    };

    private static List<CakeGlaze> glazes = new List<CakeGlaze>()
    {
        new CakeGlaze("Шоколадная", 3),
        new CakeGlaze("Карамельная", 4),
        new CakeGlaze("Сливочная", 5)
    };

    private static List<CakeDecoration> decorations = new List<CakeDecoration>()
    {
        new CakeDecoration("Цветы", 2),
        new CakeDecoration("Фигурки", 3),
        new CakeDecoration("Надпись", 1)
    };

    public void MakeOrder()
    {
        Console.Clear();
        Console.WriteLine("Выберите форму:");

        int formIndex = Menu.DisplayMenu(forms);
        selectedForm = forms[formIndex];

        Console.Clear();
        Console.WriteLine("Выберите размер:");

        int sizeIndex = Menu.DisplayMenu(sizes);
        selectedSize = sizes[sizeIndex];

        Console.Clear();
        Console.WriteLine("Выберите вкус:");

        int flavorIndex = Menu.DisplayMenu(flavors);
        selectedFlavor = flavors[flavorIndex];

        Console.Clear();
        Console.WriteLine("Введите количество:");
        quantity = int.Parse(Console.ReadLine());

        Console.Clear();
        Console.WriteLine("Выберите глазурь:");

        int glazeIndex = Menu.DisplayMenu(glazes);
        selectedGlaze = glazes[glazeIndex];

        Console.Clear();
        Console.WriteLine("Выберите декор:");

        int decorationIndex = Menu.DisplayMenu(decorations);
        selectedDecoration = decorations[decorationIndex];

        SaveToFile();
    }

    private void SaveToFile()
    {
        string fileName = "История заказов.txt";
        StreamWriter writer = new StreamWriter(fileName, true);

        writer.WriteLine($"Форма: {selectedForm.Name}");
        writer.WriteLine($"Размер: {selectedSize.Name}");
        writer.WriteLine($"Вкус: {selectedFlavor.Name}");
        writer.WriteLine($"Количество: {quantity}");
        writer.WriteLine($"Глазурь: {selectedGlaze.Name}");
        writer.WriteLine($"Декор: {selectedDecoration.Name}");
        writer.WriteLine($"Цена: {GetTotalPrice()}");
        writer.WriteLine();

        writer.Close();
    }

    private int GetTotalPrice()
    {
        int totalPrice = selectedForm.Price + selectedSize.Price + selectedFlavor.Price +
                         selectedGlaze.Price + selectedDecoration.Price;
        return totalPrice * quantity;
    }

    public override string ToString()
    {
        return $"Форма: {selectedForm.Name}\n" +
               $"Размер: {selectedSize.Name}\n" +
               $"Вкус: {selectedFlavor.Name}\n" +
               $"Количество: {quantity}\n" +
               $"Глазурь: {selectedGlaze.Name}\n" +
               $"Декор: {selectedDecoration.Name}\n" +
               $"Цена: {GetTotalPrice()}";
    }
}

class Menu
{
    public static int DisplayMenu(List<IMenuItem> items)
    {
        int selectedIndex = 0;
        bool selected = false;

        while (!selected)
        {
            Console.Clear();

            for (int i = 0; i < items.Count; i++)
            {
                if (i == selectedIndex)
                {
                    Console.WriteLine($"> {items[i]}");
                }
                else
                {
                    Console.WriteLine($"  {items[i]}");
                }
            }

            ConsoleKeyInfo key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    selectedIndex = Math.Max(0, selectedIndex - 1);
                    break;
                case ConsoleKey.DownArrow:
                    selectedIndex = Math.Min(items.Count - 1, selectedIndex + 1);
                    break;
                case ConsoleKey.Enter:
                    selected = true;
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
            }
        }

        return selectedIndex;
    }
}

interface IMenuItem
{
    string Name { get; }
    int Price { get; }
}

class CakeForm : IMenuItem
{
    public string Name { get; }
    public int Price { get; }

    public CakeForm(string name, int price)
    {
        Name = name;
        Price = price;
    }

    public override string ToString()
    {
        return $"{Name} ({Price} руб)";
    }
}

class CakeSize : IMenuItem
{
    public string Name { get; }
    public int Price { get; }

    public CakeSize(string name, int price)
    {
        Name = name;
        Price = price;
    }

    public override string ToString()
    {
        return $"{Name} ({Price} руб)";
    }
}

class CakeFlavor : IMenuItem
{
    public string Name { get; }
    public int Price { get; }

    public CakeFlavor(string name, int price)
    {
        Name = name;
        Price = price;
    }

    public override string ToString()
    {
        return $"{Name} ({Price} руб)";
    }
}

class CakeGlaze : IMenuItem
{
    public string Name { get; }
    public int Price { get; }

    public CakeGlaze(string name, int price)
    {
        Name = name;
        Price = price;
    }

    public override string ToString()
    {
        return $"{Name} ({Price} руб)";
    }
}

class CakeDecoration : IMenuItem
{
    public string Name { get; }
    public int Price { get; }

    public CakeDecoration(string name, int price)
    {
        Name = name;
        Price = price;
    }

    public override string ToString()
    {
        return $"{Name} ({Price} руб)";
    }
}