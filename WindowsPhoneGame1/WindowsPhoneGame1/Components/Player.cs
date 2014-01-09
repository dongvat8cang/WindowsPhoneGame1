using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using XRpgLibrary;

using XRpgLibrary.SpriteClasses;
using XRpgLibrary.CharacterClasses;

namespace WindowsPhoneGame1.Components
{
    public class Player
    {
        #region Field Region

       
        Game1 gameRef;
        readonly Character character;

        #endregion

        #region Property Region


        public AnimatedSprite Sprite
        {
            get { return character.Sprite; }
        }

        public Character Character
        {
            get { return character; }
        }

        #endregion

        #region Constructor Region

        public Player(Game game, Character character)
        {
            gameRef = (Game1)game;
           
            this.character = character;
        }

        #endregion

        #region Method Region

        public void Update(GameTime gameTime)
        {
           
            Sprite.Update(gameTime);

           

          
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            character.Draw(gameTime, spriteBatch);
        }

        #endregion
    }
}
