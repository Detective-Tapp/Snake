using Microsoft.Xna.Framework;

namespace Snake
{
    public class Apple : _2DObject
    {
        public bool[,] forbiddenTiles = new bool[10,10];
        public Vector2 pos;
        public Vector2 size;
        public Apple(Vector2 pos, Vector2 size) 
        {
            Box(new Point(32, 32), Color.Red);
            this.pos = pos;
            this.size = size;

            base.pos = pos;
            base.size = size;
        }
        public void respawn()
        {
            start:
            int i = Global.random.Next(10);
            int j = Global.random.Next(10);

            if (forbiddenTiles[i, j] == true)
                goto start;
            else
                pos = new Vector2(32 + (32* i), 32 + (32 * j));
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
