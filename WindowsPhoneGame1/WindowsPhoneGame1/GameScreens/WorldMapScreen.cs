using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

using XRpgLibrary;
using XRpgLibrary.Controls;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Audio;

namespace WindowsPhoneGame1.GameScreens
{
    public class WorldMapScreen : BaseGameState
    {
        #region Field region

        PictureBox backgroundImage;
        PictureBox backgroundImage2;
        PictureBox xmark;
        LinkLabel descriptionname;
        LinkLabel description;
        Rectangle[] area;
        
        float maxItemWidth = 0f;

        #endregion

        #region Property Region
        #endregion

        #region Constructor Region

        public WorldMapScreen(Game game, GameStateManager manager)
            : base(game, manager)
        {
        }

        #endregion

        #region XNA Method Region

        public override void Initialize()
        {
            base.Initialize();
            
            
            
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            ContentManager Content = Game.Content;

            area = new Rectangle[4];
            area[0] = new Rectangle(0, 0, 240, 200);
            area[1] = new Rectangle(240, 0, 240, 200);
            area[2] = new Rectangle(0, 240, 240, 200);
            area[3] = new Rectangle(240, 240, 240, 200);
            backgroundImage = new PictureBox(
                Content.Load<Texture2D>(@"Backgrounds\worldmap"), 
                new Rectangle(0,0,GameRef.ScreenRectangle.Width,GameRef.ScreenRectangle.Height/2));
            ControlManager.Add(backgroundImage);

            backgroundImage2 = new PictureBox(Content.Load<Texture2D>(@"Backgrounds\scrollbackground"),
                new Rectangle(0, GameRef.ScreenRectangle.Height / 2, GameRef.ScreenRectangle.Width, GameRef.ScreenRectangle.Height / 2));
            ControlManager.Add(backgroundImage2);

            //descriptionname = new LinkLabel("The Dark Mountains",new Vector2(180,520),Color.Brown);
            //descriptionname.SpriteFont = Content.Load<SpriteFont>(@"Fonts\WorldMapFont");
            //descriptionname.Size = descriptionname.SpriteFont.MeasureString(descriptionname.Text);
            
            //ControlManager.Add(descriptionname);

            description = new LinkLabel("Enter", new Vector2(190, 585), Color.Brown);
            description.SpriteFont = Content.Load<SpriteFont>(@"Fonts\WorldMapFont");
            description.Size = description.SpriteFont.MeasureString(description.Text);
            description.place = new Rectangle((int)description.Position.X, (int)description.Position.Y, (int)description.Size.X, (int)description.Size.Y);

            ControlManager.Add(description);

            xmark = new PictureBox(Content.Load<Texture2D>("xmark"), new Rectangle(0, 0, 15, 15));
            xmark.Scale = 0.05f;
            ControlManager.Add(xmark);
        }

        //void ControlManager_FocusChanged(object sender, EventArgs e)
        //{
        //    Control control = sender as Control;
        //    Vector2 position = new Vector2(control.Position.X + maxItemWidth + 10f, control.Position.Y);
        //    arrowImage.SetPosition(position);
        //}

        //private void menuItem_Selected(object sender, EventArgs e)
        //{
        //    //if (sender == startGame)
        //    //    //Transition(ChangeType.Push, GameRef.CharacterGeneratorScreen);

        //    //if (sender == loadGame)
        //    //    //Transition(ChangeType.Push, GameRef.LoadGameScreen);

        //    //if (sender == exitGame)
        //    //    GameRef.Exit();
        //}

        public override void Update(GameTime gameTime)
        {
            ControlManager.Update(gameTime, playerIndexInControl);
            while (TouchPanel.IsGestureAvailable)
            {
                GestureSample gesture = TouchPanel.ReadGesture();

                switch (gesture.GestureType)
                {

                    case GestureType.Tap:
                        {
                            if (gesture.Position.Y < 400)
                            {
                                xmark.SetPosition(new Vector2(gesture.Position.X - 5, gesture.Position.Y - 5));
                                touch.Play();
                            }
                            else if (description.place.Contains((int)gesture.Position.X,(int)gesture.Position.Y))
                            {
                                touch.Play();
                                GameRef.BattleScreen.setMap("Beach");
                                Transition(ChangeType.Push,GameRef.BattleScreen);
                            }
                        }
                        break;


                }
            }

            base.Update(gameTime);
            
           
        }

        public override void Draw(GameTime gameTime)
        {
            GameRef.SpriteBatch.Begin();

            base.Draw(gameTime);

            ControlManager.Draw(GameRef.SpriteBatch);

            GameRef.SpriteBatch.End();
        }

        #endregion

        #region Game State Method Region
        #endregion

    }
}
