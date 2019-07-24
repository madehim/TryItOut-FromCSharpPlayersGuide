using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{
    struct Graphics
    {
        public int GetTurn(int player, bool again)
        {
            while (true)
            {
                if (again)
                    Console.WriteLine("This column already full. Choose another, player " + player);
                else
                    Console.WriteLine("Make turn, player " + player + ".");
                try
                {
                    int turn = Convert.ToInt32(Console.ReadLine());
                    if (turn >= 1 && turn <= 7)
                        return turn - 1;
                    else
                        Console.WriteLine("Use numberse betweens 1 and 7");
                }
                catch
                {
                    Console.WriteLine("Use numberse betweens 1 and 7");
                }
            }
        }

        public void RefreshConsole(int[,] gf)
        {
            Console.Clear();
            for (int i = gf.GetLength(0) - 1; i >= 0; i--)
            {
                for (int j = 0; j < gf.GetLength(0); j++)
                {
                    switch (gf[i, j])
                    {
                        case (int)FieldStatus.free:
                            Console.Write(".");
                            break;
                        case (int)FieldStatus.firstPlayer:
                            Console.Write("X");
                            break;
                        case (int)FieldStatus.secondPlayer:
                            Console.Write("O");
                            break;
                    }
                }
                Console.WriteLine();
            }
        }

        public void Win(int player) => Console.WriteLine("Player " + player + " won!");

        public void Even() => Console.WriteLine("Even!");
    }
}
