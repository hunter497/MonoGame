using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FlappyClone
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class FlappyClone : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Screens.Screen currentScreen;

        public FlappyClone()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            Statics.CONTENT = Content;
            Statics.GRAPHICSDEVICE = GraphicsDevice;

            graphics.PreferredBackBufferHeight = Statics.GAME_HEIGHT;
            graphics.PreferredBackBufferWidth = Statics.GAME_WIDTH;
            Window.Title = Statics.GAME_TITLE;
            graphics.ApplyChanges();

            Managers.InputManager input = new Managers.InputManager();
            Statics.INPUT = input;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>

        protected override void LoadContent()
        {          
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Statics.SPRITEBATCH = spriteBatch;

            currentScreen = new Screens.GameScreen();

            currentScreen.LoadContent();

        }


        protected override void Update(GameTime gameTime)
        {
            Statics.GAMETIME = gameTime;
            Statics.INPUT.Update();

            currentScreen.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            currentScreen.Draw();

            base.Draw(gameTime);
        }
    }
}
