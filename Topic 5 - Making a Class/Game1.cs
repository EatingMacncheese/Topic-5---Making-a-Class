using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Topic_5___Making_a_Class
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private enum Screen
        {
            Title,
            House,
            End
        }
        KeyboardState keyboardState;
        Screen screen;
        MouseState mouseState;
        Rectangle window;
        List<Texture2D> ghostTextures;
        Ghost ghost1;
        Texture2D hauntedBackgroundTexture, titleTexture, endTexture;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            window = new Rectangle(0, 0, 800, 600);
            base.Initialize();
            ghost1 = new Ghost(ghostTextures, new Rectangle(150, 250, 40, 40));
            

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            hauntedBackgroundTexture = Content.Load<Texture2D>("Images/haunted-background");
            ghostTextures = new List<Texture2D>();
            ghostTextures.Add(Content.Load<Texture2D>("Images/boo-stopped"));
            titleTexture = Content.Load<Texture2D>("Images/haunted-title");
            for (int i = 1; i <= 8; i++)
                ghostTextures.Add(Content.Load<Texture2D>("Images/boo-move-" + i));


        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            mouseState = Mouse.GetState();
            keyboardState = Keyboard.GetState();
            ghost1.Update(mouseState, gameTime);
            if (screen == Screen.Title)
            {
                if (keyboardState.IsKeyDown(Keys.Enter))
                    screen = Screen.House;

            }
            else if (screen == Screen.House)
            {
                ghost1.Update(gameTime, mouseState);
                if (ghost1.Contains(mouseState.Position))
                    screen = Screen.End;

            }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            _spriteBatch.Draw(hauntedBackgroundTexture, window, Color.White);
            ghost1.Draw(_spriteBatch);
            if (screen == Screen.Title)
                _spriteBatch.Draw(titleTexture, window, Color.White);
            else if (screen == Screen.House)
            {
                _spriteBatch.Draw(hauntedBackgroundTexture, window, Color.White);
                ghost1.Draw(_spriteBatch);
            }
            else
                _spriteBatch.Draw(endTexture, window, Color.White);
            _spriteBatch.End();
            base.Draw(gameTime);
        }


    }
}
