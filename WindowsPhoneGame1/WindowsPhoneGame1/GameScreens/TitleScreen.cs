using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using XRpgLibrary;
using XRpgLibrary.Controls;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;

namespace WindowsPhoneGame1.GameScreens
{
    public class TitleScreen : BaseGameState
    {
        #region Field region

        Texture2D backgroundImage;
        Song music;
        //LinkLabel startLabel;

        #endregion

        #region Constructor region

        public TitleScreen(Game game, GameStateManager manager)
            : base(game, manager)
        {
        }

        #endregion

        #region XNA Method region

        protected override void LoadContent()
        {
            ContentManager Content = GameRef.Content;
           

            backgroundImage = Content.Load<Texture2D>(@"Backgrounds\titlescreen");

            base.LoadContent();
            music = Content.Load<Song>("preview");
            MediaPlayer.Play(music);
            //startLabel = new LinkLabel();
            //startLabel.Position = new Vector2(35, 600);
            //startLabel.Text = "Touch to countinue";
            //startLabel.Color = Color.White;
            //startLabel.TabStop = true;
            //startLabel.HasFocus = true;
            //startLabel.Selected += new EventHandler(startLabel_Selected);

            //ControlManager.Add(startLabel);
        }

        public override void Update(GameTime gameTime)
        {
            //ControlManager.Update(gameTime, PlayerIndex.One);

            base.Update(gameTime);
             while (TouchPanel.IsGestureAvailable)
            {
                GestureSample gesture = TouchPanel.ReadGesture();

                switch (gesture.GestureType)
                {

                    case GestureType.Tap:
                        Transition(ChangeType.Push, GameRef.StartMenuScreen); 
                        
                    break;


                }
            }
        }

        public override void Draw(GameTime gameTime)
        {
            GameRef.SpriteBatch.Begin();

            base.Draw(gameTime);

            GameRef.SpriteBatch.Draw(
                backgroundImage,
                GameRef.ScreenRectangle,
                Color.White);

            ControlManager.Draw(GameRef.SpriteBatch);

            GameRef.SpriteBatch.End();
        }

        #endregion

        #region Title Screen Methods

        //private void startLabel_Selected(object sender, EventArgs e)
        //{
        //    Transition(ChangeType.Push, GameRef.StartMenuScreen);
        //}

        #endregion
    }
}
