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
        protected float alpha;
        protected bool isActive { get; set; }

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
            alpha = 1.0f;
            isActive = false;
        }

        public virtual void UnloadContent()
        {
            image = null;
            text = string.Empty;
            sourceRect = Rectangle.Empty;
            content.Unload();
        }

        public virtual void Update(GameTime gameTime) { }
        public virtual void Draw(SpriteBatch spriteBatch) {
            if(image != null)
            {
                origin = new Vector2(sourceRect.Width / 2, sourceRect.Height / 2);
                spriteBatch.Draw(image, position + origin, sourceRect, Color.White, rotation, origin, scale, SpriteEffects.None, 0.0f);
            }

            if(text != string.Empty)
            {
                origin = new Vector2(font.MeasureString(text).X / 2, font.MeasureString(text).Y / 2);
                spriteBatch.DrawString(font, text, position + origin, color, rotation, origin, scale, SpriteEffects.None, 0.0f);
            }
        }

    }
}
