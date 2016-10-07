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
        public Tile[,] TileArray;

        public Level(int levelLength, int levelWidth)
        {
            LevelLength = levelLength;
            LevelWidth = levelWidth;
            TileArray = new Tile[LevelLength, LevelWidth];
        }

        public void AddTile(int x, int y, Tile tile)
        {
            TileArray[x, y] = tile;
        }

        public void PrintLevel()
        {
            int rowLength = TileArray.GetLength(0);
            int colLength = TileArray.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(TileArray[i,j].TileIcon);
                }   
                Console.Write(Environment.NewLine + Environment.NewLine);
            }
        }

    }
}
