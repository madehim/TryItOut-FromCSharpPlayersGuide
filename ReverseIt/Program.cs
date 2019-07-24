using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseIt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Reverse It Game!");
            Console.WriteLine("Write number for 2 to 9 for reverse from 1 to number");
            while (true)
            {
                int[] gameArray = CreateArray();
                bool newGame = false;
                while (true)
                {
                    WriteArray(gameArray);
                    if (CheckWin(gameArray))
                    {
                        Console.WriteLine("You Win. Wanna start new game? y/n");
                        string temp = Console.ReadLine();
                        if (temp == "y")
                            newGame = true;
                        break;
                    }
                    Console.WriteLine("Write number");
                    string numStr = Console.ReadLine();
                    try
                    {
                        int num = Convert.ToInt32(numStr);
                        gameArray = Reverse(gameArray, num - 1);
                    }
                    catch
                    {
                        Console.WriteLine("Plese, write number");
                    }
                    Console.Clear();
                }
                if (newGame)
                    newGame = false;
                else
                    break;
            }
        }

        static public int[] Reverse(int[] Array, int position)
        {
            int tmp = 0;
            for (int i = 0; i < (position + 1) / 2; i++)
            {
                tmp = Array[i];
                Array[i] = Array[position - i];
                Array[position - i] = tmp;
            }
            return Array;
        }

        static public bool CheckWin(int[] Array)
        {
            for (int i = 0; i < Array.Length; i++)
                if (!(Array[i] == i + 1))
                    return false;
            return true;
        }

        static public void WriteArray(int[] Array)
        {
            Console.WriteLine();
            for (int i = 0; i < Array.Length; i++)
                Console.Write(Array[i].ToString() + " ");
        }

        static public int[] CreateArray()
        {
            int count = 9;
            List<int> notInGameArray = new List<int>();
            for (int i = 0; i < count; i++)
                notInGameArray.Add(i + 1);
            int[] newGameArray = new int[count];
            Random rnd = new Random(DateTime.Now.Millisecond + DateTime.Now.Minute);
            while (true)
            {
                int tmp = rnd.Next(1, 10);
                if (notInGameArray.Contains(tmp))
                {
                    newGameArray[count - 1] = tmp;
                    count--;
                    notInGameArray.Remove(tmp);
                    if (count == 0)
                        break;
                }
            }
            return newGameArray;
        }
    }
}
