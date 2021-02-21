/*Добромыслов
 3. *Написать программу-преобразователь из CSV в XML-файл с информацией о студентах (6 урок).*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace L8App03
{
    class L8App03
    {
        static void Converter(string fileNameOpen, string fileNameSave)
        {
            string[] lines = File.ReadAllLines(fileNameOpen);
            string[] headers = { "Name", "Surname", "University", "Faculty", "Department", "Age", "Course", "Group", "City" };

            var xml = new XElement("Students",
               lines.Where((line, index) => index > 0).Select(line => new XElement("StudentIndo",
                  line.Split(';').Select((column, index) => new XElement(headers[index], column)))));

            xml.Save(fileNameSave);
        }

        static void Main(string[] args)
        {
            Converter("..\\..\\students.csv", "..\\..\\students.xml");

            Console.WriteLine("CSV > XML процедура завершена");
            Console.ReadLine();
        }
    }
}
