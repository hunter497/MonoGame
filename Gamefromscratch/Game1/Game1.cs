using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D logoTexture;
        Vector2 logoPosition;
        
        //// Square texture
        //Texture2D squareTexture;
        //Vector2 squarePosition;
        
        //// Movement speed of the square, public for easy access to change
        //float movementSpeed = 5f;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // Updating at a fixed rate of around 30 FPS
            //this.IsFixedTimeStep = true;
            //this.TargetElapsedTime = new System.TimeSpan(0, 0, 0, 0, 33);
        }

        protected override void OnActivated(object sender, EventArgs args)
        {
            Window.Title = "Active Application";
            base.OnActivated(sender, args);
        }

        protected override void OnDeactivated(object sender, EventArgs args)
        {
            Window.Title = "Unactive Application";
            base.OnDeactivated(sender, args);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            //// Setting the default values of the square graphics
            //squarePosition = new Vector2(0, 0);
            //squareTexture = new Texture2D(this.GraphicsDevice, 100, 100);
            //Color[] colorData = new Color[100 * 100];
            //for (int i = 0; i < 10000; i++)
            //    colorData[i] = Color.Red;
            //squareTexture.SetData<Color>(colorData);

            logoPosition = new Vector2(0, 0);

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            logoTexture = this.Content.Load<Texture2D>("logo");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            //squareTexture.Dispose();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (IsActive)
            {
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                    Exit();


                //// Normalizing the positional movement between framerates
                //squarePosition.X += 60f * movementSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

                //// Loop the square if it hits the edge of the screen
                //if (squarePosition.X > this.GraphicsDevice.Viewport.Width)
                //    squarePosition.X = 0 - squareTexture.Width;

                base.Update(gameTime);
            }
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            var fps = 1 / gameTime.ElapsedGameTime.TotalSeconds;
            Window.Title = fps.ToString();

            // All Texture calls go within the sprite batch
            spriteBatch.Begin();

            //spriteBatch.Draw(squareTexture, squarePosition);

            // Can translate and scale the texture using a destination rectangle
            // Rotates via the rotation property, but that rotates about the origin
            spriteBatch.Draw(logoTexture, 
                destinationRectangle:
                new Rectangle(150, 150, 200, 200),
                rotation:-45f,
                origin:new Vector2(logoTexture.Width/2, logoTexture.Height/2),
                color:Color.Red,
                effects:SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
