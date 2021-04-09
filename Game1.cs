using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;


namespace Monogame_3___Animations_Part_2_Lists
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Random generator;

        MouseState mouseState;

        Texture2D tribbleBrownTexture;
        Texture2D tribbleCreamTexture;
        Texture2D tribbleGreyTexture;
        Texture2D tribbleOrangeTexture;
        Texture2D tribbleIntroTexture;

        List<Texture2D> tribbleTextures; // To be used to select a random tribble

        List <Tribble> tribbles;

        enum Screen
        {
            Intro,
            TribbleYard
        }

        Screen screen;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.Window.Title = "Lesson 3 - Animation Part 2";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = 800;  // set this value to the desired width of your window
            _graphics.PreferredBackBufferHeight = 500;   // set this value to the desired height of your window
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            generator = new Random();
            screen = Screen.Intro;

            base.Initialize();

            tribbles = new List<Tribble>();
            tribbleTextures = new List<Texture2D>(){
                tribbleBrownTexture, 
                tribbleCreamTexture, 
                tribbleGreyTexture, 
                tribbleOrangeTexture
            };
         
            for (int i = 0; i < 20; i++)
            {
                int size = generator.Next(50, 100); // Wee need the size of a tribble before we can assign it to a random location so it always appears on the screen
                tribbles.Add(new Tribble(tribbleTextures[generator.Next(tribbleTextures.Count)], new Rectangle(generator.Next(_graphics.PreferredBackBufferWidth - size), generator.Next(_graphics.PreferredBackBufferHeight - size), size, size), new Vector2(generator.Next(-2, 3), generator.Next(-2, 3))));
            }
            
            


        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            tribbleGreyTexture = Content.Load<Texture2D>("tribbleGrey");
            tribbleBrownTexture = Content.Load<Texture2D>("tribbleBrown");
            tribbleCreamTexture = Content.Load<Texture2D>("tribbleCream");
            tribbleOrangeTexture = Content.Load<Texture2D>("tribbleOrange");
            tribbleIntroTexture = Content.Load<Texture2D>("tribble_intro");
            // Create a list of tribbles


        }

        protected override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (screen == Screen.Intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                    screen = Screen.TribbleYard;
            }
            else if (screen == Screen.TribbleYard)
            {
                foreach (Tribble tribble in tribbles)
                {
                    tribble.move();
                    if (tribble.Bounds.Right > _graphics.PreferredBackBufferWidth || tribble.Bounds.Left < 0)
                        tribble.bumpSide();
                    if (tribble.Bounds.Bottom > _graphics.PreferredBackBufferHeight || tribble.Bounds.Top < 0)
                        tribble.bumpTopBottom();
                }
            }

            // TODO: Add your update logic here
            
            
       

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(tribbleIntroTexture, new Rectangle(0, 0, 800, 500), Color.White);
            }
            else if (screen == Screen.TribbleYard)
            {
                foreach (Tribble tribble in tribbles)
                    _spriteBatch.Draw(tribble.Texture, tribble.Bounds, Color.White);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
