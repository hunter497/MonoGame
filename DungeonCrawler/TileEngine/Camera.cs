using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace TileEngine
{
    public class Camera
    {
        float speed = 10;


        public Vector2 Position = Vector2.Zero;


        public float Speed
        {
            get { return speed; }
            set
            {
                speed = (float)Math.Max(value, 1f);
            }
        }

        public void Update()
        {
            KeyboardState keyboardState = Keyboard.GetState();
            Vector2 motion = Vector2.Zero;

            //GamePadState gamePadState = GamePad.GetState(PlayerIndex.One);
            //motion = new Vector2(gamePadState.ThumbSticks.Left.X, -gamePadState.ThumbSticks.Left.Y);

            if (keyboardState.IsKeyDown(Keys.Up))
                motion.Y--;
            if (keyboardState.IsKeyDown(Keys.Down))
                motion.Y++;
            if (keyboardState.IsKeyDown(Keys.Left))
                motion.X--;
            if (keyboardState.IsKeyDown(Keys.Right))
                motion.X++;

            //Normalize the motion vector to make sure that the speed isn't greater than one for a diagonal direction.
            if (motion != Vector2.Zero)
                motion.Normalize();

            Position += motion * Speed;
        }
    }
}
