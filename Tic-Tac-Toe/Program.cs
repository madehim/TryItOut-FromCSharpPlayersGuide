using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Enter first player name:");
            string tempName = Console.ReadLine();
            Player player1 = new Player(tempName, true, false);
            Console.WriteLine("Enter second player name:");
            tempName = Console.ReadLine();
            Player player2 = new Player(tempName, false, true);

            while (true)
            {

                GameFields gf = new GameFields();
                bool turn = true;
                bool endGame = false;
                while (true)
                {
                    gf.Refresh();
                    Console.WriteLine($"Use numbers from 1 to {gf.N * gf.N} for turn.");
                    if (turn)
                    {
                        Console.WriteLine($"{player1.Name}'s turn.");
                        while (true)
                        {
                            int i = Convert.ToInt32(Console.ReadLine()) - 1;
                            if (i >= 0 && i <= gf.N * gf.N - 1)
                            {
                                if (!gf.Turn((byte)i, player1))
                                    Console.WriteLine("This field isn't empty. Try another");
                                else
                                    break;
                            }
                            else
                                Console.WriteLine($"Use numbers from 1 to {gf.N * gf.N} for turn.");
                        }
                        string temp = gf.CheckCondition(player1.TikPlayer);
                        switch (temp)
                        {
                            case "Player won!":
                                gf.Refresh();
                                Console.WriteLine($"{player1.Name} won!");
                                endGame = true;
                                break;
                            case "No-one won":
                                gf.Refresh();
                                Console.WriteLine("Draw");
                                endGame = true;
                                break;
                            default:
                                break;
                        }
                        if (endGame)
                            break;
                        turn = false;
                    }
                    else
                    {
                        Console.WriteLine($"{player2.Name}'s turn.");
                        while (true)
                        {
                            int i = Convert.ToInt32(Console.ReadLine()) - 1;
                            if (i >= 0 && i <= gf.N * gf.N - 1)
                            {
                                if (!gf.Turn((byte)i, player2))
                                    Console.WriteLine("This field isn't empty. Try another");
                                else
                                    break;
                            }
                            else
                                Console.WriteLine($"Use numbers from 1 to {gf.N * gf.N} for turn.");
                        }

                        string temp = gf.CheckCondition(player2.TikPlayer);
                        switch (temp)
                        {
                            case "Player won!":
                                gf.Refresh();
                                Console.WriteLine($"{player2.Name} won!");
                                endGame = true;
                                break;
                            case "No-one won":
                                gf.Refresh();
                                Console.WriteLine("Draw");
                                endGame = true;
                                break;
                            default:
                                break;
                        }
                        if (endGame)
                            break;
                        turn = true;
                    }
                }

                Console.WriteLine("Wanna start new game? y for yes, any others for no");
                if (Console.ReadLine() != "y")
                    break;
            }
        }
    }
}
