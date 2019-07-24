using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{
    enum FieldStatus { free = 0, firstPlayer = 1, secondPlayer = 2 };

    class GameField
    {
        Graphics Graphics;
        bool[] fullRow = new bool[7];
        internal int[,] fieldEnums = new int[7, 7];
        int fullField = 7 * 7;
        int PlayerNum { get; set; }

        public GameField()
        {
            for (int i = 0; i < fieldEnums.GetLength(0); i++)
                for (int j = 0; j < fieldEnums.GetLength(1); j++)
                    fieldEnums[i, j] = (int)FieldStatus.free;
            PlayerNum = 1;
        }

        bool CheckWin(int i, int j)
        {
            bool win = true;
            if (i - 3 >= 0) //check up-down
            {
                for (int index = i; index > i - 4; index--)
                    if (fieldEnums[index, j] != PlayerNum)
                    {
                        win = false;
                        break;
                    }

                if (win)
                    return win;
            }
            for (int index = j - 3; index <= j; index++) //check left-right
            {
                if (index >= 0 && index + 3 < 7)
                {
                    win = true;
                    for (int newIndex = index; newIndex < index + 4; newIndex++)
                        if (fieldEnums[i, newIndex] != PlayerNum)
                        {
                            win = false;
                            break;
                        }
                    if (win)
                        return win;
                }
            }

            for (int indexi = i - 3; indexi <= i; indexi++) //check crossline 
                for (int indexj = j - 3; indexj <= j; indexj++)
                {
                    if ((indexi >= 0 && indexi + 3 < 7) && (indexj >= 0 && indexj + 3 < 7))
                    {
                        win = true;
                        for (int temp = 0; temp < 4; temp++)
                            if (fieldEnums[indexi + temp, indexj + temp] != PlayerNum)
                            {
                                win = false;
                                break;
                            }
                        if (win)
                            return win;
                    }
                }

            for (int indexi = i + 3; indexi >= i; indexi--) //check another crossline 
                for (int indexj = j - 3; indexj <= j; indexj++)
                {
                    if ((indexi >= 3 && indexi < 7) && (indexj >= 0 && indexj + 3 < 7))
                    {
                        win = true;
                        for (int temp = 0; temp < 4; temp++)
                            if (fieldEnums[indexi - temp, indexj + temp] != PlayerNum)
                            {
                                win = false;
                                break;
                            }
                        if (win)
                            return win;
                    }
                }
            return false;
        }

        public void Turn(int num)
        {
            bool won = false;
            if (!fullRow[num])
            {
                bool testForFull = true;
                for (int i = 0; i < fieldEnums.GetLength(0); i++)
                {
                    if (fieldEnums[i, num] == (int)FieldStatus.free)
                    {
                        fieldEnums[i, num] = PlayerNum;
                        if (CheckWin(i, num))
                        {
                            Graphics.RefreshConsole(fieldEnums);
                            Graphics.Win(PlayerNum);
                            won = true;
                            break;
                        }
                        else
                        {
                            PlayerNum = (PlayerNum == 1) ? ++PlayerNum : --PlayerNum;
                            testForFull = false;
                            fullField--;
                            break;
                        }
                    }
                }
                if (testForFull)
                    fullRow[num] = true;
            }
            if (!won)
            {
                if (fullField == 0)
                {
                    Graphics.RefreshConsole(fieldEnums);
                    Graphics.Even();
                }
                else
                {
                    Graphics.RefreshConsole(fieldEnums);
                    if (fullRow[num])
                        Turn(Graphics.GetTurn(PlayerNum, true));
                    else
                        Turn(Graphics.GetTurn(PlayerNum, false));
                }
            }
        }
    }
}
