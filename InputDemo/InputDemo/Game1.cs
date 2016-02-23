using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Text;

namespace InputDemo
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D playerTexture;
        Vector2 playerPosition;
        Vector2 playerOrigin;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // Setting the default values of the square graphics
            playerPosition = new Vector2(0, 0);
            playerTexture = new Texture2D(this.GraphicsDevice, 100, 100);
            Color[] colorData = new Color[100 * 100];
            for (int i = 0; i < 10000; i++)
                colorData[i] = Color.Red;
            playerTexture.SetData<Color>(colorData);
            playerOrigin = new Vector2(50, 50);

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

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            playerTexture.Dispose();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape) || Mouse.GetState().RightButton == ButtonState.Pressed)
                Exit();


            //**    Mouse State Tutorial!!!  **//     
            MouseState state = Mouse.GetState();
            playerPosition.X = state.X;
            playerPosition.Y = state.Y;



            //**    Keyboard State Tutorial!!!  **//         
            //KeyboardState state = Keyboard.GetState();

            //StringBuilder sb = new StringBuilder();
            //foreach(var key in state.GetPressedKeys())
            //{
            //    sb.Append("Keys: ").Append(key).Append(" pressed ");
            //}

            //if (sb.Length > 0)
            //    System.Diagnostics.Debug.WriteLine(sb.ToString());

            //if (state.IsKeyDown(Keys.Right))
            //    playerPosition.X += 10;
            //if (state.IsKeyDown(Keys.Left))
            //    playerPosition.X -= 10;
            //if (state.IsKeyDown(Keys.Up))
            //    playerPosition.Y -= 10;
            //if (state.IsKeyDown(Keys.Down))
            //    playerPosition.Y += 10;

            // Have to fix this, but working on the sprite wrapping
            //if (playerPosition.X > this.GraphicsDevice.Viewport.Width)
            //    playerPosition.X = 0 - playerTexture.Width;
            //if (playerPosition.X < 0)
            //    playerPosition.X = this.GraphicsDevice.Viewport.Width + playerTexture.Width;
            //if (playerPosition.Y > this.GraphicsDevice.Viewport.Height)
            //    playerPosition.Y = 0 - playerTexture.Height;
            //if (playerPosition.Y > this.GraphicsDevice.Viewport.Height)
            //    playerPosition.Y = this.GraphicsDevice.Viewport.Height + playerTexture.Height;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            spriteBatch.Draw(playerTexture, playerPosition);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
