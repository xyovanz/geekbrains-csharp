using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2App05
{
    class Program
    {
        /* Добромыслов
         * а) Написать программу, которая запрашивает массу и рост человека, вычисляет его индекс массы и сообщает, нужно ли человеку похудеть, набрать вес или все в норме;
            б) *Рассчитать, на сколько кг похудеть или сколько кг набрать для нормализации веса. */
        static void Main(string[] args)
        {
            Help.SetTitle("Расчет ИМТ");

            Console.Write("Введите вес (кг): ");
            var m = double.Parse(Console.ReadLine());

            Console.Write("Введите рост (м): ");
            var h = double.Parse(Console.ReadLine());

            var massIndex = m / (h * h);
            Help.Print($"Индекс массы тела: {massIndex}");

            double idealMassIndex = 22; //22 как примерный нормальный индекс массы тела
            var idealMass = idealMassIndex * (h * h);
            var recommend = idealMass - m;

            if (massIndex <= 16) Help.Print($"У вас выраженный дефицит массы тела. Рекомендуем набрать около {Math.Abs(recommend)} кг.");
            else if (massIndex > 16 && massIndex < 18.5) Help.Print($"У вас дефицит массы тела. Рекомендуем набрать около {Math.Abs(recommend)} кг.");
            else if (massIndex > 18.5 && massIndex < 25) Help.Print($"Ваша масса в норме.");
            else if (massIndex > 25 && massIndex < 30) Help.Print($"У вас избыточная масса тела. Рекомендуем сбросить около {Math.Abs(recommend)} кг.");
            else if (massIndex > 30 && massIndex < 35) Help.Print($"У вас ожирение. Рекомендуем сбросить около {Math.Abs(recommend)} кг.");
            else if (massIndex > 35 && massIndex < 40) Help.Print($"У вас резкое ожирение. Рекомендуем сбросить около {Math.Abs(recommend)} кг.");
            else if (massIndex >= 40) Help.Print($"У вас очень резкое ожирение. Рекомендуем сбросить около {Math.Abs(recommend)} кг.");

            Console.ReadKey();
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
