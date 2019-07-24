using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigDice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter player's count");
            try
            {
                int playersCount = Convert.ToInt32(Console.ReadLine());
                GameTable gt = new GameTable(playersCount);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Console.ReadKey();
            }
        }
    }
}
