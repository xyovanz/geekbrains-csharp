using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2App06
{
    class Program
    {
        /* Добромыслов
         * *Написать программу подсчета количества «Хороших» чисел в диапазоне от 1 до 1 000 000 000. 
         * Хорошим называется число, которое делится на сумму своих цифр. 
         * Реализовать подсчет времени выполнения программы, используя структуру DateTime.
         */
        static void Main(string[] args)
        {
            DateTime start = DateTime.Now;

            int count = 0;

            for (int i = 1; i <= 1000000000; i++)
            {
                if (i % Sum(i) == 0)
                {
                    count++;
                }
            }

            Console.WriteLine(count);

            DateTime finish = DateTime.Now;
            Console.WriteLine($"Время выполнения программы {finish - start}");
            Console.ReadKey();
        }

        static int Sum(int a)
        {
            if (a == 0)
            {
                return 0;
            }
            else return Sum(a / 10) + a % 10;
        }
    }
}
