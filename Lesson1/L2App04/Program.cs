using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2App04
{
    /* Добромыслов
    *  Реализовать метод проверки логина и пароля. На вход подается логин и пароль. 
    *  На выходе истина, если прошел авторизацию, и ложь, если не прошел (Логин: root, Password: GeekBrains). 
    *  Используя метод проверки логина и пароля, написать программу: пользователь вводит логин и пароль, программа пропускает его дальше или не пропускает. 
    *  С помощью цикла do while ограничить ввод пароля тремя попытками.*/

    class Program
    {
        static void Main(string[] args)
        {
            Help.SetTitle("Авторизация");

            Auth();

            Console.ReadKey();
        }

        static void Auth()
        {
            int count = 0;
            bool loggedin = false;

            while (count < 3 && !loggedin)
            {
                count++;

                Console.Write("Введите логин: ");
                var login = Console.ReadLine();

                Console.Write("Введите пароль: ");
                var password = Console.ReadLine();

                if (login == "root" || password == "GeekBrains")
                {
                    loggedin = true;
                    Console.WriteLine("Добро пожаловать.");
                }
                else if (login != "root")
                {
                    Console.WriteLine($"Неверный логин. Осталось {3-count} попыток");
                }
                else if (password != "GeekBrains")
                {
                    Console.WriteLine($"Неверный пароль. Осталось {3-count} попыток");
                }
            }
            if (!loggedin)
            {
                Console.WriteLine($"Превышено количество ввода данных {count}. Доступ заблокирован.");
            }
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
