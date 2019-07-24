using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigDice
{
    class Player
    {
        internal string Name { get; }
        public int OverallScore { get; set; }
        public int TurnScore { get; set; }

        public Player(string name)
        {
            Name = name;
            OverallScore = 0;
            TurnScore = 0;
        }
    }
}
