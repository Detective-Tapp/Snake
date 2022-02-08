using Microsoft.Xna.Framework;

namespace Snake
{
    public class Body : _2DObject
    {
        public Vector2 pos;
        public Vector2 oldPos;

        public Body(Vector2 pos, Vector2 size)
        {
            oldPos = pos;
            this.pos = pos;
            Box(new Point(32, 32), Color.Green);
            this.size = size;
            base.pos = pos;
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
