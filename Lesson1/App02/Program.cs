using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2App01
{
    class Program
    {
        /* Добромыслов */
        /* Написать метод, возвращающий минимальное из трех чисел. */
        static void Main(string[] args)
        {
            Help.SetTitle("Сравнение трех чисел");

            Console.Write("Введите первое число: ");
            var n1 = int.Parse(Console.ReadLine());

            Console.Write("Введите второе число: ");
            var n2 = int.Parse(Console.ReadLine());

            Console.Write("Введите третье число: ");
            var n3 = int.Parse(Console.ReadLine());

            var result = Minimum(n1, n2, n3);

            Help.Print($"Минимальное число: {result}");

            Console.ReadKey();
        }

        static int Minimum(int n1, int n2, int n3)
        {
            if (n1 < n2 && n1 < n3)
            {
                return n1;
            }
            else if (n2 < n1 && n2 < n3)
            {
                return n2;
            }
            else
            {
                return n3;
            }
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
