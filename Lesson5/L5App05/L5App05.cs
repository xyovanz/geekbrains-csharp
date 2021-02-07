using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

/*Добромыслов
 5. **Написать игру «Верю. Не верю». 
 В файле хранятся вопрос и ответ, правда это или нет. 
 Например: «Шариковую ручку изобрели в древнем Египте», «Да». Компьютер загружает эти данные, случайным образом выбирает 5 вопросов и задаёт их игроку. 
 Игрок отвечает Да или Нет на каждый вопрос и набирает баллы за каждый правильный ответ. Список вопросов ищите во вложении или воспользуйтесь интернетом.*/

namespace L5App05
{
    class Game
    {
        Question[] a;
        int Length;
        private static char[] separators = { '"' };

        public Game(string path)
        {
            int l = 0;
            StreamReader r = new StreamReader(path);
            StreamReader x = new StreamReader(path);
            
            Regex reg = new Regex("\"(.*?)\"");
            while (r.ReadLine() != null)
            {
                l++;
            }
            Length = l;
            a = new Question[l];

            for (int i = 0; i < l; i++)
            {
                string[] b = x.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);
                Question n = new Question(b);
                a[i] = n;
            }

            r.Close();
            x.Close();
        }

        public void PlayGame(int n)
        {
            Random r = new Random();
            int score = 0;
            for (int i = 0; i < n; i++)
            {
                int j = r.Next(a.Length);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(a[j].question);
                string answer = Console.ReadLine();
                if (answer.ToLower() == a[j].answer.ToLower())
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Ответ верный!");
                    score++;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Ответ не верный!");
                }
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Игра завершена. Ваш счет: {score}");
        }

        public void PrintAllQuestions()
        {
            foreach (Question q in a)
            {
                Console.WriteLine($"{q.question}");
            }
        }
    }

    class Question
    {
        string[] a;
        public string question;
        public string answer;

        public Question(string[] s)
        {
            a = s;
            question = s[0];
            answer = s[2];
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
            return $"Вопрос: {question} | Ответ: {answer}";
        }
    }

    class L5App05
    {
        static void Main(string[] args)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "game.txt";
            Game g = new Game(path);

            int num = 5;
            g.PlayGame(num);

            Console.ReadLine();
        }
    }
}
