using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Snake
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        private GameSpace gameSpace;
        private GraphicsDeviceManager graphics;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

        }

        protected override void Initialize()
        {
            Global.GraphicsDevice = GraphicsDevice;
            Global.spriteBatch = new SpriteBatch(GraphicsDevice);
            Global.contentManager = Content;

            // TODO: Add your initialization logic here
            Global.screenWidth = 1600;
            Global.screenHeight = 900;

            graphics.PreferredBackBufferWidth = Global.screenWidth;
            graphics.PreferredBackBufferHeight = Global.screenHeight;

            graphics.ApplyChanges();


            base.Initialize();
        }

        protected override void LoadContent()
        {

            // TODO: use this.Content to load your game content here
            gameSpace = new GameSpace();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            Global.gameTime = gameTime;
            gameSpace.Update();
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            Global.spriteBatch.Begin();

            gameSpace.Draw();

            Global.spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
