using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L3App01B
{
    /* Добромыслов
     б) Дописать класс Complex, добавив методы вычитания и произведения чисел. Проверить работу класса;*/
    class Complex
    {

        #region Private Fields

        /// <summary>
        /// Мнимая часть комплексного числа
        /// </summary>
        private double _im;

        /// <summary>
        /// Действительная часть комплексного числа
        /// </summary>
        private double _re;

        #endregion

        #region Public Properties

        /// <summary>
        /// Мнимая часть комплексного числа
        /// </summary>
        public double Im
        {
            get
            {
                return _im;
            }

            set
            {
                _im = value;
            }
        }

        /// <summary>
        /// Действительная часть комплексного числа
        /// </summary>
        public double Re
        {
            get
            {
                return _re;
            }

            set
            {
                _re = value;
            }
        }

        #endregion

        #region Constructors

        public Complex()
        {
        }
        /// <summary>
        /// Комплексное число
        /// </summary>
        /// <param name="re">Действительная часть комплексного числа</param>
        /// <param name="im">Мнимая часть комплексного числа</param>
        public Complex(double re, double im)
        {
            _re = re;
            _im = im;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Перегрузка оператора +, сложение комплексных чисел
        /// </summary>
        /// <param name="complex1">Комплексное число</param>
        /// <param name="complex2">Комплексное число</param>
        /// <returns>Результат сложения комплексных чисел</returns>
        public static Complex operator +(Complex complex1, Complex complex2)
        {
            return new Complex { Re = complex1.Re + complex2.Re, Im = complex1.Im + complex2.Im };
        }

        /// <summary>
        /// Перегрузка оператора -, сложение вычитание чисел
        /// </summary>
        /// <param name="complex1">Комплексное число</param>
        /// <param name="complex2">Комплексное число</param>
        /// <returns>Результат вычитания комплексных чисел</returns>
        public static Complex operator -(Complex complex1, Complex complex2)
        {
            return new Complex { Re = complex1.Re - complex2.Re, Im = complex1.Im - complex2.Im };
        }

        /// <summary>
        /// Перегрузка оператора *, сложение комплексных чисел
        /// </summary>
        /// <param name="complex1">Комплексное число</param>
        /// <param name="complex2">Комплексное число</param>
        /// <returns>Результат умножения комплексных чисел</returns>
        public static Complex operator *(Complex complex1, Complex complex2)
        {
            return new Complex { Re = complex1.Re * complex2.Re, Im = complex1.Im * complex2.Im };
        }

        public override string ToString()
        {
            if (_im < 0)
            {
                _im = Math.Abs(_im);
                return $"({_re} - {_im}i)";
            }
            else
            {
                return $"({_re} + {_im}i)";
            }
        }

        #endregion

    }
    class L3App1TaskB
    {
        static void Main(string[] args)
        {
            Complex c1 = new Complex(2, -3);
            Complex c2 = new Complex(-5, 7);

            Console.WriteLine($"Работа с комплексными числами {c1} и {c2}");
            Console.WriteLine($"Сложение: {c1+c2}");
            Console.WriteLine($"Вычитание: {c1-c2}");
            Console.WriteLine($"Умножение: {c1*c2}");

            Console.ReadKey();
        }
    }
}
