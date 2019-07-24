using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Conway_s_Game_Of_Life
{
    class LoadField
    {
        public string FilePath { get; set; }

        public LoadField(string filePath)
        {
            if (File.Exists(filePath))
                FilePath = filePath;
        }

        public bool[,] LoadFile()
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    string[] temp = File.ReadAllLines(FilePath);
                    bool[,] returnArray = new bool[temp.Length, temp[0].Length];
                    for (int i = 0; i < temp.Length; i++)
                        for (int j = 0; j < temp[i].Length; j++)
                            if (temp[i][j].ToString().ToLower() == "x")
                                returnArray[i, j] = true;
                            else
                                returnArray[i, j] = false;
                    return returnArray;
                }
                else
                {
                    return new bool[,] { { false }, { false } };
                }
            }
            catch
            {
                return new bool[,] { { false }, { false } };
            }
        }
    }
}
