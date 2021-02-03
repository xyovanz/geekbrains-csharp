using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4
{
    /*Добромыслов
     1. Дан целочисленный массив из 20 элементов. 
     Элементы массива могут принимать целые значения от –10 000 до 10 000 включительно. 
     Написать программу, позволяющую найти и вывести количество пар элементов массива, в которых хотя бы одно число делится на 3. 
     В данной задаче под парой подразумевается два подряд идущих элемента массива. 
     Например, для массива из пяти элементов: 6; 2; 9; –3; 6 – ответ: 4.*/

    class L4App01
    {
        static void Main(string[] args)
        {
            int[] a = { 4, -523, 6, -943, -4, 2345, 27, 30, -25, -8, 9, 456, 123, 634, 123, 5, -253, -213, -43, 12 };

            int count = 0;
            
            for (int i = 0; i < a.Length - 1; i++)
            {
                if (a[i] % 3 == 0 || a[i+1] % 3 == 0)
                {
                    count++;
                }
            }

            Console.Write("Данный массив: ");
            PrintArray(a);
            Console.WriteLine();
            Console.WriteLine($"Количество пар элементов с заданными условиями: {count}");

            Console.ReadKey();
        }

        /// <summary>
        /// Вывод массива в строку
        /// </summary>
        /// <param name="a">Массив int</param>
        static void PrintArray(int[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write($"{a[i]} ");
            }
        }
    }
}
