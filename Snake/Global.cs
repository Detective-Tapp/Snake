using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;


namespace Snake
{
    public static class Global
    {
        public static GraphicsDevice GraphicsDevice;
        public static SpriteBatch spriteBatch;
        public static ContentManager contentManager;

        public static GameTime gameTime;

        public static Vector2 size = new Vector2(32,32);

        public static int screenHeight, screenWidth;
        public static Random random = new Random();
    }
}
