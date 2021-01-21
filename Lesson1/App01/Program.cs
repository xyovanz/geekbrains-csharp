using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App01
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Task1

            Console.Title = "Анкета";
            Console.Write("Ваше имя: ");
            var name = Console.ReadLine();

            Console.Write("Ваша фамилия: ");
            var surname = Console.ReadLine();

            Console.Write("Ваш возраст: ");
            var age = double.Parse(Console.ReadLine());

            Console.Write("Ваша высота: ");
            var height = double.Parse(Console.ReadLine());

            Console.Write("Ваш вес: ");
            var weight = double.Parse(Console.ReadLine());

            Console.WriteLine($"Фамилия: {surname}, Имя: {name}, Возраст: {age}, Высота: {height}, Вес: {weight}");
            Console.ReadKey();

            #endregion

            #region Task2
            Console.Clear();

            Console.Title = "Индекс массы тела";

            Console.Write("Введите вес (кг): ");
            var m = double.Parse(Console.ReadLine());

            Console.Write("Введите рост (м): ");
            var h = double.Parse(Console.ReadLine());

            var massIndex = m / (h * h);

            Console.WriteLine($"Индекс массы тела: {massIndex}");

            Console.ReadKey();

            #endregion

            #region Task3
            Console.Clear();

            Console.Title = "Расстояние между точками";

            Console.Write("Введите x1: ");
            var x1 = double.Parse(Console.ReadLine());

            Console.Write("Введите y1: ");
            var y1 = double.Parse(Console.ReadLine());

            Console.Write("Введите x2: ");
            var x2 = double.Parse(Console.ReadLine());

            Console.Write("Введите y2: ");
            var y2 = double.Parse(Console.ReadLine());

            var r = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));

            Console.WriteLine($"Расстояние между точками: {r:f}");

            var rMethod = Distance(x1, y1, x2, y2);

            Console.WriteLine("Расстояние между точками (методом): {0:f}", rMethod);

            Console.ReadKey();
            #endregion

            #region Task4
            Console.Clear();

            Console.Title = "Обмен значений переменных";

            Console.Write("Введите первую переменную: ");
            var v1 = Console.ReadLine();

            Console.Write("Введите вторую переменную: ");
            var v2 = Console.ReadLine();

            var temp = v1;
            v1 = v2;
            v2 = temp;

            Console.WriteLine($"Первая переменная: {v1}\nВторая переменная: {v2}");

            Exchange(v1, v2);

            Console.ReadKey();
            #endregion

            #region Task5
            Console.Clear();

            Console.Title = "Информация о проживании";

            Console.Write("Введите имя: ");
            var iName = Console.ReadLine();

            Console.Write("Введите фамилию: ");
            var iSurname = Console.ReadLine();

            Console.Write("Введите город проживания: ");
            var city = Console.ReadLine();

            int xw = Console.WindowWidth / 2;
            int yw = Console.WindowHeight / 2;

            Print($"Имя: {iName}", xw, yw);
            Print($"Фамилия: {iSurname}", xw, yw+1);
            Print($"Город проживания: {city}", xw, yw+2);

            HelpAssist.Pause();
            #endregion
        }

        static double Distance(double x1, double y1, double x2, double y2)
        {
            var res = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            return res;
        }

        static void Exchange(string s1, string s2)
        {
            Console.WriteLine($"Без использования третьей переменной: \nПервая переменная: {s2}\nВторая переменная: {s1}");
        }

        static void Print(string msg, int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(msg);
        }
    }

    class HelpAssist
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
}
