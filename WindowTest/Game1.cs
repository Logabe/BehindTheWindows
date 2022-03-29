using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;

namespace WindowTest
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Point oldSize;
        Point oldCamera;
        Point camera;
        Point pos = Point.Zero;

        
        Texture2D texture;
        
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);

            Window.AllowUserResizing = true;
            Window.AllowAltF4 = false;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Window.ClientSizeChanged += OnResize;
        }

        protected override void Initialize()
        {
            //Centers the camera
            camera.X = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2 - GraphicsDevice.Viewport.Width;
            camera.Y = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2 - GraphicsDevice.Viewport.Height;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            texture = Content.Load<Texture2D>("Icon");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            //Exit code
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //Check that the window is in the same spot
            if(camera != oldCamera)
            {
                OnMoved();
            }


            //Texture move
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
                pos.Y--;
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
                pos.Y++;
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                pos.X--;
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                pos.X++;

            //More logic
            camera = Window.Position;
            oldCamera = camera;
            oldSize = Window.ClientBounds.Size;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            //Draw testing thing
            _spriteBatch.Begin();
            _spriteBatch.Draw(texture, new Rectangle(pos - camera, new Point(texture.Width, texture.Height)), Color.White);
            _spriteBatch.End();
            
            base.Draw(gameTime);
        }

        //Callbacks
        public void OnResize(Object sender, EventArgs e)
        {
            Point Size = Window.ClientBounds.Size;
            Point Pos = Window.ClientBounds.Location;
            if (Pos.X < camera.X)
            {
                camera.X -= Size.X - oldSize.X;
            }
            if (Pos.Y < camera.Y)
            {
                camera.Y -= Size.Y - oldSize.Y;
            }

        }

        public void OnMoved()
        {
            camera = Window.Position;
        }
    }
}
