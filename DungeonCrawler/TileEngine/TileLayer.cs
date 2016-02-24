using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TileEngine
{
    public class TileLayer
    {
        static int tileWidth = 64;
        static int tileHeight = 64;

        public int TileWidth
        {
            get { return tileWidth; }
            set
            {
                tileWidth = (int)MathHelper.Clamp(value, 20f, 100f);
            }
        }
        public int TileHeight
        {
            get { return tileHeight; }
            set
            {
                tileHeight = (int)MathHelper.Clamp(value, 20f, 100f);
            }
        }


        List<Texture2D> tileTextures = new List<Texture2D>();
        int[,] map;
        float alpha = 1f;

        public float Alpha
        {
            get { return alpha; }
            set
            {
                alpha = MathHelper.Clamp(value, 0f, 1f);
            }
        }

        public int WidthInPixels
        {
            get
            {
                return map.GetLength(1) * tileWidth;
            }
        }

        public int HeightInPixels
        {
            get
            {
                return map.GetLength(0) * tileHeight;
            }
        }


        public TileLayer(int width, int height)
        {
            map = new int[height, width];
        }

        public TileLayer(int[,] existingMap)
        {
            // int[,] is a reference type, so this makes sure we have a separate copy of the map
            map = (int[,])existingMap.Clone();
        }

        public static TileLayer FromFile(ContentManager content, string filename)
        {
            TileLayer tileLayer;
            bool readingTextures = false;
            bool readingLayout = false;
            List<string> textureNames = new List<string>();
            List<List<int>> tempLayout = new List<List<int>>();

            using (StreamReader reader = new StreamReader(filename))
            {
                while(!reader.EndOfStream)
                {
                    string line = reader.ReadLine().Trim();

                    if (string.IsNullOrEmpty(line))
                        continue;

                    if (line.Contains("[Textures]"))
                    {
                        readingTextures = true;
                        readingLayout = false;
                    }
                    else if(line.Contains("[Layout]"))
                    {
                        readingTextures = false;
                        readingLayout = true;
                    }
                    else if(readingTextures)
                    {
                        textureNames.Add(line);
                    }
                    else if(readingLayout)
                    {
                        List<int> row = new List<int>();
                        string[] cells = line.Split(' ');

                        foreach (string cell in cells)
                        {
                            if (!string.IsNullOrEmpty(cell))
                                row.Add(int.Parse(cell));
                        }
                        tempLayout.Add(row);
                    }
                }
            }

            int width = tempLayout[0].Count;
            int height = tempLayout.Count;

            tileLayer = new TileLayer(width, height);

            for(int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                    tileLayer.SetCellIndex(x, y, tempLayout[y][x]);

            tileLayer.LoadTileTextures(content, textureNames.ToArray());

            return tileLayer;
        }

        public void LoadTileTextures(ContentManager content, params string[] textureNames)
        {
            Texture2D texture;
            
            foreach (string textureName in textureNames)
            {
                texture = content.Load<Texture2D>(textureName);
                tileTextures.Add(texture);
            }
            
        }


        // Dynamically remove tiles from the tile layers during the load or game running
        public void SetCellIndex(int x, int y, int cellIndex)
        {
            map[y, x] = cellIndex;
        }

        public void Draw(SpriteBatch batch, Camera camera)
        {
            // Make sure each layer has its own batch script
            batch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

            int tileMapWidth = map.GetLength(1);
            int tileMapHeight = map.GetLength(0);

            for (int x = 0; x < tileMapWidth; x++)
            {
                for (int y = 0; y < tileMapHeight; y++)
                {
                    int textureIndex = map[y, x];

                    if (textureIndex == -1)
                        continue;

                    Texture2D texture = tileTextures[textureIndex];
                    batch.Draw(
                        texture,
                        destinationRectangle: new Rectangle(
                            x * tileWidth - (int)camera.Position.X,
                            y * tileHeight - (int)camera.Position.Y,
                            tileWidth,
                            tileHeight),
                        color:new Color(new Vector4(1f, 1f, 1f, Alpha))
                        );
                }
            }

            batch.End();
        }

    }
}
