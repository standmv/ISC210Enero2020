using System;
using System.Collections.Generic;
using UnityEngine;

namespace AssemblyCSharp.Assets.Scripts.Exploration.Entities
{
    public class Map
    {
        public int Width;
        public int Height;
        public int TileWidth;
        public int TileHeight;
        public List<Tile> Tiles;

        public Map(int width, int height, int tileWidth, int tileHeight)
        {
            Width = width;
            Height = height;
            TileWidth = tileWidth;
            TileHeight = tileHeight;
            Tiles = new List<Tile>();
        }


    }
}
