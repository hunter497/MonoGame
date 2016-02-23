using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace TileEngine
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        List<Texture2D> tileTextures;

        int[,] tileMap;

        int tileWidth = 64;
        int tileHeight = 64;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            tileTextures = new List<Texture2D>();

            tileMap = new int[,] {
            { 1, 1, 2, 4, 2, 1, 1, 1},
            { 1, 0, 0, 4, 0, 0, 0, 1},
            { 1, 0, 0, 4, 4, 0, 0, 1},
            { 1, 0, 0, 0, 4, 0, 0, 1},
            { 1, 0, 0, 0, 4, 4, 0, 1},
            { 1, 0, 0, 0, 0, 4, 0, 1},
            { 1, 0, 0, 0, 0, 4, 0, 1},
            { 1, 1, 1, 1, 2, 4, 2, 1}
        };

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

            Texture2D texture;

            texture = Content.Load<Texture2D>("Tiles/wood");
            tileTextures.Add(texture);
            texture = Content.Load<Texture2D>("Tiles/wall");
            tileTextures.Add(texture);
            texture = Content.Load<Texture2D>("Tiles/wall_purple");
            tileTextures.Add(texture);
            texture = Content.Load<Texture2D>("Tiles/wood_dark");
            tileTextures.Add(texture);
            texture = Content.Load<Texture2D>("Tiles/brick");
            tileTextures.Add(texture);

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

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

            int tileMapWidth = tileMap.GetLength(1);
            int tileMapHeight = tileMap.GetLength(0);

            for(int x=0; x < tileMapWidth; x++)
            {
                for (int y=0; y < tileMapHeight; y++)
                {
                    int textureIndex = tileMap[y, x];
                    Texture2D texture = tileTextures[textureIndex];
                    spriteBatch.Draw(
                        texture,
                        destinationRectangle:new Rectangle(x*tileWidth, y*tileHeight, tileWidth, tileHeight)
                        );
                }
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
