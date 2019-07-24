using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PigDice
{
    class GameTable
    {
        internal List<Player> PlayersList;
        Dice Dice1 { get; set; }
        Dice Dice2 { get; set; }
        int numPlayerTurn;
        Graphic Graphics;

        public GameTable(List<Player> playersList, Dice dice1, Dice dice2)
        {
            numPlayerTurn = 0;
            PlayersList = playersList;
            Dice1 = dice1;
            Dice2 = dice2;
            GetCmd();
        }

        public GameTable(int playerCount)
        {
            if (playerCount > 0)
            {
                numPlayerTurn = 0;
                PlayersList = new List<Player>();
                for (int i = 0; i < playerCount; i++)
                {
                    string tmpName = Graphics.GetPlayerName(i);
                    Player tmpPlayer = new Player(tmpName);
                    PlayersList.Add(tmpPlayer);
                }
                Dice1 = new Dice();
                Thread.Sleep(2);
                Dice2 = new Dice();
                GetCmd();
            }
        }

        private void NextPlayer()
        {
            numPlayerTurn = (numPlayerTurn < PlayersList.Count - 1) ? ++numPlayerTurn : 0;
        }

        public void Hold()
        {
            PlayersList[numPlayerTurn].OverallScore += PlayersList[numPlayerTurn].TurnScore;
            PlayersList[numPlayerTurn].TurnScore = 0;
            NextPlayer();
            GetCmd(Graphics.ChooseCommand(PlayersList, numPlayerTurn));
        }

        public void Turn()
        {
            int dice1 = Dice1.Roll();
            int dice2 = Dice2.Roll();
            if (dice1 != 1 && dice2 != 1)
            {
                PlayersList[numPlayerTurn].TurnScore += dice1 + dice2;
                Graphics.TurnInfo(PlayersList[numPlayerTurn], dice1, dice2);
                if (PlayersList[numPlayerTurn].OverallScore + PlayersList[numPlayerTurn].TurnScore >= 100)
                {
                    Graphics.Win(PlayersList[numPlayerTurn]);
                }
                else
                {
                    GetCmd(Graphics.ChooseCommand(PlayersList[numPlayerTurn]));
                }
            }
            else
            {
                PlayersList[numPlayerTurn].TurnScore = 0;
                Graphics.TurnInfo(PlayersList[numPlayerTurn], dice1, dice2);
                Thread.Sleep(1500);
                NextPlayer();
                GetCmd(Graphics.ChooseCommand(PlayersList, numPlayerTurn));
            }
        }

        public void GetCmd()
        {
            string cmd = Graphics.ChooseCommand(PlayersList, numPlayerTurn);
            if (cmd == "turn")
                Turn();
            else
                Hold();
        }

        public void GetCmd(string cmd)
        {
            if (cmd == "turn")
                Turn();
            else
                Hold();
        }

    }
}
