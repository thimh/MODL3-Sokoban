﻿using System;
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

        public void Move(String direction)
        {
            currentPos = currentLevel.TileArray[currentX, currentY];

            switch (direction)
            {
                case "Left":
                    {
                        if (!HasCollision(direction))
                        {
                            currentPos.hasPlayer = false;
                            newPos = currentLevel.TileArray[currentX - 1, currentY];
                            currentPos = newPos;

                            currentPos.hasPlayer = true;
                            currentPos.TileIcon = Tile.TileType.Player.ToString();
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
                            currentPos.TileIcon = Tile.TileType.Player.ToString();
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
                            currentPos.TileIcon = Tile.TileType.Player.ToString();
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
                            currentPos.TileIcon = Tile.TileType.Player.ToString();
                        }

                        break;
                    }

                default:
                    {
                        break;
                    }
            }
            //TODO redraw the level
        }

        public bool HasCollision(String direction)
        {
            switch (direction)
            {
                case "Left":
                    {
                        if (currentLevel.TileArray[currentX - 1, currentY].TileIcon == Tile.TileType.Wall.ToString())
                        {
                            return true;
                        }
                        return false;
                    }

                case "Right":
                    {
                        if (currentLevel.TileArray[currentX + 1, currentY].TileIcon == Tile.TileType.Wall.ToString())
                        {
                            return true;
                        }
                        return false;
                    }

                case "Up":
                    {
                        if (currentLevel.TileArray[currentX, currentY - 1].TileIcon == Tile.TileType.Wall.ToString())
                        {
                            return true;
                        }
                        return false;
                    }

                case "Down":
                    {
                        if (currentLevel.TileArray[currentX, currentY + 1].TileIcon == Tile.TileType.Wall.ToString())
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
