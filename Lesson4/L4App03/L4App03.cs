using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace L4App03
{
    /*Добромыслов
     3. Решить задачу с логинами из предыдущего урока, только логины и пароли считать из файла в массив. 
     Создайте структуру Account, содержащую Login и Password.*/
    class L4App03
    {
        struct Account
        {
            public string login;
            public string password;

            public void Load(string fileName)
            {
                if (!File.Exists(fileName))
                    throw new FileNotFoundException();
                StreamReader r = new StreamReader(fileName);
                login = r.ReadLine();
                password = r.ReadLine();
                r.Close();
            }
        }

        static void Main(string[] args)
        {
            Account a = new Account();
            a.Load(AppDomain.CurrentDomain.BaseDirectory + "Account.txt");
            Auth(a);

            Console.ReadKey();
        }
        
        static void Auth(Account a)
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

                if (login == a.login && password == a.password)
                {
                    loggedin = true;
                    Console.WriteLine("Добро пожаловать.");
                }
                else if (login != a.login)
                {
                    Console.WriteLine($"Неверный логин. Осталось {3 - count} попыток");
                }
                else if (password != a.password)
                {
                    Console.WriteLine($"Неверный пароль. Осталось {3 - count} попыток");
                }
            }
            if (!loggedin)
            {
                Console.WriteLine($"Превышено количество ввода данных {count}. Доступ заблокирован.");
            }
        }
    }
}
