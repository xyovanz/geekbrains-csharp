/*Добромыслов
 1. Изменить программу вывода функции так, чтобы можно было передавать функции типа double (double,double). 
 Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L6App01
{
    delegate double DoMethod(double a, double b);
    class L6App01
    {
        static double Square(double a, double x)
        {
            Console.Write($"{a} * {x}^2");
            return a * x * x;
        }

        static void Print(DoMethod m, double a, double b)
        {
            double res = m(a, b);
            Console.Write($" = {res}");
        }

        static void Main(string[] args)
        {
            Print(Square, 10, 3);
            Console.WriteLine();

            Print(delegate (double a, double x)
            {
                Console.Write($"{a} * sin({x})");
                return a * Math.Sin(x);
            }, 5, 9);

            Console.ReadKey();
        }
    }
}
