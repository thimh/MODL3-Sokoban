using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    class Level
    {
        public int LevelLength;
        public int LevelWidth;
        //make tileArray size to fit perfectly to level.
        //no hardcoding
        public Player player;
        public Tile[,] TileArray;
        public String lineString;
        public String[] lineStrings;
        public int amountOfLines;

        public Level(int levelLength, int levelWidth)
        {
            player = new Player(this);
            LevelLength = levelLength;
            LevelWidth = levelWidth;
            TileArray = new Tile[LevelLength, LevelWidth];
        }

        public void AddTile(int x, int y, Tile tile)
        {
            TileArray[x, y] = tile;
        }

        public void PrintLevel(int levelNumber)
        {
            System.IO.File.Create(@"..\..\..\doolhof" + levelNumber + ".save.txt").Close();

            //supposed to be the real deal
            string text = System.IO.File.ReadAllText(@"..\..\..\doolhof" + levelNumber + ".txt");
            string[] lines = System.IO.File.ReadAllLines(@"..\..\..\doolhof" + levelNumber + ".txt");

            int lineCount = 0;
            foreach (string line in lines)
            {
                lineString = "";
                String screenString = null;
                for (int i = 0; i < line.Length; i++)
                {
                    //check each char in the line to see if it's something valid
                    //then create a tile on that spot with the corresponding icon
                    var lineDivided = line.ToCharArray();
                    
                    switch (lineDivided[i])
                    {
                        case '@':
                            {
                                //there should be a floor tile with a player object on top of it
                                //player enum should be removed
                                Tile newTile = new Tile(Tile.TileType.Player);

                                screenString += newTile.TileIcon;
                                AddTile(i, lineCount, newTile);
                                player.currentX = i;
                                player.currentY = lineCount;
                                break;
                            }

                        case 'o':
                            {
                                Tile newTile = new Tile(Tile.TileType.Box);
                                screenString += newTile.TileIcon;
                                AddTile(i, lineCount, newTile);
                                break;
                            }
                        case '0':
                            {
                                Tile newTile = new Tile(Tile.TileType.BoxOnPoint);
                                screenString += newTile.TileIcon;
                                AddTile(i, lineCount, newTile);
                                break;
                            }

                        case 'x':
                            {
                                Tile newTile = new Tile(Tile.TileType.Destination);
                                screenString += newTile.TileIcon;
                                AddTile(i, lineCount, newTile);
                                break;
                            }

                        case '.':
                            {
                                Tile newTile = new Tile(Tile.TileType.Floor);
                                screenString += newTile.TileIcon;
                                AddTile(i, lineCount, newTile);
                                break;
                            }

                        case ' ':
                            {
                                Tile newTile = new Tile(Tile.TileType.Outerspace);
                                screenString += newTile.TileIcon;
                                AddTile(i, lineCount, newTile);
                                break;
                            }

                        case '#':
                            {
                                Tile newTile = new Tile(Tile.TileType.Wall);
                                screenString += newTile.TileIcon;
                                AddTile(i, lineCount, newTile);
                                break;
                            }

                        //case '█':
                        //    {
                        //        Tile newTile = new Tile(Tile.TileType.Wall);
                        //        screenString += newTile.TileIcon;
                        //        AddTile(i, lineCount, newTile);
                        //        break;
                        //    }
                        default:
                            {
                                Tile newTile = new Tile(Tile.TileType.Outerspace);
                                screenString += newTile.TileIcon;
                                AddTile(i, lineCount, newTile);
                                break;
                            }

                    }
                    lineString = lineString + TileArray[i, lineCount].TileIcon;
                }
                Console.WriteLine(lineString);
                if (lineCount == 0)
                {
                    lineStrings = new string[lines.Length];
                }
                lineStrings[lineCount] = lineString;
                lineCount++;
            }
            amountOfLines = lineCount;
            System.IO.File.AppendAllLines(@"..\..\..\doolhof" + levelNumber + ".save.txt", lineStrings);
        }

        public void UpdateLevel(int levelNumber)
        {
            string[] lines = System.IO.File.ReadAllLines(@"..\..\..\doolhof" + levelNumber + ".save.txt");
            for (int i = 0; i < amountOfLines; i++)
            {
                Console.WriteLine(lines[i]);
            }
            System.IO.File.WriteAllLines(@"..\..\..\doolhof" + levelNumber + ".save.txt", lines);
        }

    }
}
