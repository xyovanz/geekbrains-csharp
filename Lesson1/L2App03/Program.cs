using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2App03
{
    class Program
    {
        /* Добромыслов
         * С клавиатуры вводятся числа, пока не будет введен 0. Подсчитать сумму всех нечетных положительных чисел. */
        static void Main(string[] args)
        {
            Help.SetTitle("Сумма нечетных положительных чисел");

            int sum = 0;
            
            Console.Write("Введите число ( 0 прекращает ввод ): ");
            int input = int.Parse(Console.ReadLine());
            while (input != 0)
            {
                if (input > 0 && !IsOdd(input))
                {
                    sum = sum + input;
                }
                Console.Write("Введите число ( 0 прекращает ввод ): ");
                input = int.Parse(Console.ReadLine());
            }
            Help.Print($"Сумма нечетных положительных чисел: {sum}");

            Console.ReadKey();
        }

        static bool IsOdd(int a)
        {
            return a % 2 == 0;
        }
    }
    #region Help Class
    class Help
    {   
        public static void Print(string msg, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(msg);
        }

        public static void Print(string msg)
        {
            Console.WriteLine(msg);
        }

        public static void Pause()
        {
            Console.ReadKey();
        }

        public static void SetTitle(string t)
        {
            Console.Title = t;
        }
    }
    #endregion
}
