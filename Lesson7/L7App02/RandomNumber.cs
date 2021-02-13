using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L7App02
{
    class RandomNumber
    {
        int value;
        int steps;
        bool started;

        public int Value { get { return value; } }
        public int Steps { get { return steps; } }
        public bool Started { get { return started; } }

        public RandomNumber()
        {
            value = 0;
            steps = 0;
            started = false;
        }

        public void StartGame(int max)
        {
            Random r = new Random();
            steps = 0;
            value = r.Next(1, max);
            started = true;
        }

        public void StopGame()
        {
            value = 0;
            steps = 0;
            started = false;
        }

        public void CheckNumber(int userInput, out bool check, out string msg)
        {
            if (userInput == value)
            {
                check = true;
                msg = $"Поздравляем! Вы угадали загаданное число {value} за {steps} попыток!";
            }
            else if (userInput < value)
            {
                check = false;
                steps++;
                msg = $"Введенное число меньше загаданного!";
            }
            else
            {
                check = false;
                steps++;
                msg = $"Введенное число больше загаданного!";
            }
        }
    }
}
