using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyClone.Entities
{
    public class Bird
    {
        public Texture2D[] birdTextures;
        public float rotation;
        public float YSpeed; 

        public int texturePosition;
        public Vector2 position;

        public int jumpTimer = 500;
        public double jumpElapsed = 0;

        public int animTimer = 100;
        public double animElapsed = 0;
        public int textureAdd = 1;

        public bool canJump = true;

        public bool dead = false;

        public Bird()
        {
            birdTextures = new Texture2D[3];
            birdTextures[0] = Statics.CONTENT.Load<Texture2D>("Textures/bird1");
            birdTextures[1] = Statics.CONTENT.Load<Texture2D>("Textures/bird2");
            birdTextures[2] = Statics.CONTENT.Load<Texture2D>("Textures/bird3");
            YSpeed = 0;
            position = new Vector2(150, 300);
            texturePosition = 0;
        }

        public void Update()
        {
            YSpeed += 0.2f;

            jumpElapsed += Statics.GAMETIME.ElapsedGameTime.TotalMilliseconds;

            if(jumpElapsed > jumpTimer)
            {
                canJump = true;
                jumpElapsed = 0;
            }

            animElapsed += Statics.GAMETIME.ElapsedGameTime.TotalMilliseconds;

            if (animElapsed > animTimer)
            {
                texturePosition += textureAdd;
                if (texturePosition == 2 || texturePosition == 0)
                    textureAdd = textureAdd * -1;
                animElapsed = 0;
            }

            if (Statics.INPUT.isKeyPressed(Microsoft.Xna.Framework.Input.Keys.Space) && canJump)
            {
                YSpeed = -6;
            }

            rotation = (float)Math.Atan2(YSpeed, 6);

            
            position.Y += YSpeed;

            if(position.Y > 500)
            {
                dead = true;
            }

            
        }

        public Rectangle Bounds { get { return new Rectangle((int)position.X - 20, (int)position.Y - 20, 40, 40); } set { } }

        public void Draw()
        {
            Statics.SPRITEBATCH.Draw(birdTextures[texturePosition], position, null, Color.White, rotation, new Vector2(20, 20), 1f, SpriteEffects.None, 0f);

            if(Statics.DEBUG)
                Statics.SPRITEBATCH.Draw(Statics.PIXEL, Bounds, new Color(1f, 0f, 0f, 0.3f));
        }
    }
}
