﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using XRpgLibrary;
using XRpgLibrary.Controls;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input.Touch;

namespace WindowsPhoneGame1.GameScreens
{
    public abstract partial class BaseGameState : GameState
    {
        #region Fields region

        protected WindowsPhoneGame1.Game1 GameRef;

        protected ControlManager ControlManager;

        protected PlayerIndex playerIndexInControl;

        protected BaseGameState TransitionTo;

        protected bool Transitioning;

        protected ChangeType changeType;

        protected TimeSpan transitionTimer;
        protected TimeSpan transitionInterval = TimeSpan.FromSeconds(0.5);

        protected Rectangle[] places;

        protected int number = 0;

        protected SoundEffect touch;
        #endregion

        #region Properties region
        #endregion

        #region Constructor Region

        public BaseGameState(Game game, GameStateManager manager)
            : base(game, manager)
        {
            GameRef = (WindowsPhoneGame1.Game1)game;

            playerIndexInControl = PlayerIndex.One;
        }

        #endregion

        #region XNA Method Region

        public override void Initialize()
        {
            base.Initialize();
            TouchPanel.EnabledGestures = GestureType.Tap;
        }

        protected override void LoadContent()
        {
            ContentManager Content = Game.Content;

            SpriteFont menuFont = Content.Load<SpriteFont>(@"Fonts\StartMenuFont");
            ControlManager = new ControlManager(menuFont);
            touch = Content.Load<SoundEffect>(@"Sounds\TouchSound");

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (Transitioning)
            {
                transitionTimer += gameTime.ElapsedGameTime;

                if (transitionTimer >= transitionInterval)
                {
                    Transitioning = false;
                    switch (changeType)
                    {
                        case ChangeType.Change:
                            StateManager.ChangeState(TransitionTo);
                            break;
                        case ChangeType.Pop:
                            StateManager.PopState();
                            break;
                        case ChangeType.Push:
                            StateManager.PushState(TransitionTo);
                            break;
                    }
                }
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }

        #endregion

        #region Method Region

        public virtual void Transition(ChangeType change, BaseGameState gameState)
        {
            Transitioning = true;
            changeType = change;
            TransitionTo = gameState;
            transitionTimer = TimeSpan.Zero;
        }

        #endregion
    }
}
