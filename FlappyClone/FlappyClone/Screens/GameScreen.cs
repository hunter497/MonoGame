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
        public Entities.Bird player;
        public Entities.Scroll scroll;
        public List<Entities.Tube> tubes;

        public GameScreen()
        {

        }

        public override void LoadContent()
        {
            background = Statics.CONTENT.Load<Texture2D>("Textures/background");

            player = new Entities.Bird();
            scroll = new Entities.Scroll();
            tubes = new List<Entities.Tube>();
            tubes.Add(new Entities.Tube());

            base.LoadContent();
        }

        public override void Update()
        {
            player.Update();
            scroll.Update();
            foreach(var tube in tubes)
            {
                tube.Update();
            }

            base.Update();
        }

        public override void Draw()
        {
            Statics.SPRITEBATCH.Begin(sortMode:SpriteSortMode.Deferred, blendState:BlendState.AlphaBlend, samplerState: SamplerState.LinearWrap);

            Statics.SPRITEBATCH.Draw(background, Vector2.Zero, Color.White);
            player.Draw();
            scroll.Draw();

            foreach (var tube in tubes)
            {
                tube.Draw();
            }

            Statics.SPRITEBATCH.End();
            base.Draw();
        }
    }
}
