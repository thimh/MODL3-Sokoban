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
            currentPos = currentLevel.currentPos.Value;

            switch (direction)
            {
                case "Left":
                {
                    currentPos.hasPlayer = false;
                    newPos = currentLevel.currentPos.Previous.Value;
                    currentPos = newPos;

                    currentPos.hasPlayer = true;
                    currentPos.TileIcon = Tile.TileType.Player.ToString();
                    
                        break;
                    }

                case "Right":
                    {
                        newPos = currentLevel.currentPos.Next.Value;

                        break;
                    }

                case "Up":
                    {
                        newPos = currentLevel.currentPos.Value;//How to make the tile know his northern neighbour???

                        break;
                    }

                case "Down":
                    {
                        newPos = currentLevel.currentPos.Value;//How to make the tile know his southern neighbour???

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
