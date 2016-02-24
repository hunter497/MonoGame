using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TileEngine
{
    public class TileMap
    {
        public List<TileLayer> Layers = new List<TileLayer>();

        public void Draw(SpriteBatch batch, Camera camera)
        {
            foreach (TileLayer layer in Layers)
            {
                layer.Draw(batch, camera);
            }
        }

    }
}
