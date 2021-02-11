/*Добромыслов
 3. Переделать программу «Пример использования коллекций» для решения следующих задач:
а) Подсчитать количество студентов учащихся на 5 и 6 курсах;
б) подсчитать сколько студентов в возрасте от 18 до 20 лет на каком курсе учатся (частотный массив);
в) отсортировать список по возрасту студента;
г) *отсортировать список по курсу и возрасту студента;
д) разработать единый метод подсчета количества студентов по различным параметрам выбора с помощью делегата и методов предикатов.*/


using System;
using System.Collections.Generic;
using System.IO;

namespace L6App03
{
    delegate int Comp(Student s1, Student s2);
    class Student
    {
        public string lastName;
        public string firstName;
        public string university;
        public string faculty;
        public int course;
        public string department;
        public int group;
        public string city;
        public int age;
        // Создаем конструктор
        public Student(string firstName, string lastName, string university, string faculty, string department, int age, int course, int group, string city)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.university = university;
            this.faculty = faculty;
            this.department = department;
            this.course = course;
            this.age = age;
            this.group = group;
            this.city = city;
        }
    }
    class Program
    {
        static int Age(Student st1, Student st2)          // Создаем метод для сравнения для экземпляров
        {
            return string.Compare(st1.age.ToString(), st2.age.ToString());          // Сравниваем две строки
        }
        static int CourseAndAge(Student st1, Student st2)
        {
            if (st1.course > st2.course)
                return 1;
            if (st1.course < st2.course)
                return -1;
            if (st1.age > st2.age)
                return 1;
            if (st1.age < st2.age)
                return -1;
            return 0;
        }
        static void SortList(List<Student> list, Comp c)
        {
            list.Sort(new Comparison<Student>(c));
            if (c == Age)
            {
                Console.WriteLine("Сортировка по возрасту");
                foreach (var v in list) Console.WriteLine($"{v.firstName}, возраст {v.age}");
            }
            else if (c == CourseAndAge)
            {
                Console.WriteLine("Сортировка по курсу и возрасту");
                foreach (var v in list) Console.WriteLine($"{v.firstName}, возраст {v.age}, курс {v.course}");
            }
        }
        static void Main(string[] args)
        {
            int bakalavr = 0;
            int magistr = 0;
            int course5to6 = 0;
            Dictionary<int, int> age18to20course = new Dictionary<int, int>();
            List<Student> list = new List<Student>();                             // Создаем список студентов
            DateTime dt = DateTime.Now;
            StreamReader sr = new StreamReader("students.csv");
            while (!sr.EndOfStream)
            {
                try
                {
                    string[] s = sr.ReadLine().Split(';');
                    // Добавляем в список новый экземпляр класса Student
                    Student st = new Student(s[0], s[1], s[2], s[3], s[4], int.Parse(s[5]), int.Parse(s[6]), int.Parse(s[7]), s[8]);
                    list.Add(st);
                    // Одновременно подсчитываем количество бакалавров и магистров
                    if (st.course < 5) bakalavr++; else magistr++;

                    if (st.course == 5 ^ st.course == 6) course5to6++;
                    if (st.age >= 18 ^ st.age <= 20)
                    {
                        if (age18to20course.ContainsKey(st.course))
                            age18to20course[st.course] += 1;
                        else
                            age18to20course.Add(st.course, 1);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Ошибка!ESC - прекратить выполнение программы");
                    // Выход из Main
                    if (Console.ReadKey().Key == ConsoleKey.Escape) return;
                }
            }
            sr.Close();
            Console.WindowHeight = 40;
            Console.WriteLine($"Всего студентов: {list.Count}");
            Console.WriteLine($"Магистров: {magistr}");
            Console.WriteLine($"Бакалавров: {bakalavr}");
            Console.WriteLine($"Студентов с 5 по 6 курс: {course5to6}");
            Console.ReadKey();

            var keys = age18to20course.Keys;
            string result = string.Format("{0,-10} {1,-10}\n", "Курс", "Количество студентов");
            foreach (int key in keys)
                result += string.Format("{0,-10} {1,-10:N0}\n", key, age18to20course[key]);
            Console.WriteLine($"\n{result}");

            SortList(list, Age);
            Console.WriteLine();
            SortList(list, CourseAndAge);

            Console.WriteLine();
            Console.WriteLine(DateTime.Now - dt);
            Console.ReadKey();
        }
    }
}