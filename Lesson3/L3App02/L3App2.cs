using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L3App02
{
    /* Добромыслов
     2. а) С клавиатуры вводятся числа, пока не будет введен 0 (каждое число в новой строке). Требуется подсчитать сумму всех нечетных положительных чисел. Сами числа и сумму вывести на экран, используя tryParse;
        б) Добавить обработку исключительных ситуаций на то, что могут быть введены некорректные данные. При возникновении ошибки вывести сообщение. Напишите соответствующую функцию;*/

    class L3App2
    {
        static void Main(string[] args)
        {
            int sum = 0;
            while (true)
            {
                Console.WriteLine("Введите нечетное положительное число (0 завершает ввод):");
                var a = int.TryParse(Console.ReadLine(), out int i);

                if (i != 0)
                {
                    if (i > 0 && i % 2 != 0)
                    {
                        sum = sum + i;
                    }
                    else if (i % 2 == 0)
                    {
                        throw new Exception("Вы ввели четное число");
                    }
                    else if (i < 0)
                    {
                        throw new Exception("Вы ввели отрицательное число");
                    }
                }
                else if (i == 0)
                {
                    Console.WriteLine($"Сумма нечетных положительных чисел: {sum}");
                    Console.ReadKey();
                    return;
                }
            }
        }
    }
}
