using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2App07
{
    class Program
    {
        /* Добромыслов 
         * a) Разработать рекурсивный метод, который выводит на экран числа от a до b (a<b);
            б) *Разработать рекурсивный метод, который считает сумму чисел от a до b. */
        static void Main(string[] args)
        {
            Help.SetTitle("Вывод чисел на экран");
            while (true)
            {
                Console.Write("Введите номер задания (1 - А, 2 - B, 0 - выход): ");
                var x = int.Parse(Console.ReadLine());

                switch (x)
                {
                    case 0:
                        return;
                    case 1:
                        TaskA();
                        break;
                    case 2:
                        TaskB();
                        break;
                }
            }
        }

        static void TaskA()
        {
            Console.Write("Введите a: ");
            var a = int.Parse(Console.ReadLine());

            Console.Write("Введите b: ");
            var b = int.Parse(Console.ReadLine());

            Recursive(a, b);
        }

        static void TaskB()
        {
            Console.Write("Введите a: ");
            var a = int.Parse(Console.ReadLine());

            Console.Write("Введите b: ");
            var b = int.Parse(Console.ReadLine());

            Console.WriteLine(RecursiveSum(a, b));
        }

        static void Recursive(int n, int m)
        {
            Console.WriteLine(n);
            if (n < m)
            {
                n++;
                Recursive(n, m);
            }
        }

        static int RecursiveSum(int n, int m)
        {
            if (n == m)
            {
                return n;
            }
            else
            {
                return n + RecursiveSum(n + 1, m);
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
