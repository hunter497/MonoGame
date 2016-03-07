﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyClone
{
    public class Statics
    {
        public static int GAME_WIDTH = 400;
        public static int GAME_HEIGHT = 600;

        public static String GAME_TITLE = "FlappyClone";

        public static Random RANDOM = new Random();

        public static GameTime GAMETIME;
        public static SpriteBatch SPRITEBATCH;
        public static ContentManager CONTENT;
        public static GraphicsDevice GRAPHICSDEVICE;

        public static Texture2D PIXEL;
        public static Managers.InputManager INPUT;

    }
}
