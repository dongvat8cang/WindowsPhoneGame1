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

namespace WindowsPhoneGame1.GameScreens
{
    public class OptionScreen : BaseGameState
    {
        #region Field region

        PictureBox backgroundImage;
        

        LinkLabel[] option;
        LinkLabel[] value;
         
        float maxItemWidth = 0f;

        #endregion

        #region Property Region
        #endregion

        #region Constructor Region

        public OptionScreen(Game game, GameStateManager manager)
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

            backgroundImage = new PictureBox(
                Content.Load<Texture2D>(@"Backgrounds\startmenu"), 
                GameRef.ScreenRectangle);
            ControlManager.Add(backgroundImage);

          

            number = 4;
            places = new Rectangle[number];

            option = new LinkLabel[4];
            value = new LinkLabel[4];
            for (int i = 0; i < 4; i++)
            {
                option[i] = new LinkLabel();
                value[i] = new LinkLabel();
                if (i < 3)  ControlManager.Add(option[i]);
                ControlManager.Add(value[i]);
            }

            
            option[0].Text = "*Graphics Detail";
            option[1].Text = "*Difficulty";
            option[2].Text = "<Back";
            value[0].Text = "Low";
            value[1].Text = "High";
            value[2].Text = "Easy";
            value[3].Text = "Hard";
            
            

          

            //ControlManager.NextControl();

            //ControlManager.FocusChanged += new EventHandler(ControlManager_FocusChanged);

            Vector2 position = new Vector2(60, 140);
            foreach (Control c in ControlManager)
            {
                if (c is LinkLabel)
                {
                    c.SpriteFont = Content.Load<SpriteFont>(@"Fonts\StartMenuFont");
                    c.Color = Color.Brown;
                 
                }
            }

            option[0].Position = new Vector2(30, 70);
            option[1].Position = new Vector2(30, 210);
            option[2].Position = new Vector2(20, 680);
            option[2].Size = option[2].SpriteFont.MeasureString(option[2].Text);
            option[2].Place = new Rectangle((int)option[2].Position.X, (int)option[2].Position.Y, (int)option[2].Size.X, (int)option[2].Size.Y);
            for (int i = 0; i < 4; i++)
            {
                if (i == 0)
                {
                    value[i].Position = new Vector2(60, 140);
                    value[i].Color = Color.Red;
                }
                else if (i == 1) value[i].Position = new Vector2(240, 140);
                else if (i == 2)
                {
                    value[i].Position = new Vector2(60, 280);
                    value[i].Color = Color.Red;
                }
                else if (i == 3) value[i].Position = new Vector2(240, 280);
                value[i].Size = value[i].SpriteFont.MeasureString(value[i].Text);
            value[i].Place = new Rectangle((int)value[i].Position.X, (int)value[i].Position.Y, (int)value[i].Size.X, (int)value[i].Size.Y);
            value[i].Selected += new EventHandler(menuItem_Selected);
           
            

            


        
            }

            //ControlManager_FocusChanged(startGame, null);
        }

        //void ControlManager_FocusChanged(object sender, EventArgs e)
        //{
        //    Control control = sender as Control;
        //    Vector2 position = new Vector2(control.Position.X + maxItemWidth + 10f, control.Position.Y);
        //    arrowImage.SetPosition(position);
        //}

        private void menuItem_Selected(object sender, EventArgs e)
        {
        //    if (sender == startGame)
        //        //Transition(ChangeType.Push, GameRef.CharacterGeneratorScreen);

        //    if (sender == loadGame)
        //        //Transition(ChangeType.Push, GameRef.LoadGameScreen);

        //    if (sender == exitGame)
                GameRef.Exit();
        }

        public override void Update(GameTime gameTime)
        {
            ControlManager.Update(gameTime, playerIndexInControl);
            
            base.Update(gameTime);
            while (TouchPanel.IsGestureAvailable)
            {
                GestureSample gesture = TouchPanel.ReadGesture();

                switch (gesture.GestureType)
                {

                    case GestureType.Tap:
                       
                        if (option[2].place.Contains((int)gesture.Position.X,(int)gesture.Position.Y))
                        {touch.Play();
                        Transition(ChangeType.Pop, GameRef.OptionScreen);
                        }
                        else if (value[0].place.Contains((int)gesture.Position.X, (int)gesture.Position.Y))
                        {
                            value[0].Color = Color.Red;
                            value[1].Color = Color.Brown;
                            touch.Play();
                        }
                        else if (value[1].place.Contains((int)gesture.Position.X, (int)gesture.Position.Y))
                        {
                            value[1].Color = Color.Red;
                            value[0].Color = Color.Brown;
                            touch.Play();
                        }
                        else if (value[2].place.Contains((int)gesture.Position.X, (int)gesture.Position.Y))
                        {
                            value[2].Color = Color.Red;
                            value[3].Color = Color.Brown;
                            touch.Play();
                        }
                        else if (value[3].place.Contains((int)gesture.Position.X, (int)gesture.Position.Y))
                        {
                            value[3].Color = Color.Red;
                            value[2].Color = Color.Brown;
                            touch.Play();
                        }
                        break;


                }
            }
           
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
