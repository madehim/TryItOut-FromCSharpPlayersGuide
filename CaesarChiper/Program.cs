using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CaesarChiper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Caesar Cipher. Enter \"Shift\" for encryption or decryption. Exit for ending program");
            string cmd = "";
            string filePath = "";
            bool exit = false;
            while (true)
            {
                cmd = Console.ReadLine();
                switch (cmd)
                {
                    case "Shift":
                        Console.WriteLine("Wanna change file path? y/n");
                        ChangePath(ref filePath);
                        if (File.Exists(filePath))
                        {
                            int shift = 0;
                            GetKey(ref shift);
                            ShiftStuff(filePath, shift);
                        }
                        else
                            Console.WriteLine("File don't exist. Start again");
                        break;
                    case "Exit":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Unknown command");
                        break;
                }
                if (exit)
                    break;
            }
        }


        public static void ChangePath(ref string filePath)
        {
            bool leaveChangePath = false;
            while (true)
            {
                string answer = Console.ReadLine();
                switch (answer)
                {
                    case "y":
                        Console.WriteLine("Enter new path to file");
                        filePath = Console.ReadLine();
                        Console.WriteLine("Path changed");
                        leaveChangePath = true;
                        break;
                    case "n":
                        leaveChangePath = true;
                        break;
                    default:
                        Console.WriteLine("Enter y or n");
                        break;
                }
                if (leaveChangePath)
                    break;
            }
        }

        public static void GetKey(ref int shift)
        {
            bool leaveLoop = false;
            while (true)
            {
                Console.WriteLine("Enter key between 1 and 25");
                string key = Console.ReadLine();
                shift = 0;
                try
                {
                    shift = Convert.ToInt32(key);
                }
                finally
                {
                    if (shift == 0 || shift > 25)
                        Console.WriteLine("Wrong key. Enter key between 1 and 25");
                    else
                        leaveLoop = true;
                }
                if (leaveLoop)
                    break;
            }
        }

        public static void ShiftStuff(string filepath, int key)
        {
            char[] ABC = new char[26];
            int tmp = 0;
            for (char i = 'a'; i <= 'z'; i++)
            {
                ABC[tmp] = i;
                tmp++;
            }
            try
            {
                string fileContent = File.ReadAllText(filepath).ToLower();
                string newFileContent = "";
                for (int i = 0; i < fileContent.Length; i++)
                {
                    int j = Array.FindIndex(ABC, x => x.Equals(fileContent[i]));
                    if (j != -1)
                    {
                        int shift = (j + key >= 26 ? j + key - 26 : j + key);
                        newFileContent += ABC[shift];
                    }
                    else
                        newFileContent += fileContent[i];
                }
                File.WriteAllText(filepath + "_new.txt", newFileContent);
                Console.WriteLine("New file created " + filepath + "_new.txt");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
