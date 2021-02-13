using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7
{
    public delegate void LastMoves();

    class Doubler
    {
        int value;
        int steps;
        int goal;
        Random r = new Random();
        Stack<LastMoves> lastMoves = new Stack<LastMoves>();

        public int Value { get { return value; } }
        public int Steps { get { return steps; } }
        public int Goal { get { return goal; } }

        public Doubler()
        {
            value = 0;
            steps = 0;
            goal = 0;
        }

        public void Plus()
        {
            steps++;
            value++;
            lastMoves.Push(new LastMoves(Minus));
        }

        public void Double()
        {
            steps++;
            value *= 2;
            lastMoves.Push(new LastMoves(DivideByTwo));
        }

        public void Minus()
        {
            value--;
        }

        public void DivideByTwo()
        {
            value /= 2;
        }

        public void Return()
        {
            LastMoves reverseFunc;
            if (lastMoves.Count != 0)
            {
                reverseFunc = lastMoves.Pop();
                reverseFunc();
                steps++;
            }
            return;
        }

        public void Reset()
        {
            steps = 0;
            value = 0;
            lastMoves.Clear();
        }

        public void GetGoal()
        {
            goal = r.Next(1, 1000);
        }

        public bool CheckGoal()
        {
            return value == goal ? true : false;
        }
    }
}
