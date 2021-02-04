using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace L4App02
{
    /*Добромыслов
     2. а) Дописать класс для работы с одномерным массивом. 
     Реализовать конструктор, создающий массив заданной размерности и заполняющий массив числами от начального значения с заданным шагом. 
     Создать свойство Sum, которые возвращают сумму элементов массива, метод Inverse, меняющий знаки у всех элементов массива, метод Multi, умножающий каждый элемент массива на определенное число, свойство MaxCount, возвращающее количество максимальных элементов. 
     В Main продемонстрировать работу класса.
        б)Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.*/

    class IntArray
    {
        int[] a;

        public IntArray(int[] a)
        {
            this.a = a;
        }

        public IntArray(int b)
        {
            a = new int[b];
        }

        public IntArray(string fileName)
        {
            a = LoadArrayFromFile(fileName);
        }

        /// <summary>
        /// Массив int
        /// </summary>
        /// <param name="l">Длинна массива</param>
        /// <param name="start">Начальное значение</param>
        /// <param name="step">Шаг</param>
        public IntArray(int l, int start, int step)
        {
            a = new int[l];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = start + (step * i);
            }
        }

        /// <summary>
        /// Сумма всех элементов массива
        /// </summary>
        /// <returns></returns>
        public int Sum()
        {
            int sum = 0;
            for (int i = 0; i < a.Length; i++)
            {
                sum += a[i];
            }
            return sum;
        }

        /// <summary>
        /// Массив в измененными знаками
        /// </summary>
        /// <returns></returns>
        public IntArray Inversed()
        {
            IntArray res = new IntArray(a.Length);
            for (int i = 0; i < a.Length; i++)
            {
                res[i] = a[i] * -1;
            }
            return res;
        }

        /// <summary>
        /// Домножение массива на заданное число
        /// </summary>
        /// <param name="z">Число, на которое нужно домножить массив</param>
        /// <returns></returns>
        public IntArray Multied(int z)
        {
            IntArray res = new IntArray(a.Length);
            for (int i = 0; i < a.Length; i++)
            {
                res[i] = a[i] * z;
            }
            return res;
        }

        /// <summary>
        /// Индексное свойство
        /// </summary>
        /// <param name="index">Индекс элемента массива</param>
        /// <returns>Значение элемента массива</returns>
        public int this[int index]
        {
            get { return a[index]; }
            set
            {
                a[index] = value;
            }
        }

        public int MaxCount()
        {
            int max = a.Max();
            int count = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == max)
                {
                    count++;
                }
            }
            return count;
        }

        /// <summary>
        /// Загрузка массива из файла
        /// </summary>
        /// <param name="fileName">Название файла</param>
        /// <returns></returns>
        public static int[] LoadArrayFromFile(string fileName)
        {
            if (!File.Exists(fileName))
                throw new FileNotFoundException();
            StreamReader r = new StreamReader(fileName);
            int[] x = new int[int.Parse(r.ReadLine())];
            for (int i = 0; i < x.Length; i++)
                x[i] = int.Parse(r.ReadLine());
            r.Close();
            return x;
        }

        /// <summary>
        /// Сохранение массива в файл
        /// </summary>
        /// <param name="fileName"></param>
        public void SaveToFile(string fileName)
        {
            StreamWriter w = new StreamWriter(fileName);
            for (int i = 0; i < a.Length; i++)
            {
                w.WriteLine(a[i]);
            }
            w.Close();
        }

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < a.Length; i++)
            {
                s += $"{a[i]} ";
            }
            return s;
        }
    }

    class L4App02
    {
        static void Main(string[] args)
        {
            int l = 5;
            int s = 4;
            int step = 7;
            int z = 3;

            IntArray a = new IntArray(l, s, step);
            int[] arr = { 1, 5, 5, 2 };
            IntArray b = new IntArray(arr);
            IntArray c = new IntArray(AppDomain.CurrentDomain.BaseDirectory + "Array.txt");

            Console.WriteLine($"Сконструированный массив: {a}");
            Console.WriteLine();
            Console.WriteLine($"Сумма элементов массива: {a.Sum()}");
            Console.WriteLine($"Перевернутый массив: {a.Inversed()}");
            Console.WriteLine($"Массив, домноженный на {z}: {a.Multied(z)}");
            Console.WriteLine();
            Console.WriteLine($"Еще один массив: {b}");
            Console.WriteLine($"Количество максимальных элементов первого массива: {a.MaxCount()}");
            Console.WriteLine($"Количество максимальных элементов второго массива: {b.MaxCount()}");
            
            Console.WriteLine();
            Console.WriteLine($"Массив из файла: {c}");

            c.SaveToFile(AppDomain.CurrentDomain.BaseDirectory + @"../../ArraySave.txt"); //не понял, как сохранять не в bin, кроме как так

            Console.ReadKey();
        }
    }
}
