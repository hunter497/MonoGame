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
        public Texture2D sand;
        public Entities.Bird player;
        public Entities.Scroll scroll;
        public List<Entities.Tube> tubes;
        public int tubeTimer = 2000;
        public double tubeElapsed = 0;

        public GameScreen()
        {

        }

        public override void LoadContent()
        {
            background = Statics.CONTENT.Load<Texture2D>("Textures/background");
            sand = Statics.CONTENT.Load<Texture2D>("Textures/sand");

            player = new Entities.Bird();
            scroll = new Entities.Scroll();
            tubes = new List<Entities.Tube>();
            tubes.Add(new Entities.Tube());

            base.LoadContent();
        }

        public override void Update()
        {
            tubeCreator();
            for(int i=tubes.Count-1; i > -1; i--)
            {
                if (tubes[i].position.X < -50)
                    tubes.RemoveAt(i);
                else
                    tubes[i].Update();
            }
            player.Update();
            scroll.Update();

            base.Update();
        }

        public void tubeCreator()
        {
            tubeElapsed += Statics.GAMETIME.ElapsedGameTime.TotalMilliseconds;

            if (tubeElapsed > tubeTimer)
            {
                tubes.Add(new Entities.Tube());
                tubeElapsed = 0;
            }
        }

        public override void Draw()
        {
            Statics.SPRITEBATCH.Begin(sortMode:SpriteSortMode.Deferred, blendState:BlendState.AlphaBlend, samplerState: SamplerState.LinearWrap);

            Statics.SPRITEBATCH.Draw(background, Vector2.Zero, Color.White);


            foreach (var tube in tubes)
            {
                tube.Draw();
            }

            Statics.SPRITEBATCH.Draw(sand, new Vector2(0, 529), Color.White);

            scroll.Draw();

            player.Draw();
            

            Statics.SPRITEBATCH.End();
            base.Draw();
        }
    }
}
