using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFour
{

    class Program
    {


        static void Main(string[] args)
        {
            Graphics graphics = new Graphics();
            GameField gf = new GameField();
            graphics.RefreshConsole(gf.fieldEnums);
            gf.Turn(graphics.GetTurn(1, false));
            Console.ReadKey();
        }
    }
}
