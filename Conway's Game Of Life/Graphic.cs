using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conway_s_Game_Of_Life
{
    struct Graphic
    {
        public void RefreshConsole(bool[,] array)
        {
            Console.Clear();
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                    if (array[i, j])
                        Console.Write("X");
                    else
                        Console.Write(".");
                Console.WriteLine();
            }


        }

    }
}
