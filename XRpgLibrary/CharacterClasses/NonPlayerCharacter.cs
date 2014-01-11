using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XRpgLibrary.SpriteClasses;

using RpgLibrary.CharacterClasses;


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XRpgLibrary.CharacterClasses
{
    public class NonPlayerCharacter : Character
    {
        #region Field Region

     
        #endregion

        #region Property Region

       

    

        #endregion

        #region Constructor Region

        public NonPlayerCharacter(Entity entity, AnimatedSprite sprite)
            : base(entity, sprite)
        {
        }    
        

        #endregion

        #region Method Region
        #endregion

        #region Virtual Method region

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }

        #endregion
    }
}
