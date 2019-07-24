using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigDice
{
    struct Graphic
    {
        void PlayerListToScreen(List<Player> playersList)
        {
            Console.Clear();
            Console.Write("Players:   ");
            for (int i = 0; i < playersList.Count; i++)
                Console.Write(playersList[i].Name + " ");
            Console.WriteLine();
            Console.Write("OverScore: ");
            for (int i = 0; i < playersList.Count; i++)
                Console.Write(playersList[i].OverallScore.ToString().PadRight(playersList[i].Name.Length + 1));
        }

        public string GetPlayerName(int i)
        {
            Console.WriteLine($"Enter player's {i} nickname");
            string tmp = Console.ReadLine();
            return tmp;
        }

        public void TurnInfo(Player player, int dice1, int dice2)
        {
            Console.WriteLine();
            Console.Write(player.Name + " turn's. Dice 1 = " + dice1 + ", Dice 2 = " + dice2 + ". Turn score =" + player.TurnScore);
        }

        public void Win(Player player)
        {
            Console.WriteLine();
            Console.WriteLine("Player " + player.Name + " won! Press anykey for exit");
            Console.ReadKey();
        }

        public string ChooseCommand(Player player)
        {
            string cmd = "";
            Console.WriteLine();
            while (true)
            {
                Console.WriteLine(player.Name + " choose: Turn or Hold");
                cmd = Console.ReadLine();
                if (cmd.ToLower() == "turn" || cmd.ToLower() == "hold")
                    return cmd.ToLower();
            }
        }

        public string ChooseCommand(List<Player> playersList, int currentPlayer)
        {
            PlayerListToScreen(playersList);
            return ChooseCommand(playersList[currentPlayer]);
        }
    }
}
