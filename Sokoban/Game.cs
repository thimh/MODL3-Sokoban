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
            LoadLevel2(LevelChoice);
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



            if (LevelChoice != 1 && LevelChoice != 2 && LevelChoice != 3 && LevelChoice != 4)
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

        public Level LoadLevel2(int levelNumber)
        {
            //supposed to be the real deal
            string text = System.IO.File.ReadAllText(@"..\..\..\doolhof" + levelNumber + ".txt");
            string[] lines = System.IO.File.ReadAllLines(@"..\..\..\doolhof" + levelNumber + ".txt");

            //this will only work with square levels! find another way.
            _currentLevel = new Level(100, 100);
            int lineCount = 0;
            foreach (string line in lines)
            {
                String screenString = null;
                for (int i = 0; i < line.Length; i++)
                {
                    //check each char in the line to see if it's something valid
                    //then create a tile on that spot with the corresponding icon
                    var lineDivided = line.ToCharArray();
                    
                    switch (lineDivided[i])
                    {
                        case 'O':
                            {
                                Tile newTile = new Tile(Tile.TileType.Box);
                                screenString = screenString + newTile.TileIcon;
                                _currentLevel.AddTile(i, lineCount, newTile);
                                break;
                            }
                        case '0':
                            {
                                Tile newTile = new Tile(Tile.TileType.BoxOnPoint);
                                screenString = screenString + newTile.TileIcon;
                                _currentLevel.AddTile(i, lineCount, newTile);
                                break;
                            }

                        case 'x':
                            {
                                Tile newTile = new Tile(Tile.TileType.Destination);
                                screenString = screenString + newTile.TileIcon;
                                _currentLevel.AddTile(i, lineCount, newTile);
                                break;
                            }

                        case '.':
                            {
                                Tile newTile = new Tile(Tile.TileType.Floor);
                                screenString = screenString + newTile.TileIcon;
                                _currentLevel.AddTile(i, lineCount, newTile);
                                break;
                            }

                        case ' ':
                            {
                                Tile newTile = new Tile(Tile.TileType.Outerspace);
                                screenString = screenString + newTile.TileIcon;
                                _currentLevel.AddTile(i, lineCount, newTile);
                                break;
                            }

                        case '#':
                            {
                                Tile newTile = new Tile(Tile.TileType.Wall);
                                screenString = screenString + newTile.TileIcon;
                                _currentLevel.AddTile(i, lineCount, newTile);
                                break;
                            }
                        default:
                            {
                                Tile newTile = new Tile(Tile.TileType.Outerspace);
                                screenString = screenString + newTile.TileIcon;
                                _currentLevel.AddTile(i, lineCount, newTile);
                                break;
                            }

                    }
                }
                lineCount++;
                //prints a 'screen string'. should print the level.
                //Console.WriteLine(screenString);
                _currentLevel.PrintLevel();
            }
            return _currentLevel;
        }

        public void PlayGame()
        {
            while (!HasWon)
            {
                
            }
        }
    }
}
