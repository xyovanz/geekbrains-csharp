using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L3App01
{
    class Lesson3
    {
        /* Добромыслов
         * а) Дописать структуру Complex, добавив метод вычитания комплексных чисел. Продемонстрировать работу структуры;*/
        struct Complex
        {
            /// <summary>
            /// Мнимая часть комплексного числа
            /// </summary>
            public double im;

            /// <summary>
            /// Действительная часть комплексного числа
            /// </summary>
            public double re;

            public Complex Plus(Complex x)
            {
                Complex y;
                y.im = im + x.im;
                y.re = re + x.re;
                return y;
            }

            public Complex Minus(Complex x)
            {
                Complex y;
                y.im = im - x.im;
                y.re = re - x.re;
                return y;
            }

            public override string ToString()
            {
                if (im < 0)
                {
                    im = Math.Abs(im);
                    return $"({re} - {im}i)";
                }
                else
                {
                    return $"({re} + {im}i)";
                }
            }

        }

        static void Main(string[] args)
        {
            Complex complex1;
            complex1.re = 5;
            complex1.im = -4;

            Complex complex2;
            complex2.re = -6;
            complex2.im = -4;

            Console.WriteLine($"Результат сложения комплексных чисел {complex1} и {complex2} -> {complex1.Plus(complex2)}");
            Console.WriteLine($"Результат вычитания комплексных чисел {complex1} и {complex2} -> {complex1.Minus(complex2)}");
            

            Console.ReadKey();
        }

    }
}
