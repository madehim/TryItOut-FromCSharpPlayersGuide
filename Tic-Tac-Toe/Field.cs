using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    class Field
    {
        bool isfree = true;
        bool tic = false;
        bool tac = false;

        public Field()
        {
            Isfree = true;
            Tic = false;
            Tac = false;
        }

        public bool Tac { get => tac; set => tac = value; }
        public bool Tic { get => tic; set => tic = value; }
        public bool Isfree { get => isfree; set => isfree = value; }
    }
}
