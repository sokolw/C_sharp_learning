using System;

namespace week2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите первое число: ");
            int x = EnterNumber();
            Console.WriteLine("Введите оператор: ");
            string operation= EnterOperator();
            Console.WriteLine("Введите второе число: ");
            int y = EnterNumber();

            if(string.Equals(operation,"*"))
                Console.WriteLine($"Результат умножения: {x*y}");
            if (string.Equals(operation, "/"))
                Console.WriteLine($"Результат деления: {x / (double)y}");
            if (string.Equals(operation, "+"))
                Console.WriteLine($"Результат сложения: {x + y}");
            if (string.Equals(operation, "-"))
                Console.WriteLine($"Результат вычитания: {x - y}");
        }
        static int EnterNumber()
        {
            int temp;
            try
            {
                temp = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Нужно ввести число!");
                return EnterNumber();
            }
            return temp;
        }
        static string EnterOperator()
        {
            string temp = Console.ReadLine();
            if (temp!="*" && temp != "/" && temp != "+" && temp != "-")
            {
                Console.WriteLine("Введите один из операторов * , / , + , -");
                return EnterOperator();
            }
            return temp;
        }
    }
}
