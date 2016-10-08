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
        public String standardIcon = ".";
        public bool hasPlayer = false;

        public enum TileType
        {
            Outerspace, Wall, Floor, Box, BoxOnPoint, Destination, Player
        }
        public Tile(TileType type)
        {
            TileSwitch(type);
        }

        private void TileSwitch(TileType type)
        {
            switch (type)
            {
                case TileType.Player:
                    {
                        TileIcon = "@";
                        break;
                    }

                case TileType.Box:
                    {
                        TileIcon = "o";
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
