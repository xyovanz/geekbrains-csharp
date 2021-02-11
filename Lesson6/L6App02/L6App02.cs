/*Добромыслов
 2. Модифицировать программу нахождения минимума функции так, чтобы можно было передавать функцию в виде делегата.
а) Сделайте меню с различными функциями и предоставьте пользователю выбор, для какой функции и на каком отрезке находить минимум.
б) Используйте массив (или список) делегатов, в котором хранятся различные функции.
в) *Переделайте функцию Load, чтобы она возвращала массив считанных значений. Пусть она возвращает минимум через параметр.*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L6App02
{
    class L6App02
    {
        public delegate double Func(double i);

        public static double F1(double x)
        {
            return x * x - 50 * x + 10;
        }

        public static double F2(double x)
        {
            return x * x + 20 * x - 70;
        }

        public static double F3(double x)
        {
            return x * x - 60 * x - 70;
        }

        public static void SaveFunc(string fileName, double a, double b, double h, Func f)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            double x = a;
            while (x <= b)
            {
                bw.Write(f(x));
                x += h;
            }
            bw.Close();
            fs.Close();
        }
        public static double Load(string fileName, out ArrayList aL)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader bw = new BinaryReader(fs);
            aL = new ArrayList();
            double min = double.MaxValue;
            double d;
            for (int i = 0; i < fs.Length / sizeof(double); i++)
            {
                // Считываем значение и переходим к следующему
                d = bw.ReadDouble();
                aL.Add(d);
                if (d < min) min = d;
            }
            bw.Close();
            fs.Close();
            return min;
        }
        static void Main(string[] args)
        {
            Func[] f = { F1, F2, F3 };
            List<Func> fl = new List<Func>(f);
            Console.Write("Введите номер функции: ");
            for (int i = 0; i < fl.Capacity; i++)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
            var input = int.TryParse(Console.ReadLine(), out int index);

            Console.WriteLine($"Введите нижнюю границу: ");
            input = int.TryParse(Console.ReadLine(), out int low);

            Console.WriteLine($"Введите верхнюю границу: ");
            input = int.TryParse(Console.ReadLine(), out int high);

            SaveFunc("data.bin", low, high, 0.5, f[index]);
            Console.WriteLine(Load("data.bin", out ArrayList list));

            Console.WriteLine("Нажмите любую кнопку, чтобы вывести считанные значения...");
            Console.ReadLine();

            foreach (var e in list)
            {
                Console.WriteLine(e);
            }

            Console.ReadKey();
        }
    }
}