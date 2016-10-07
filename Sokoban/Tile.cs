using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    class Tile
    {
        public String TileIcon;

        public enum TileType
        {
            Outerspace, Wall, Floor, Box, BoxOnPoint, Destination
        }
        public Tile(TileType type)
        {
            switch (type)
            {
                case TileType.Box:
                {
                    TileIcon = "O";
                    break;
                }
                case TileType.BoxOnPoint:
                {
                    TileIcon = "0";
                    break;
                }

                case TileType.Destination:
                {
                    TileIcon = "x";
                    break;
                }

                case TileType.Floor:
                {
                    TileIcon = ".";
                    break;
                }

                case TileType.Outerspace:
                {
                    TileIcon = " ";
                    break;
                }

                case TileType.Wall:
                {
                    TileIcon = "█";
                    break;
                }
                default:
                {
                    TileIcon = "-";
                    break;
                }

            }


        }
    }
}
