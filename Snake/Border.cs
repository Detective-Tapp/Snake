using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Snake
{
    public class Border
    {
        List<_2DObject> walls = new List<_2DObject>();
        public Border()
        {
            makeBorder();
        }

        private void makeBorder()
        {
            walls.Add(new _2DObject(new Vector2(0, 0), new Vector2(32, 32 * 12)));
            walls.Add(new _2DObject(new Vector2(32*11, 0), new Vector2(32, 32 * 12)));
            walls.Add(new _2DObject(new Vector2(32,0), new Vector2(32 * 10, 32)));
            walls.Add(new _2DObject(new Vector2(32, 32*11), new Vector2(32 * 10, 32)));

            for (int i = 0; i < walls.Count; i++)
            {
                walls[i].Box(new Point((int)walls[i].size.X, (int)walls[i].size.Y), Color.White);
            }
        }

        public void Draw()
        {
            for (int i = 0; i < walls.Count; i++)
            {
                walls[i].Draw();
            }
        }
    }
}
