using Microsoft.Xna.Framework;

namespace Snake
{
    public class Head : _2DObject
    { 
        public Vector2 pos;

        public Head(Vector2 pos, Vector2 size)
        {
            Box(new Point(32,32),Color.DarkGoldenrod);
            this.pos = pos;
            base.size = size;
        }

        public void Update()
        {
            base.pos = pos;
            base.Update();
        }
        public void Draw()
        {
            base.Draw();
        }
    }
}
