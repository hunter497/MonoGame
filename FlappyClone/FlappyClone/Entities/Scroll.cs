using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyClone.Entities
{
    public class Scroll
    {
        public Vector2 position;
        public Texture2D texture;

        public int animTimer = 10;
        public double animElapsed = 0;
        public int decalX = 0;

        public Scroll()
        {
            position = new Vector2(0, 529);
            texture = Statics.CONTENT.Load<Texture2D>("Textures/scroll");
        }

        public void Update()
        {
            animElapsed += Statics.GAMETIME.ElapsedGameTime.TotalMilliseconds;
            if(animElapsed > animTimer)
            {
                decalX += 2;
                if (decalX > 12)
                    decalX = 0;
                animElapsed = 0;
            }
        }

        public void Draw()
        {
            Statics.SPRITEBATCH.Draw(texture, position, new Rectangle(decalX, 0, Statics.GAME_WIDTH, 12), Color.White);
        }
    }
}
