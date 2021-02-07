using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/*Добромыслов
 * 2. Разработать класс Message, содержащий следующие статические методы для обработки текста:
    а) Вывести только те слова сообщения, которые содержат не более n букв.
    б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
    в) Найти самое длинное слово сообщения.
    г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
    Продемонстрируйте работу программы на текстовом файле с вашей программой.
 */
namespace L5App02
{
    class Message
    {
        string a;

        /// <summary>
        /// Конструктор сообщения из строки
        /// </summary>
        /// <param name="a"></param>
        public Message(string a)
        {
            this.a = a;
        }

        /// <summary>
        /// Конструктор сообщения из файла
        /// </summary>
        /// <param name="r"></param>
        public Message(StreamReader r)
        {
            a = r.ReadLine();
        }

        /// <summary>
        /// Ограничить вывод сообщения только словами до n букв
        /// </summary>
        /// <param name="n">Максимальное количество букв</param>
        /// <returns></returns>
        public Message Limited(int n)
        {
            string[] separators = { ",", ".", "!", "?", ";", ":", " " };
            string res = string.Empty;
            string[] b = a.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < b.Length; i++)
            {
                if (b[i].Length < n)
                    res += b[i] + " ";
            }
            Message m = new Message(res);
            return m;
        }
        
        /// <summary>
        /// Удалить из сообщения слова с заданным символом на конце
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public Message DeleteWithLastChar(char c)
        {
            string[] separators = { " " };
            string res = string.Empty;
            string[] b = a.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < b.Length; i++)
            {
                if (b[i][b[i].Length - 1] != c)
                {
                    res += b[i] + " ";
                }
            }
            Message m = new Message(res);
            return m;
        }

        /// <summary>
        /// Возвращает самое длинное слово в сообщении
        /// </summary>
        /// <returns></returns>
        public string LongestWord()
        {
            string[] separators = { ",", ".", "!", "?", ";", ":", " " };
            string max = string.Empty;
            string[] b = a.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < b.Length; i++)
            {
                if (max.Length < b[i].Length)
                {
                    max = b[i];
                }
            }
            return max;
        }

        /// <summary>
        /// Возвращает строку из самых длинных слов в сообщении
        /// </summary>
        /// <returns></returns>
        public StringBuilder LongestWords()
        {
            string[] separators = { ",", ".", "!", "?", ";", ":", " " };
            string max = string.Empty;
            StringBuilder res = new StringBuilder();
            string[] b = a.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < b.Length; i++)
            {
                if (max.Length < b[i].Length)
                {
                    max = b[i];
                }
                else if (max.Length == b[i].Length)
                {
                    res.Append(b[i]+ " ");
                }
            }
            return res;
        }

        public override string ToString()
        {
            return $"{a}";
        }

        public void Save(string path)
        {
            StreamWriter w = new StreamWriter(path);
            w.WriteLine(a);
            w.Close();
        }
    }

    class L5App02
    {
        static void Main(string[] args)
        {
            StreamReader r = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "message.txt");
            Message m = new Message(r);
            int n = 5;
            char c = 'а';

            Console.WriteLine($"Сообщение: {m}");
            Console.WriteLine();
            Console.WriteLine($"Сообщение из слов меньше {n} букв: {m.Limited(n)}");
            Console.WriteLine($"Сообщение без слов с символом {c} на конце: {m.DeleteWithLastChar(c)}");
            Console.WriteLine($"Самое длинное слово в сообщении: {m.LongestWord()}");
            Console.WriteLine($"Самое длинные слова в сообщении: {m.LongestWords()}");
            Console.WriteLine();

            Console.WriteLine($"Введите свою строку для сохранения:");
            Message s = new Message(Console.ReadLine());
            s.Save(AppDomain.CurrentDomain.BaseDirectory + @"../../message_out.txt");
            
            Console.ReadKey();
            
        }
    }
}
