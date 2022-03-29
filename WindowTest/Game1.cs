using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace WindowTest
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Point camera;
        Point pos = Point.Zero;

        Texture2D texture;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            camera.X = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2 - 400;
            camera.Y = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2 - 240;
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.W))
                camera.Y--;
            if (Keyboard.GetState().IsKeyDown(Keys.S))
                camera.Y++;
            if (Keyboard.GetState().IsKeyDown(Keys.A))
                camera.X--;
            if (Keyboard.GetState().IsKeyDown(Keys.D))
                camera.X++;
            //Texture move
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
                pos.Y--;
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
                pos.Y++;
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                pos.X--;
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                pos.X++;
            Window.Position = camera;
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            _spriteBatch.Draw(texture, new Rectangle(pos - camera, new Point(texture.Width, texture.Height)), Color.White);
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
