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

        public TileType TypeOfTile;

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
                        TypeOfTile = TileType.Player;
                        break;
                    }

                case TileType.Box:
                    {
                        TileIcon = "o";
                        TypeOfTile = TileType.Box;
                        break;
                    }
                case TileType.BoxOnPoint:
                    {
                        TileIcon = "0";
                        TypeOfTile = TileType.BoxOnPoint;
                        break;
                    }

                case TileType.Destination:
                    {
                        TileIcon = "x";
                        TypeOfTile = TileType.Destination;
                        break;
                    }

                case TileType.Floor:
                    {
                        TileIcon = ".";
                        TypeOfTile = TileType.Floor;
                        break;
                    }

                case TileType.Outerspace:
                    {
                        TileIcon = " ";
                        TypeOfTile = TileType.Outerspace;
                        break;
                    }

                case TileType.Wall:
                    {
                        TileIcon = "█";
                        TypeOfTile = TileType.Wall;
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
