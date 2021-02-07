using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

/*Добромыслов 
 * 3. *Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой. Регистр можно не учитывать:
    а) с использованием методов C#;
    б) *разработав собственный алгоритм.
    Например:
    badc являются перестановкой abcd.*/
namespace L5App03
{
    class L5App03
    {
        static void Main(string[] args)
        {
            string aS = "abcd";
            string bS = "bdac";
            string сS = "gfds";

            char[] aChar = aS.ToArray();
            char[] bChar = bS.ToArray();
            char[] cChar = сS.ToArray();

            Array.Sort(aChar, StringComparer.InvariantCultureIgnoreCase);
            Array.Sort(bChar, StringComparer.InvariantCultureIgnoreCase);
            Array.Sort(cChar, StringComparer.InvariantCultureIgnoreCase);

            string a = new string(aChar);
            string b = new string(bChar);
            string с = new string(cChar);
            
            Console.WriteLine($"Является ли строка {bS} перестановкой {aS}: {a.Contains(b)}");
            Console.WriteLine($"Является ли строка {сS} перестановкой {aS}: {a.Contains(с)}");

            Console.ReadKey();
        }
    }
}
