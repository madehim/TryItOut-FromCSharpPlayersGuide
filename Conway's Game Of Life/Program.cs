using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Conway_s_Game_Of_Life
{
    class Program
    {
        static bool[,] thisGeneration;
        //static bool[,] nextGeneration;
        static string path;


        static void Main(string[] args)
        {
            Graphic gc = new Graphic();
            LoadField lf;
            Console.WriteLine("Enter path to file");
            while (true)
            {
                path = Console.ReadLine();
                lf = new LoadField(path);
                thisGeneration = lf.LoadFile();
                if (thisGeneration.Length > 2)
                    break;
                else
                    Console.WriteLine("Something going wrong");
            }
            while (true)
            {
                gc.RefreshConsole(thisGeneration);
                Thread.Sleep(1500);
                thisGeneration = NewGeneration(thisGeneration);
            }
        }


        static bool[,] NewGeneration(bool[,] oldGeneration)
        {
            bool[,] newGenArray = new bool[oldGeneration.GetLength(0), oldGeneration.GetLength(1)];
            for (int i = 0; i < oldGeneration.GetLength(0); i++)
                for (int j = 0; j < oldGeneration.GetLength(1); j++)
                    if (oldGeneration[i, j] == true)
                        newGenArray[i, j] = LiveOrDead(i, j, true);
                    else
                        newGenArray[i, j] = LiveOrDead(i, j, false);
            return newGenArray;
        }

        static bool LiveOrDead(int i, int j, bool isAlive)
        {
            int liveAround = 0;
            if (i + 1 < thisGeneration.GetLength(0))//check square around
            {
                if (thisGeneration[i + 1, j] == true)
                    liveAround++;
                if (j - 1 >= 0)
                    if (thisGeneration[i + 1, j - 1] == true)
                        liveAround++;
                if (j + 1 < thisGeneration.GetLength(1))
                    if (thisGeneration[i + 1, j + 1] == true)
                        liveAround++;
            }
            if (i - 1 >= 0)
            {
                if (thisGeneration[i - 1, j] == true)
                    liveAround++;
                if (j - 1 >= 0)
                    if (thisGeneration[i - 1, j - 1] == true)
                        liveAround++;
                if (j + 1 < thisGeneration.GetLength(1))
                    if (thisGeneration[i - 1, j + 1] == true)
                        liveAround++;
            }
            if (j + 1 < thisGeneration.GetLength(1))
                if (thisGeneration[i, j + 1] == true)
                    liveAround++;
            if (j - 1 >= 0)
                if (thisGeneration[i, j - 1] == true)
                    liveAround++;
            if (isAlive) //dead or alive
            {
                if (liveAround > 3 || liveAround < 2)
                    return false;
                else
                    return true;
            }
            else
            {
                if (liveAround == 3)
                    return true;
                else
                    return false;
            }
        }

    }
}
