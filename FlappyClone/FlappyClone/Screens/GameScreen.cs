using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyClone.Screens
{
    public class GameScreen : Screen
    {
        public Texture2D background;

        public GameScreen()
        {

        }

        public override void LoadContent()
        {
            background = Statics.CONTENT.Load<Texture2D>("Textures/background");

            base.LoadContent();
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Draw()
        {
            Statics.SPRITEBATCH.Begin();

            Statics.SPRITEBATCH.Draw(background, Vector2.Zero, Color.White);

            Statics.SPRITEBATCH.End();
            base.Draw();
        }
    }
}
