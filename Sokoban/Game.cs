using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Char;

namespace Sokoban
{
    class Game
    {
        public int LevelChoice;
        private String _input;
        private int _value;
        private Level _currentLevel;
        public Boolean HasWon = false;

        public Game()
        {
            ChooseLevel();
            //LoadLevel(1);

            int levelHeight = System.IO.File.ReadLines(@"..\..\..\doolhof" + LevelChoice + ".txt").Count();
            int levelWidth = System.IO.File.ReadAllLines(@"..\..\..\doolhof" + LevelChoice + ".txt")[0].Count();

            int maxLevelWidth = ma

            //Console.WriteLine(System.IO.File.ReadAllLines(@"..\..\..\doolhof" + LevelChoice + ".txt")[0].Count());
            _currentLevel = new Level(levelWidth, levelHeight);
            //this will only work with square levels! find another way.

            _currentLevel.PrintLevel(LevelChoice);
            _currentLevel.lineStrings = new string[_currentLevel.amountOfLines];
            PlayGame();
            Console.ReadLine();
        }

        public void ChooseLevel()
        {
            Console.WriteLine("Selecteer een level (1-4)!");

            _input = Console.ReadLine();

            if (int.TryParse(_input, out _value))
            {
                LevelChoice = int.Parse(_input);
            }
            else
            {
                while (int.TryParse(_input, out _value) == false)
                {
                    Console.WriteLine("Ongeldige input, letters zijn niet toegestaan. Probeer opnieuw.");
                    _input = Console.ReadLine();
                    LevelChoice = int.Parse(_input);
                }
            }



            if (LevelChoice<1 || LevelChoice >4)
            {
                while (LevelChoice != 1 && LevelChoice != 2 && LevelChoice != 3 && LevelChoice != 4)
                {
                    Console.Write("Ongeldige input, alleen 1-2-3-4 zijn beschikbaar. Probeer opnieuw.");
                    LevelChoice = int.Parse(Console.ReadLine());
                }
            }
            Console.WriteLine("Level " + LevelChoice + " wordt gestart!");
        }

        public void LoadLevel(int level)
        {
            //primitive for demo purposes
            string text = System.IO.File.ReadAllText(@"C:\Users\Victor\Desktop\Huiswerk\Blok 5\MODL3\Sokoban\Sokoban\doolhof" + level + ".txt");
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Victor\Desktop\Huiswerk\Blok 5\MODL3\Sokoban\Sokoban\doolhof" + level + ".txt");
           
            foreach (string line in lines)
            {
                Console.WriteLine("" + line);
            }
        }

        public void PlayGame()
        {
            while (!HasWon)
            {
                KeyHandler();
            }
        }

        private void KeyHandler()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            switch (keyInfo.Key)
            {
                case ConsoleKey.LeftArrow:
                    {
                        Console.Clear();
                        _currentLevel.player.Move("Left", LevelChoice);
                        _currentLevel.UpdateLevel(LevelChoice);
                        break;
                    }

                case ConsoleKey.RightArrow:
                    {
                        Console.Clear();
                        _currentLevel.player.Move("Right", LevelChoice);
                        _currentLevel.UpdateLevel(LevelChoice);
                        break;
                    }

                case ConsoleKey.UpArrow:
                    {
                        Console.Clear();
                        _currentLevel.player.Move("Up", LevelChoice);
                        _currentLevel.UpdateLevel(LevelChoice);
                        break;
                    }

                case ConsoleKey.DownArrow:
                    {
                        Console.Clear();
                        _currentLevel.player.Move("Down", LevelChoice);
                        _currentLevel.UpdateLevel(LevelChoice);
                        break;
                    }

                default:
                    {
                        break;
                    }
            }
        }
    }
}
