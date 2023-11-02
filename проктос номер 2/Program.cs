using System;

class Program
{
    static void Main()
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Игра 'Угадай число'");
            Console.WriteLine("2. Таблица умножения");
            Console.WriteLine("3. Вывод делителей числа");
            Console.WriteLine("0. Выход");

            Console.Write("Выберите программу (0-3): ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    GuessNumberGame();
                    break;
                case 2:
                    MultiplicationTable();
                    break;
                case 3:
                    PrintDivisors();
                    break;
                case 0:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void GuessNumberGame()
    {
        Console.WriteLine("Игра 'Угадай число'");
        Random random = new Random();
        int targetNumber = random.Next(0, 101);
        int attempts = 0;
        int guess;

        do
        {
            Console.Write("Введите число: ");
            guess = Convert.ToInt32(Console.ReadLine());
            attempts++;

            if (guess < targetNumber)
                Console.WriteLine("Загаданное число больше.");
            else if (guess > targetNumber)
                Console.WriteLine("Загаданное число меньше.");

        } while (guess != targetNumber);

        Console.WriteLine($"Вы угадали! Загаданное число было {targetNumber}. Количество попыток: {attempts}");
    }

    static void MultiplicationTable()
    {
        Console.WriteLine("Таблица умножения");

        int[,] table = new int[10, 10];

        for (int i = 1; i <= 10; i++)
        {
            for (int j = 1; j <= 10; j++)
            {
                table[i - 1, j - 1] = i * j;
            }
        }

        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Console.Write($"{table[i, j],4}");
            }
            Console.WriteLine();
        }
    }

    static void PrintDivisors()
    {
        Console.WriteLine("Вывод делителей числа");

        int number;

        do
        {
            Console.Write("Введите число (0 для выхода): ");
            number = Convert.ToInt32(Console.ReadLine());

            if (number == 0)
                return;

            Console.Write("Делители числа: ");

            for (int i = 1; i <= number; i++)
            {
                if (number % i == 0)
                    Console.Write($"{i} ");
            }

            Console.WriteLine();
        } while (true);
    }
}