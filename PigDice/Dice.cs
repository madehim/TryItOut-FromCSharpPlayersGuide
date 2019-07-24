using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigDice
{
    class Dice
    {
        Random roll;
        internal int Number { get; set; }

        public Dice(int add)
        {
            roll = new Random(DateTime.Now.Millisecond + add);
        }
        public Dice()
        {
            roll = new Random(DateTime.Now.Millisecond);
        }

        public int Roll()
        {
            Number = roll.Next(1, 7);
            return Number;
        }

        public int Roll(int min, int max)
        {
            Number = roll.Next(min, max + 1);
            return Number;
        }
    }
}
