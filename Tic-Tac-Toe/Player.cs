using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    class Player
    {
        string name;
        int winCount = 0;
        int loseCount = 0;
        bool tikPlayer = false;
        bool tacPlayer = false;
        

        public Player(string name, bool tikPlayer, bool tacPlayer)
        {
            if (tikPlayer)
                TikPlayer = true;
            else if (tacPlayer)
                TacPlayer = true;
            else if ((tikPlayer && tacPlayer) || !(tikPlayer && tacPlayer))
                    Console.WriteLine("Choose one of the sides");
            Name = name;

        }


        public bool TikPlayer { get => tikPlayer; set => tikPlayer = value; }
        public bool TacPlayer { get => tacPlayer; set => tacPlayer = value; }
        public string Name { get => name; set => name = value; }
    }
}
