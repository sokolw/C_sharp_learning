using System;
using System.ComponentModel;

namespace week3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstNumber;
            int[] secondNumber;
            do
            {
                Console.WriteLine("Введите два положительных числа: ");
                Console.WriteLine("Первое число: ");
                firstNumber = InputNumberToArray();
                Console.WriteLine("Второе число: ");
                secondNumber = InputNumberToArray();
                Console.WriteLine("Результат сложения в столбик: "+SumTwoArrays(firstNumber, secondNumber));
                Console.WriteLine("Продолжить Y/N: ");
            }
            while (Console.ReadLine().Equals("Y",StringComparison.OrdinalIgnoreCase));
        }

        //ввод + число в массив
        public static int[] InputNumberToArray()
        {
            string stringNumber = Console.ReadLine();
            if (!int.TryParse(stringNumber, out int number))
            {
                Console.WriteLine("Введите число!");
                return InputNumberToArray();
            }
            int[] numbersArray = new int[stringNumber.Length];

            for(int i=numbersArray.Length-1; i >= 0; i--)
            {
                numbersArray[i] = number % 10;
                number /= 10;
            }
            return numbersArray;
        }

        //сумма массивов
        public static int SumTwoArrays(int[] firstNumber, int[] secondNumber)
        {
            //делаем массивы с равным кол-вом элементов
            if (firstNumber.Length > secondNumber.Length)
                secondNumber= AddZero(firstNumber, secondNumber);
            else if (firstNumber.Length < secondNumber.Length)
                firstNumber = AddZero(secondNumber, firstNumber);
            
            int[] AddZero(int[] firstNumberZ, int[] secondNumberZ)
            {
                int[] tempArr;
                tempArr = new int[firstNumberZ.Length];
                secondNumberZ.CopyTo(tempArr, firstNumberZ.Length - secondNumberZ.Length);
                return tempArr;
            }

            //сложение массивов
            int[] sumResultArray = new int[firstNumber.Length+1];

            for (int i = firstNumber.Length-1; i >=0; i--)
            {
                if((firstNumber[i]+ secondNumber[i] + sumResultArray[i + 1]) /10 != 0)
                {
                    sumResultArray[i+1] = (firstNumber[i] + secondNumber[i]+ sumResultArray[i + 1]) % 10;
                    sumResultArray[i] = (firstNumber[i] + secondNumber[i]) / 10;
                }
                else
                    sumResultArray[i + 1] += firstNumber[i] + secondNumber[i];
            }
            return NumberArrayToInt(sumResultArray);
        }

        //из массива в число
        public static int NumberArrayToInt(int[] numberArray)
        {
            int result = 0;
            int dec = 1;
            for (int i = numberArray.Length-1; i >= 0; i--)
            {
                result += numberArray[i] * dec;
                dec *= 10;
            }
            return result;
        }

    }
}
