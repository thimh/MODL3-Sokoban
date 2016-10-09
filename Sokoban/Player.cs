using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    class Player
    {
        public Level currentLevel;
        public int currentX;
        public int currentY;
        public char Icon = '@';
        public Tile currentPos;
        public Tile newPos;

        public Player(Level level)
        {
            currentLevel = level;
        }

        public void Move(String direction, int levelNumber)
        {
            currentPos = currentLevel.TileArray[currentX, currentY];

            switch (direction)
            {
                case "Left":
                    {
                        if (!HasCollision(direction))
                        {
                            currentPos.hasPlayer = false;
                            Tile oldPos = currentPos;
                            newPos = currentLevel.TileArray[currentX - 1, currentY];
                            currentPos = newPos;
                            
                            oldPos = new Tile(Tile.TileType.Floor);

                            currentPos.hasPlayer = true;
                            currentPos = new Tile(Tile.TileType.Player);

                            Console.WriteLine("You moved " + direction);

                            string[] lines = new string[currentLevel.LevelLength];

                            for (int j = 0; j < currentLevel.LevelWidth; j++)
                            {
                                string line = "";
                                for (int i = 0; i < currentLevel.LevelLength; i++)
                                {
                                    line += currentLevel.TileArray[i,j].TileIcon;
                                }
                                lines[j] = line;
                            }

                            System.IO.File.WriteAllLines(@"..\..\..\doolhof" + levelNumber + ".save.txt", lines);
                            //TODO fix het bewegen --> sla de nieuwe tiles op in .save
                        }
                        else
                        {
                            Console.WriteLine("You tried to move " + direction + " but you cannot walk through walls!");
                        }

                        break;
                    }

                case "Right":
                    {
                        if (!HasCollision(direction))
                        {
                            currentPos.hasPlayer = false;
                            newPos = currentLevel.TileArray[currentX + 1, currentY];
                            currentPos = newPos;

                            currentPos.hasPlayer = true;
                            currentPos = new Tile(Tile.TileType.Player);

                            Console.WriteLine("You moved " + direction);
                        }
                        else
                        {
                            Console.WriteLine("You tried to move " + direction + " but you cannot walk through walls!");
                        }

                        break;
                    }

                case "Up":
                    {
                        if (!HasCollision(direction))
                        {
                            currentPos.hasPlayer = false;
                            newPos = currentLevel.TileArray[currentX, currentY - 1];
                            currentPos = newPos;

                            currentPos.hasPlayer = true;
                            currentPos = new Tile(Tile.TileType.Player);

                            Console.WriteLine("You moved " + direction);
                        }
                        else
                        {
                            Console.WriteLine("You tried to move " + direction + " but you cannot walk through walls!");
                        }

                        break;
                    }

                case "Down":
                    {
                        if (!HasCollision(direction))
                        {
                            currentPos.hasPlayer = false;
                            newPos = currentLevel.TileArray[currentX, currentY + 1];
                            currentPos = newPos;

                            currentPos.hasPlayer = true;
                            currentPos = new Tile(Tile.TileType.Player);

                            Console.WriteLine("You moved " + direction);
                        }
                        else
                        {
                            Console.WriteLine("You tried to move " + direction + " but you cannot walk through walls!");
                        }

                        break;
                    }

                default:
                    {
                        break;
                    }
            }
        }

        public bool HasCollision(String direction)
        {
            switch (direction)
            {
                case "Left":
                    {
                        if (currentLevel.TileArray[currentX - 1, currentY].TypeOfTile == Tile.TileType.Wall)
                        {
                            return true;
                        }
                        return false;
                    }

                case "Right":
                    {
                        if (currentLevel.TileArray[currentX + 1, currentY].TypeOfTile == Tile.TileType.Wall)
                        {
                            return true;
                        }
                        return false;
                    }

                case "Up":
                    {
                        if (currentLevel.TileArray[currentX, currentY - 1].TypeOfTile == Tile.TileType.Wall)
                        {
                            return true;
                        }
                        return false;
                    }

                case "Down":
                    {
                        if (currentLevel.TileArray[currentX, currentY + 1].TypeOfTile == Tile.TileType.Wall)
                        {
                            return true;
                        }
                        return false;
                    }

                default:
                    {
                        return true;
                    }
            }
        }

        public bool HasBox(String direction)
        {
            switch (direction)
            {
                case "Left":
                    {
                        if (currentLevel.TileArray[currentX - 1, currentY].TypeOfTile == Tile.TileType.Box)
                        {
                            return true;
                        }
                        return false;
                    }

                case "Right":
                    {
                        if (currentLevel.TileArray[currentX + 1, currentY].TypeOfTile == Tile.TileType.Box)
                        {
                            return true;
                        }
                        return false;
                    }

                case "Up":
                    {
                        if (currentLevel.TileArray[currentX, currentY - 1].TypeOfTile == Tile.TileType.Box)
                        {
                            return true;
                        }
                        return false;
                    }

                case "Down":
                    {
                        if (currentLevel.TileArray[currentX, currentY + 1].TypeOfTile == Tile.TileType.Box)
                        {
                            return true;
                        }
                        return false;
                    }

                default:
                    {
                        return true;
                    }
            }
        }
    }
}
