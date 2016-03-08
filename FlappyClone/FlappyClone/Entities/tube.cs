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

        public bool scored = false;

        public Tube()
        {
            texture = Statics.CONTENT.Load<Texture2D>("Textures/tuyaux");
            position = new Vector2(420, Statics.RANDOM.Next(-200, 5));
        }

        public void Update()
        {
            position.X -= 2f;
        }

        public Rectangle TopBound { get { return new Rectangle((int)position.X, (int)position.Y, 55, 308); } }
        public Rectangle BottomBound { get { return new Rectangle((int)position.X, (int)position.Y + 460, 55, 340); } }

        public void Draw()
        {
            Statics.SPRITEBATCH.Draw(texture, position, Color.White);

            if(Statics.DEBUG)
            {
                Statics.SPRITEBATCH.Draw(Statics.PIXEL, TopBound, new Color(1f, 0f, 0f, 0.3f));
                Statics.SPRITEBATCH.Draw(Statics.PIXEL, BottomBound, new Color(1f, 0f, 0f, 0.3f));
            }
            
        }
    }
}
