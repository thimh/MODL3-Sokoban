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

        public void move(String direction)
        {
            currentPos = currentLevel.TileArray[currentX, currentY];

            switch (direction)
            {
                case "Left":
                {
                    currentPos.hasPlayer = false;
                    newPos = currentLevel.TileArray[currentX - 1, currentY];
                    currentPos = newPos;

                    currentPos.hasPlayer = true;
                    currentPos.TileIcon = Tile.TileType.Player.ToString();
                    
                        break;
                    }

                case "Right":
                    {
                        newPos = currentLevel.TileArray[currentX + 1, currentY];

                        break;
                    }

                case "Up":
                    {
                        newPos = currentLevel.TileArray[currentX, currentY - 1];

                        break;
                    }

                case "Down":
                    {
                        newPos = currentLevel.TileArray[currentX, currentY + 1];

                        break;
                    }

                default:
                    {
                        break;
                    }
            }
            //redraw the level
        }
    }
}
