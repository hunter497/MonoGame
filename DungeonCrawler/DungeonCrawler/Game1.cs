using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using TileEngine;

namespace DungeonCrawler
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Camera camera;

        TileLayer tileLayer;
        TileLayer tileLayer2;
        TileLayer tileLayer3;

        TileMap tileMap;

        int screenWidth;
        int screenHeight;

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
            camera = new Camera();
            tileMap = new TileMap();


            screenWidth = GraphicsDevice.Viewport.Width;
            screenHeight = GraphicsDevice.Viewport.Height;

            base.Initialize();

            tileMap.Layers.Add(tileLayer);
            tileMap.Layers.Add(tileLayer2);
            tileMap.Layers.Add(tileLayer3);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            tileLayer = TileLayer.FromFile(Content, "Content/Layers/Layer1.layer");

            tileLayer2 = TileLayer.FromFile(Content, "Content/Layers/Layer2.layer");

            tileLayer3 = TileLayer.FromFile(Content, "Content/Layers/Layer3.layer");
            tileLayer3.Alpha = .5f;

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
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

            camera.Update();

            if (camera.Position.X < 0)
                camera.Position.X = 0;
            if (camera.Position.Y < 0)
                camera.Position.Y = 0;
            if (camera.Position.X > tileLayer.WidthInPixels - screenWidth)
                camera.Position.X = tileLayer.WidthInPixels - screenWidth;
            if (camera.Position.Y > tileLayer.HeightInPixels - screenHeight)
                camera.Position.Y = tileLayer.HeightInPixels - screenHeight;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            tileMap.Draw(spriteBatch, camera);

            base.Draw(gameTime);
        }
    }
}
