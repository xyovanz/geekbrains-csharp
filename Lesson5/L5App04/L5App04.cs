using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/*Добромыслов 
 4. Задача ЕГЭ.
*На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней
школы. В первой строке сообщается количество учеников N, которое не меньше 10, но не
превосходит 100, каждая из следующих N строк имеет следующий формат:
<Фамилия> <Имя> <оценки>,
где <Фамилия> — строка, состоящая не более чем из 20 символов, <Имя> — строка, состоящая не
более чем из 15 символов, <оценки> — через пробел три целых числа, соответствующие оценкам по
пятибалльной системе. <Фамилия> и <Имя>, а также <Имя> и <оценки> разделены одним пробелом.
Пример входной строки:
Иванов Петр 4 5 3
Требуется написать как можно более эффективную программу, которая будет выводить на экран
фамилии и имена трёх худших по среднему баллу учеников. Если среди остальных есть ученики,
набравшие тот же средний балл, что и один из трёх худших, следует вывести и их фамилии и имена.*/

namespace L5App04
{
    class Pupils
    {
        public Pupil[] a;
        public int Length;
        private static string[] separators = { " " };

        public Pupils(StreamReader r)
        {
            int.TryParse(r.ReadLine(), out int l);

            Length = l;
            a = new Pupil[l];

            if (l < 10 ^ l > 100)
            {
                throw new Exception("Журнал должен быть размером от 10 до 100 записей");
            }

            for (int i = 0; i < l; i++)
            {
                string[] b = r.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
                Pupil n = new Pupil(b);
                a[i] = n;
            }
            r.Close();
        }

        private void SortByAverageAscending()
        {
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[i].Average() > a[j].Average())
                    {
                        var temp = a[i];
                        a[i] = a[j];
                        a[j] = temp;
                    }
                }
            }
        }

        public void WorstPerformingNames()
        {
            SortByAverageAscending();
            for (int i = 0; i < a.Length - 1; i++)
            {
                string output = $"{a[i].surname} {a[i].name}";
                if (i < 3)
                {
                    Console.WriteLine(output);
                }
                else if (i > 3 && (a[2].Average() == a[i].Average()))
                {
                    Console.WriteLine(output);
                }
            }
        }

        public Pupil[] this[int index]
        {
            get { return a; }
            set
            {
                a = value;
            }
        }

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < Length; i++)
            {
                s += $"{a[i]}\n";
            }
            return s;
        }
    }

    class Pupil
    {
        string[] a;
        public string name;
        public string surname;
        public int[] ranks = new int[3];

        private static string[] separators = { " " };

        public Pupil(string[] s)
        {
            a = s;
            string[] b = new string[a.Length];

            for (int i = 0; i < a.Length; i++)
            {
                b = a[i].Split(separators, StringSplitOptions.RemoveEmptyEntries);
                surname = s[0];
                name = s[1];
                ranks[0] = int.Parse(s[2]);
                ranks[1] = int.Parse(s[3]);
                ranks[2] = int.Parse(s[4]);
            }
        }

        public double Average()
        {
            double sum = ranks[0] + ranks[1] + ranks[2];
            return sum / 3;
        }

        public string[] this[int index]
        {
            get { return a; }
            set
            {
                a = value;
            }
        }

        public override string ToString()
        {
            return $"{name} {surname} {ranks[0]} {ranks[1]} {ranks[2]}";
        }
    }

    class L5App04
    {
        static void Main(string[] args)
        {
            StreamReader r = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "pupils.txt");
            Pupils p = new Pupils(r);

            Console.WriteLine("Журнал учеников:");
            Console.WriteLine(p);
            Console.WriteLine();
            Console.WriteLine($"Худшие ученики по среднему баллу: ");
            p.WorstPerformingNames();

            Console.ReadKey();
        }
    }
}
