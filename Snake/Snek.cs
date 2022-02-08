using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Snake
{
    enum SnakeDirection
    {
        left = 0,
        right = 1,
        down = 2,
        up = 3
    }
    public class Snek : Unit
    {
        SnakeDirection oldDirection;
        SnakeDirection snakeDirection;
        List<Body> bodies = new List<Body>();   
        Head head;

        bool isDead;
        public Snek()
        {
            head = new Head(new Vector2(32 * 10, 32 * 4), Global.size);
            initializeSnek();
            snakeDirection = SnakeDirection.left;
        }
        private void initializeSnek()
        {
            bodies.Add(new Body(new Vector2(64, 64), Global.size));
            bodies.Add(new Body(new Vector2(64, 64), Global.size));
            bodies.Add(new Body(new Vector2(64, 64), Global.size));
        }
        private void input ()
        {
            oldDirection = snakeDirection;
            if (Keyboard.GetState().IsKeyDown(Keys.Left) && snakeDirection == SnakeDirection.right)
            {
                snakeDirection = SnakeDirection.up;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right) && snakeDirection == SnakeDirection.right)
            {
                snakeDirection = SnakeDirection.down;
            }

            if (oldDirection != snakeDirection)
                goto marker;

            if (Keyboard.GetState().IsKeyDown(Keys.Left) && snakeDirection == SnakeDirection.left)
            { 
                snakeDirection = SnakeDirection.down;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right) && snakeDirection == SnakeDirection.left)
            {
                snakeDirection = SnakeDirection.up;
            }

            if (oldDirection != snakeDirection)
                goto marker;

            if (Keyboard.GetState().IsKeyDown(Keys.Left) && snakeDirection == SnakeDirection.up)
            {
                snakeDirection = SnakeDirection.left;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right) && snakeDirection == SnakeDirection.up)
            {
                snakeDirection = SnakeDirection.right;
            }

            if (oldDirection != snakeDirection)
                goto marker;

            if (Keyboard.GetState().IsKeyDown(Keys.Left) && snakeDirection == SnakeDirection.down)
            {
                snakeDirection = SnakeDirection.right;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right) && snakeDirection == SnakeDirection.down)
            {
                snakeDirection = SnakeDirection.left;
            }

            marker:

            if (snakeDirection == SnakeDirection.up)
                head.pos.Y -= Global.size.X;
            if (snakeDirection == SnakeDirection.down)
                head.pos.Y += Global.size.X;
            if (snakeDirection == SnakeDirection.left)
                head.pos.X -= Global.size.X;
            if (snakeDirection == SnakeDirection.right)
                head.pos.X += Global.size.X;
        }
        private void collision()
        {
            for (int i = 0; i < bodies.Count; i++)
            {
                if (head.pos == bodies[i].pos)
                    isDead = true;
            }
            if (head.pos == GameSpace.apple.pos)
            {
                bodies.Add(new Body(bodies[bodies.Count-1].pos, Global.size));
                GameSpace.apple.respawn();
            }
            if (head.pos.X <= 0 || head.pos.X >= 32 * 11)
                isDead = true;
            
            if (head.pos.Y <= 0 || head.pos.Y >= 32 * 11)
                isDead = true;
        }
        public void Update()
        {
            if (isDead != true)
            {
                for (int i = 0; i < bodies.Count; i++)
                {
                    if (i == 0)
                    {
                        bodies[i].oldPos = bodies[i].pos;
                        bodies[i].pos = head.pos;
                    }
                    else
                    {
                        bodies[i].oldPos = bodies[i].pos;
                        bodies[i].pos = bodies[i - 1].oldPos;
                    }
                    bodies[i].Update();
                }
                input();
                head.Update();
                collision();
                if (isDead != true)
                {
                    bool[,] tempArray = new bool[10, 10];

                    for (int i = 0; i < bodies.Count; i++)
                    {
                        tempArray[(int)((bodies[i].pos.X - 32) / 32), (int)((bodies[i].pos.Y - 32) / 32)] = true;
                    }
                    tempArray[(int)((head.pos.X - 32) / 32), (int)((head.pos.Y - 32) / 32)] = true;

                    GameSpace.apple.forbiddenTiles = tempArray;
                }
            }
            base.Update();
        }
        public void Draw()
        {
            head.Draw();
            for (int i = 0; i < bodies.Count; i++)
            {
                bodies[i].Draw();
            }
            base.Draw();
        }
    }
}
