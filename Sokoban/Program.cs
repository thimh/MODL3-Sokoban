using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sokoban
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game1 = new Game();
            
            Console.ReadLine();
            //AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
        }

        //private static void OnProcessExit(object sender, EventArgs e)
        //{
        //    System.IO.File.Delete(@"..\..\..\doolhof" + /*Hier moet de LevelChoice komen +*/ ".save.txt");
        //}
    }
}
