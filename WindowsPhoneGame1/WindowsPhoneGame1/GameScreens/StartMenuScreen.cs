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
    public class StartMenuScreen: BaseGameState
    {
        #region Field region

        PictureBox backgroundImage;
        PictureBox arrowImage;
        
        LinkLabel startGame;
        LinkLabel loadGame;
        LinkLabel options;
        LinkLabel exitGame;

        
        float maxItemWidth = 0f;

        #endregion

        #region Property Region
        #endregion

        #region Constructor Region

        public StartMenuScreen(Game game, GameStateManager manager)
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


            //Texture2D arrowTexture = Content.Load<Texture2D>(@"GUI\leftarrowUp");
            
            //arrowImage = new PictureBox(
            //    arrowTexture,
            //    new Rectangle(
            //        0,
            //        0,
            //        arrowTexture.Width,
            //        arrowTexture.Height));
            //ControlManager.Add(arrowImage);


            number = 4;
            places = new Rectangle[number];

            startGame = new LinkLabel();
            startGame.Text = "Start Game";
            startGame.Size = startGame.SpriteFont.MeasureString(startGame.Text);
            startGame.Selected += new EventHandler(menuItem_Selected);

            ControlManager.Add(startGame);

            loadGame = new LinkLabel();
            loadGame.Text = "Load Game";
            loadGame.Size = loadGame.SpriteFont.MeasureString(loadGame.Text);
            loadGame.Selected += menuItem_Selected;

            ControlManager.Add(loadGame);

            options = new LinkLabel();
            options.Text = "Options";
            options.Size = options.SpriteFont.MeasureString(options.Text);
            options.Selected += menuItem_Selected;
            
            ControlManager.Add(options);

            exitGame = new LinkLabel();
            exitGame.Text = "Exit Game";
            exitGame.Size = exitGame.SpriteFont.MeasureString(exitGame.Text);
            exitGame.Selected += menuItem_Selected;

            ControlManager.Add(exitGame);


            

            //ControlManager.NextControl();

            //ControlManager.FocusChanged += new EventHandler(ControlManager_FocusChanged);

            Vector2 position = new Vector2(30, 70);
            foreach (Control c in ControlManager)
            {
                if (c is LinkLabel)
                {
                    c.SpriteFont = Content.Load<SpriteFont>(@"Fonts\StartMenuFont");
                    c.Color = Color.Brown;
                    if (c.Size.X > maxItemWidth)
                        maxItemWidth = c.Size.X;

                    c.Position = position;
                    position.Y += c.Size.Y + 35f;
                }
            }
            //set up rectangle for input touch
            startGame.place = new Rectangle((int)startGame.Position.X, (int)startGame.Position.Y, (int)startGame.Size.X, (int)startGame.Size.Y);
            options.place = new Rectangle((int)options.Position.X, (int)options.Position.Y, (int)options.Size.X, (int)options.Size.Y);

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
            if (sender == startGame)
                //Transition(ChangeType.Push, GameRef.CharacterGeneratorScreen);

            if (sender == loadGame)
                //Transition(ChangeType.Push, GameRef.LoadGameScreen);

            if (sender == exitGame)
                GameRef.Exit();
        }

        public override void Update(GameTime gameTime)
        {
            ControlManager.Update(gameTime, playerIndexInControl);
            while (TouchPanel.IsGestureAvailable)
            {
                GestureSample gesture = TouchPanel.ReadGesture();

                switch (gesture.GestureType)
                {

                    case GestureType.Tap:
                        if (options.place.Contains((int)gesture.Position.X, (int)gesture.Position.Y))
                        {
                            Transition(ChangeType.Push, GameRef.OptionScreen);
                            touch.Play();
                        }
                        else if (startGame.place.Contains((int)gesture.Position.X, (int)gesture.Position.Y))
                        {
                            Transition(ChangeType.Push, GameRef.WorldMapScreen);
                            touch.Play();
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
