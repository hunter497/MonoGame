using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Platformer.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Managers
{
    public class ScreenManager
    {
        GameScreen currentScreen;
        GameScreen newScreen;

        private static ScreenManager screenManager;

        Stack<GameScreen> screenStack = new Stack<GameScreen>();

        Vector2 dimensions; 

        public static ScreenManager Instance
        {
            get
            {
                if (screenManager == null)
                    screenManager = new ScreenManager();
                return screenManager;
            }
        }

        public Vector2 Dimensions
        {
            get { return dimensions; }
            set { dimensions = value; }
        }

        public void SetScreen(GameScreen screen)
        {
            newScreen = screen;
            screenStack.Push(screen);
        }

        public void Initialize()
        {

        }

        public void LoadContent(ContentManager content)
        {

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
