using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Text.RegularExpressions;

/*Добромыслов
 1. Создать программу, которая будет проверять корректность ввода логина. 
 Корректным логином будет строка от 2 до 10 символов, содержащая только буквы латинского алфавита или цифры, при этом цифра не может быть первой:
    а) без использования регулярных выражений;
    б) с использованием регулярных выражений.*/
namespace L5App01
{
    class L5App01
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Выберите решение задания (1 - без ReGex, 2 - с Regex, 0 - выход): ");
                var s = int.TryParse(Console.ReadLine(), out int n);
                switch (n)
                {
                    case 1:
                        NoRegex();
                        break;
                    case 2:
                        WithRegex();
                        break;
                    case 0:
                        Console.ReadKey();
                        return;
                }
            }

        }

        static void NoRegex()
        {
            while (true) 
            {
                Console.Write("Введите логин: ");
                string login = Console.ReadLine();
                if (2 <= login.Length && login.Length <= 10)
                {
                    foreach (char c in login)
                    {
                        char tl = char.ToLower(c);
                        if (((tl >= 'a') && (tl <= 'z')) ^ (((int)char.GetNumericValue(tl) >= 0) && ((int)char.GetNumericValue(tl) <= 9)))
                        {
                            Console.WriteLine("Верный логин");
                            Console.ReadKey();
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Логин должен состоять из латинских cимволов или цифр");
                            Console.ReadKey();
                            return;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Логин должен быть размером от 2 до 10 символов");
                }
            }
        }

        static void WithRegex()
        {
            while (true)
            {
                Console.Write("Введите логин: ");
                string login = Console.ReadLine();
                Regex pattern = new Regex(@"^[a-zA-Z0-9]{2,10}$");
                if (pattern.IsMatch(login))
                {
                    Console.WriteLine("Верный логин");
                    Console.ReadKey();
                    return;
                }
                else
                {
                    Console.WriteLine("Логин должен быть размером от 2 до 10 символов и состоять из латинских cимволов или цифр");
                    Console.ReadKey();
                    return;
                }
            }
        }
    }
}
