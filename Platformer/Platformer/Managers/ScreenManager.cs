using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Platformer.Screens;
using System.Collections.Generic;

namespace Platformer.Managers
{
    public class ScreenManager
    {
        private static ScreenManager instance;
        GameScreen currentScreen;
        Stack<GameScreen> screenStack = new Stack<GameScreen>();
        ContentManager content;
        public Vector2 Dimensions { get; set; }

        public static ScreenManager Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new ScreenManager();
                }
                return instance;
            }
        }

        public void SetScreen(GameScreen screen)
        {
            screenStack.Push(screen);
            currentScreen.UnloadContent();
            currentScreen = screen;
            currentScreen.LoadContent(content);
        }

        public void Initialize()
        {
            currentScreen = new SplashScreen();
        }

        public void LoadContent(ContentManager Content)
        {
            content = new ContentManager(Content.ServiceProvider, "Content");
            currentScreen.LoadContent(Content);
        }

        public void Update(GameTime gameTime)
        {
            currentScreen.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentScreen.Draw(spriteBatch);
        }
    }
}
