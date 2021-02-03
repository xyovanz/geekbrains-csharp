using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace L4App04
{
    /*Добромыслов
     4. *а) Реализовать класс для работы с двумерным массивом. 
            Реализовать конструктор, заполняющий массив случайными числами. Создать методы, которые возвращают сумму всех элементов массива, сумму всех элементов массива больше заданного, свойство, возвращающее минимальный элемент массива, свойство, возвращающее максимальный элемент массива, метод, возвращающий номер максимального элемента массива (через параметры, используя модификатор ref или out)
        *б) Добавить конструктор и методы, которые загружают данные из файла и записывают данные в файл.
            Дополнительные задачи
        в) Обработать возможные исключительные ситуации при работе с файлами.*/

    class Array2D
    {
        int[,] a;

        /// <summary>
        /// Двумерный int массив со случайными числами
        /// </summary>
        /// <param name="x">Первый размер</param>
        /// <param name="y">Второй размер</param>
        /// <param name="max">Максимальное значение элемента</param>
        public Array2D(int x, int y, int max)
        {
            a = new int[x, y];
            Random r = new Random();
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    a[i, j] = r.Next(max);
                }
            }
        }

        /// <summary>
        /// Двумерный int массив
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Array2D(int x, int y)
        {
            a = new int[x, y];
        }

        public Array2D(int[,] x)
        {
            a = x;
        }

        /// <summary>
        /// Двумерный int массив из файла
        /// </summary>
        /// <param name="fileName"></param>
        public Array2D(string fileName)
        {
            //a = LoadArrayFromFile(fileName);
        }

        /// <summary>
        /// Сумма всех элементов двумерного массива
        /// </summary>
        public void Sum(out int s)
        {
            s = 0;
            foreach (int i in a)
            {
                s += i;
            }
        }

        /// <summary>
        /// Сумма всех элементов, больше заданного
        /// </summary>
        /// <param name="max">Заданный элемент</param>
        public void Sum(int max)
        {
            int s = 0;
            foreach (int i in a)
            {
                if (i > max)
                    s += i;
            }
            Console.WriteLine($"Сумма всех элементов массива больше, чем {max}: {s}");
        }

        /// <summary>
        /// Нахождение минимального элемента массива
        /// </summary>
        public void Min()
        {
            int min = a[0,0];
            foreach (int i in a)
            {
                if (i < min)
                {
                    min = i;
                }
            }
            Console.WriteLine($"Минимальный элемент массива: {min}");
        }

        /// <summary>
        /// Свойство, возвращающее максимальный элемент массива
        /// </summary>
        /// <returns></returns>
        public int Max()
        {
            int max = 0;
            foreach (int i in a)
            {
                if (i > max)
                {
                    max = i;
                }
            }
            return max;
        }

        /// <summary>
        /// Нахождение индекса максимального элемента
        /// </summary>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public void MaxIndex(out int y, out int z)
        {
            y = 0;
            z = 0;
            int max = 0;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    if (a[i,j] > max)
                    {
                        max = a[i,j];
                        y = i;
                        z = j;
                    }
                }
            }

        }

        /// <summary>
        /// Загрузка массива из файла
        /// </summary>
        /// <param name="fileName">Название файла</param>
        /// <returns></returns>
        //public static Array2D LoadArrayFromFile(string fileName)
        //{
        //    if (!File.Exists(fileName))
        //        throw new FileNotFoundException();
        //    int x = 0;
        //    int y = 0;
        //    string line;
        //    StreamReader r = new StreamReader(fileName);
        //    while ((line = r.ReadLine()) != "" ^ (line = r.ReadLine()) != null)
        //    {
        //        foreach(char c in line)
        //        {
        //            c.
        //        }
        //        x++;
        //    }
        //    int[,] m = new int[x,y];
        //    for (int i = 0; i < m.GetLength(0); i++)
        //        for (int j = 0; j < m.GetLength(1); j++)
        //            m[i,j] = int.Parse(r.ReadLine());
        //    r.Close();
        //    Array2D n = new Array2D(m);
        //    return n;
        //}

        /// <summary>
        /// Сохранение массива в файл
        /// </summary>
        /// <param name="fileName"></param>
        public void SaveToFile(string fileName)
        {
            StreamWriter w = new StreamWriter(fileName);
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    w.Write($"{a[i,j]} ");
                }
                w.WriteLine();
            }
            w.Close();
        }

        public int this[int i, int j]
        {
            get { return a[i, j]; }
            set
            {
                a[i, j] = value;
            }
        }

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    s += a[i, j] + " ";
                }
                s += "\n";
            }
            return s;
        }
    }

    class L4App04
    {
        static void Main(string[] args)
        {
            int x = 2;
            int y = 3;
            int m = 16;
            Array2D a = new Array2D(x, y, m);
            Array2D b = new Array2D(AppDomain.CurrentDomain.BaseDirectory + "LoadArray.txt");
            
            Console.WriteLine("Сгенерированный массив:");
            Console.WriteLine();
            Console.WriteLine(a);

            int max = 5;

            a.Sum(out int sum);
            Console.WriteLine($"Сумма всех элементов массива: {sum}");
            a.Sum(max);
            a.Min();
            a.MaxIndex(out int i, out int j);
            Console.WriteLine($"Максимальный элемент массива: {a.Max()} по индексу [{i},{j}]");

            Console.WriteLine();
            //Console.WriteLine("Массив из файла:");
            //Console.WriteLine();
            //Console.WriteLine(b);
            a.SaveToFile(AppDomain.CurrentDomain.BaseDirectory + @"../../SaveArray.txt");


            Console.ReadKey();
        }
    }
}
