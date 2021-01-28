using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2App02
{
    class Program
    {
        /* Добромыслов
         * Написать метод подсчета количества цифр числа.*/

        static void Main(string[] args)
        {
            Console.Clear();
            Help.SetTitle("Подсчет количества цифр числа");

            Console.Write("Введите число: ");
            var input = Console.ReadLine();
            
            Help.Print($"Количество цифр в числе: {(NumbersCount(input))}"); 
            
            Console.ReadKey();
        }

        static int NumbersCount(string s) //по-хорошему, метод бесполезный, поскольку можно было бы использовать input.Length, правильно?
        {
            int res = 0;
            foreach(char c in s)
            {
                res++;
            }
            return res;
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
