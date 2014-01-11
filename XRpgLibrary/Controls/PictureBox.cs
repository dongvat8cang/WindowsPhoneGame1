using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace XRpgLibrary.Controls
{
    public class PictureBox : Control
    {
        #region Field Region

        Texture2D image;
        Rectangle sourceRect;
        Rectangle destRect;
        float scale = 1f;

        public float Scale
        {
            get { return scale; }
            set { scale = value; }
        }

        #endregion

        #region Property Region

        public Texture2D Image
        {
            get { return image; }
            set { image = value; }
        }

        public Rectangle SourceRectangle
        {
            get { return sourceRect; }
            set { sourceRect = value; }
        }

        public Rectangle DestinationRectangle
        {
            get { return destRect; }
            set { destRect = value; }
        }
        
        #endregion

        #region Constructors

        public PictureBox(Texture2D image, Rectangle destination)
        {
            Image = image;
            DestinationRectangle = destination;
            SourceRectangle = new Rectangle(0, 0, image.Width, image.Height);
            Color = Color.White;
        }

        public PictureBox(Texture2D image, Rectangle destination, Rectangle source)
        {
            Image = image;
            DestinationRectangle = destination;
            SourceRectangle = source;
            Color = Color.White;
        }

        #endregion

        #region Abstract Method Region

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            //SpriteBatch.Draw(image, destRect, sourceRect, Color.White, null, scale, SpriteEffects.None, 0f);
            if (scale == 1f)
            { spriteBatch.Draw(image, destRect, sourceRect, color); }
            else spriteBatch.Draw(image, position, sourceRect, Color.White, 0f, new Vector2(0, 0), scale, SpriteEffects.None, 0f);
        }

        public override void HandleInput(PlayerIndex playerIndex)
        {
        }

        #endregion

        #region Picture Box Methods

        public void SetPosition(Vector2 newPosition)
        {
            destRect = new Rectangle(
                (int)newPosition.X,
                (int)newPosition.Y,
                sourceRect.Width,
                sourceRect.Height);

            position = newPosition;
        }

        #endregion
    }
}
