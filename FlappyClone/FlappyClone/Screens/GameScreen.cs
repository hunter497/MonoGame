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
        public Texture2D gameOver;
        public Entities.Bird player;
        public Entities.Scroll scroll;
        public SpriteFont font;
        public int score = 0;

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
            font = Statics.CONTENT.Load<SpriteFont>("Fonts/font");
            gameOver = Statics.CONTENT.Load<Texture2D>("Textures/gameover");

            Reset();
            base.LoadContent();
        }

        public void Reset()
        {
            player = new Entities.Bird();
            scroll = new Entities.Scroll();

            tubes = new List<Entities.Tube>();
            tubes.Add(new Entities.Tube());
            score = 0;
            tubeElapsed = 0;
        }

        public override void Update()
        {
            TubeCreator();
            if(!player.dead)
            {
                for (int i = tubes.Count - 1; i > -1; i--)
                {
                    if (tubes[i].position.X < -50)
                        tubes.RemoveAt(i);
                    else
                    {
                        tubes[i].Update();
                        if (!tubes[i].scored && player.position.X > tubes[i].position.X + 50)
                        {
                            tubes[i].scored = true;
                            score++;
                        }

                        if (player.Bounds.Intersects(tubes[i].BottomBound) || player.Bounds.Intersects(tubes[i].TopBound))
                        {
                            player.dead = true;
                        }
                    }
                }
                player.Update();
                scroll.Update();
            }
            
            if(player.dead && Statics.INPUT.isKeyPressed(Microsoft.Xna.Framework.Input.Keys.Enter))
            {
                Reset();
            }
            

            base.Update();
        }

        public void TubeCreator()
        {
            tubeElapsed += Statics.GAMETIME.ElapsedGameTime.TotalMilliseconds;

            if (tubeElapsed > tubeTimer)
            {
                tubes.Add(new Entities.Tube());
                tubeElapsed = 0;
            }
        }

        public void Score()
        {

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

            Statics.SPRITEBATCH.DrawString(font, "Score: " + score.ToString(), new Vector2(10, 10), Color.Red);

            if(player.dead)
            {
                Statics.SPRITEBATCH.Draw(Statics.PIXEL, new Rectangle(0, 0, Statics.GAME_WIDTH, Statics.GAME_HEIGHT), new Color(1f, 0f, 0f, 0.3f));
                Statics.SPRITEBATCH.Draw(gameOver, new Vector2(0, 80), Color.White);
            }

            Statics.SPRITEBATCH.End();
            base.Draw();
        }
    }
}
