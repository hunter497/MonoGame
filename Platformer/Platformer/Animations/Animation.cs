using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer.Animations
{
    public class Animation
    {
        protected Texture2D image;
        protected string text;
        protected SpriteFont font;
        protected Color color;
        protected Rectangle sourceRect;
        protected float rotation, scale, axis;
        protected Vector2 origin, position;
        protected ContentManager content;

        public virtual void LoadContent(ContentManager Content, Texture2D image, string text, Vector2 position)
        {
            content = new ContentManager(Content.ServiceProvider, "Content");
            this.image = image;
            this.text = text;
            this.position = position;
            if (text != string.Empty)
            {
                content.Load<SpriteFont>("Fonts/font");
                color = new Color(114, 77, 255);
            }
            if (image != null)
                sourceRect = new Rectangle(0, 0, image.Width, image.Height);
            rotation = 0.0f;
            axis = 0.0f;
            scale = 1.0f;
        }

        public virtual void UnloadContent()
        {
            image = null;
            text = null;
            content.Unload();
        }

        public virtual void Update(GameTime gameTime) { }
        public virtual void Draw(SpriteBatch spriteBatch) { }

    }
}
