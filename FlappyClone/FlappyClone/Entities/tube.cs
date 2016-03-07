using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyClone.Entities
{
    public class Tube
    {
        public Texture2D texture;
        public Vector2 position;

        public Tube()
        {
            texture = Statics.CONTENT.Load<Texture2D>("Textures/tuyaux");
            position = new Vector2(250, 0);
        }

        public void Update()
        {

        }

        public void Draw()
        {
            Statics.SPRITEBATCH.Draw(texture, position, Color.White);
        }
    }
}
