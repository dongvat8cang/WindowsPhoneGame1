using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XRpgLibrary.CharacterClasses;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using XRpgLibrary.ItemClasses;

namespace XRpgLibrary.WorldClasses
{
    public class Level
    {
        #region Field Region

       
        readonly List<Character> characters;
        readonly List<ItemSprite> chests;

        #endregion

        #region Property Region

       

        public List<Character> Characters
        {
            get { return characters; }
        }

        public List<ItemSprite> Chests
        {
            get { return chests; }
        }

        #endregion

        #region Constructor Region

       

        #endregion

        #region Method Region

        public void Update(GameTime gameTime)
        {
            foreach (Character character in characters)
                character.Update(gameTime);

            foreach (ItemSprite sprite in chests)
                sprite.Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            
            foreach (Character character in characters)
                character.Draw(gameTime, spriteBatch);

            foreach (ItemSprite sprite in chests)
                sprite.Draw(gameTime, spriteBatch);
        }

        #endregion
    }
}
