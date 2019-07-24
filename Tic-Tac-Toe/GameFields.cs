using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    class GameFields
    {
        Field[] gameField;
        int n = 3;
        int freeFieldCount;

        
        public int N { get => n;  }

        public GameFields()
        {
            gameField = new Field[n * n];
            for (int i = 0; i < gameField.Length; i++)
                gameField[i] = new Field();
            freeFieldCount = n * n;
        }

        public bool Turn(byte i, Player player)
        {
            if (gameField[i].Isfree)
            {

                gameField[i].Isfree = false;
                if (player.TacPlayer)
                    gameField[i].Tac = true;
                else
                    gameField[i].Tic = true;
                freeFieldCount--;
                return true;
            }
            return false;
        }

        bool WinCondition(bool tic, Field[] field)
        {
            if (tic)
            {
                for (int i = 0; i < n * n; i += n)
                {
                    bool temp = true;
                    for (int j = 0; j < n; j++)
                        temp = temp && field[i + j].Tic;
                    if (temp)
                        return true;
                }
                    //if (field[i].Tic && field[i + 1].Tic && field[i + 2].Tic)  only for n=3
                    //    win = true;
                for (int i = 0; i < n; i++)
                {
                    bool temp = true;
                    for (int j = 0; j < n * n; j+=n)
                        temp = temp && field[i + j].Tic;
                    if (temp)
                        return true;
                }
                //if (field[i].Tic && field[i + n].Tic && field[i + n + n].Tic) only for n=3
                //    win = true;
                bool newTemp = true;
                for (int i = 0; i < n * n; i += (n + 1))
                    newTemp = newTemp && field[i].Tic;
                if (newTemp)
                    return true;
                newTemp = true;
                for (int i = 0; i < (n * n) - (n - 1); i += (n - 1))
                    newTemp = newTemp && field[i].Tic;
                if (newTemp)
                    return true;
                return false;
            }
            else
            {
                for (int i = 0; i < n * n; i += n)
                {
                    bool temp = true;
                    for (int j = 0; j < n; j++)
                        temp = temp && field[i + j].Tac;
                    if (temp)
                        return true;
                }
                for (int i = 0; i < n; i++)
                {
                    bool temp = true;
                    for (int j = 0; j < n * n; j += n)
                        temp = temp && field[i + j].Tac;
                    if (temp)
                        return true;
                }
                bool newTemp = true;
                for (int i = 0; i < n * n; i += (n + 1))
                    newTemp = newTemp && field[i].Tac;
                if (newTemp)
                    return true;
                newTemp = true;
                for (int i = 0; i < (n * n) - (n - 1); i += (n - 1))
                    newTemp = newTemp && field[i].Tac;
                if (newTemp)
                    return true;
                return false;
            }
        }

        bool Draw()
        {
            if (freeFieldCount == 0)
                return true;
            else
                return false;
        }

        public string CheckCondition(bool ticPlayer)
        {
            if (WinCondition(ticPlayer, gameField))
                return "Player won!";
            if (Draw())
                return "No-one won";
            return "Still got some move.";
        }

        public void Refresh()
        {
            Console.Clear();
            for (int i = 0; i < n * n; i+=n)
            {
                for (int j = 0; j < n; j++)
                {
                    if (gameField[i + j].Isfree)
                        Console.Write(" ");
                    else if (gameField[i + j].Tac)
                        Console.Write("x");
                    else
                        Console.Write("o");
                }
                Console.WriteLine();
            }
        }

    }
}
