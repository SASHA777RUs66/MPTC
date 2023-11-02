using System;

class Calculator
{
    static void Main()
    {
        int choice;
        double num1, num2;

        do
        {
            Console.WriteLine("Выберите операцию:");
            Console.WriteLine("1. Сложение");
            Console.WriteLine("2. Вычитание");
            Console.WriteLine("3. Умножение");
            Console.WriteLine("4. Деление");
            Console.WriteLine("5. Возведение в степень");
            Console.WriteLine("6. Квадратный корень");
            Console.WriteLine("7. 1 процент числа");
            Console.WriteLine("8. Факториал числа");
            Console.WriteLine("9. Выход");

            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Введите два числа:");
                    num1 = double.Parse(Console.ReadLine());
                    num2 = double.Parse(Console.ReadLine());
                    Console.WriteLine("Результат: " + (num1 + num2));
                    break;
                case 2:
                    Console.WriteLine("Введите два числа:");
                    num1 = double.Parse(Console.ReadLine());
                    num2 = double.Parse(Console.ReadLine());
                    Console.WriteLine("Результат: " + (num1 - num2));
                    break;
                case 3:
                    Console.WriteLine("Введите два числа:");
                    num1 = double.Parse(Console.ReadLine());
                    num2 = double.Parse(Console.ReadLine());
                    Console.WriteLine("Результат: " + (num1 * num2));
                    break;
                case 4:
                    Console.WriteLine("Введите два числа:");
                    num1 = double.Parse(Console.ReadLine());
                    num2 = double.Parse(Console.ReadLine());
                    Console.WriteLine("Результат: " + (num1 / num2));
                    break;
                case 5:
                    Console.WriteLine("Введите число и степень:");
                    num1 = double.Parse(Console.ReadLine());
                    int power = int.Parse(Console.ReadLine());
                    Console.WriteLine("Результат: " + Math.Pow(num1, power));
                    break;
                case 6:
                    Console.WriteLine("Введите число:");
                    num1 = double.Parse(Console.ReadLine());
                    Console.WriteLine("Результат: " + Math.Sqrt(num1));
                    break;
                case 7:
                    Console.WriteLine("Введите число:");
                    num1 = double.Parse(Console.ReadLine());
                    Console.WriteLine("Результат: " + (num1 / 100));
                    break;
                case 8:
                    Console.WriteLine("Введите число:");
                    num1 = double.Parse(Console.ReadLine());
                    Console.WriteLine("Результат: " + Factorial(num1));
                    break;
                case 9:
                    Console.WriteLine("Выход из программы.");
                    break;
                default:
                    Console.WriteLine("Некорректный выбор операции.");
                    break;
            }

            Console.WriteLine();
        } while (choice != 9);
    }

    static double Factorial(double num)
    {
        if (num == 0)
            return 1;
        else
            return num * Factorial(num - 1);
    }
}