using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
   
namespace Snake
{
    public class _2DObject
    { 
        protected Texture2D texture;
        protected Vector2 pos;
        public Vector2 size;

        public _2DObject() { }
        public _2DObject(Vector2 pos, Vector2 size)
        {
            this.pos = pos;
            this.size = size;
        }
        public void Box(Point size, Color clr)
        {
            Color[] data = new Color[(int)size.X * (int)size.Y];

            int count = 0;

            for (int i = 0; i < size.X; i++)
            {
                for (int j = 0; j < size.Y; j++)
                {
                    data[count] = clr;
                    count++;
                }
            }
            texture = new Texture2D(Global.GraphicsDevice, (int)size.X, (int)size.Y);
            texture.SetData(data);
        }

        protected void Update() { }
        public void Draw()
        {
            if (texture != null)
                Global.spriteBatch.Draw(texture, new Rectangle((int)pos.X, (int)pos.Y, (int)size.X, (int)size.Y), Color.White);
        }
    }
}
