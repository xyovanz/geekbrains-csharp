using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L3App03
{
    /*Добромыслов
     3. *Описать класс дробей - рациональных чисел, являющихся отношением двух целых чисел. Предусмотреть методы сложения, вычитания, умножения и деления дробей. Написать программу, демонстрирующую все разработанные элементы класса. Достаточно решить 2 задачи. Все программы сделать в одном решении.
    ** Добавить проверку, чтобы знаменатель не равнялся 0. Выбрасывать исключение
    ArgumentException("Знаменатель не может быть равен 0");
    Добавить упрощение дробей.*/
    /// <summary>
    /// Класс Дробь.
    /// </summary>
    class Fraction
    {
        #region Private fields

        /// <summary>
        /// Числитель дроби
        /// </summary>
        private int _num;

        /// <summary>
        /// Знаменатель дроби
        /// </summary>
        private int _den;

        #endregion

        #region Public properties

        /// <summary>
        /// Числитель дроби
        /// </summary>
        public int Num
        {
            get
            {
                return _num;
            }
            set
            {
                _num = value;
            }
        }

        /// <summary>
        /// Знаменатель дроби
        /// </summary>
        public int Den
        {
            get
            {
                return _den;
            }
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException("Знаменатель не может быть равен 0");
                }
                else
                {
                    _den = value;
                }
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Дробь
        /// </summary>
        public Fraction()
        {
            _num = 0;
            _den = 1;
        }

        /// <summary>
        /// Дробь
        /// </summary>
        /// <param name="num">Числитель</param>
        /// <param name="den">Знаменатель</param>
        public Fraction(int num, int den)
        {
            _num = num;
            if (den == 0)
            {
                throw new ArgumentException("Знаменатель не может быть равен 0");
            }
            else
            {
                _den = den;
            }
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Сокращение дробей
        /// </summary>
        /// <param name="a">Ссылка на дробь</param>
        /// <returns>Сокращенная дробь</returns>
        public static Fraction Normalize(ref Fraction a)
        {

            int max = 0;
            
            if (a.Num > a.Den)
            {
                max = Math.Abs(a.Num);
            }
            else
            {
                max = Math.Abs(a.Den);
            }
                                    
            for (int i = max; i >= 2; i--)
            {
                if ((a.Num % i == 0) & (a.Den % i == 0))
                {
                    a.Num = a.Num / i;
                    a.Den = a.Den / i;
                }
            }

            if (a.Den < 0)
            {
                a.Num = -1 * a.Num;
                a.Den = Math.Abs(a.Den);
            }

            return a;
        }

        public Fraction Reversed()
        {
            if (Num < 0)
            {
                return new Fraction(-Den, Math.Abs(Num));
            }
            return new Fraction(Den, Num);
        }

        public static Fraction operator +(Fraction a, Fraction b)
        {
            Fraction res = new Fraction
            {
                Num = (a.Num * b.Den) + (a.Den * b.Num),
                Den = a.Den * b.Den
            };
            Normalize(ref res);
            return res;
        }

        public static Fraction operator -(Fraction a, Fraction b)
        {
            Fraction res = new Fraction
            {
                Num = (a.Num * b.Den) - (a.Den * b.Num),
                Den = a.Den * b.Den
            };
            Normalize(ref res);
            return res;
        }
        
        public static Fraction operator *(Fraction a, Fraction b)
        {
            Fraction res = new Fraction
            {
                Num = a.Num * b.Num,
                Den = a.Den * b.Den
            };
            Normalize(ref res);
            return res;
        }
        
        public static Fraction operator /(Fraction a, Fraction b)
        {
            Fraction res = new Fraction();
            res = a * b.Reversed();
            Normalize(ref res);
            return res;
        }


        public override string ToString()
        {
            if (_num == 0)
            {
                return "0";
            }
            if (_num < 0)
            {
                int numAbs = Math.Abs(_num);
                if (numAbs > _den)
                {
                    int o = numAbs / _den;
                    return $"-{o}({numAbs - (o * _den)}/{_den})";
                }
                return $"-({numAbs}/{_den})";
            }
            if (_num > _den)
            {
                int o = _num / _den;
                return $"{o}({_num - (o * _den)}/{_den})";
            }
            return $"({_num}/{_den})";
        }

        #endregion
    }

    class L3App3
    {
        static void Main(string[] args)
        {
            Fraction a = new Fraction(5, 2);
            Fraction b = new Fraction(-45, 24);

            Console.WriteLine($"Первая дробь: {a}");
            Console.WriteLine($"Вторая дробь: {b}");
            Console.WriteLine("");
            Console.WriteLine($"Сложение: {a + b}");
            Console.WriteLine($"Вычитание: {a - b}");
            Console.WriteLine($"Умножение: {a * b}");
            Console.WriteLine($"Деление: {a / b}");

            Console.ReadKey();
        }
    }
}
