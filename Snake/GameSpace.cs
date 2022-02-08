using Microsoft.Xna.Framework;

namespace Snake
{
    public class GameSpace
    {
        public static Snek snek;
        public static Apple apple;
        private Border border;

        private MCTimer gameTick;

        private int interval = 350;

        public GameSpace()
        {
            gameTick = new MCTimer(interval);
            snek = new Snek();
            apple = new Apple(new Vector2(32*5,32*6), Global.size);
            border = new Border();
        }
        public void Update()
        {
            gameTick.UpdateTimer();

            if (gameTick.Test())
            {
                snek.Update();
                apple.Update();

                gameTick.ResetToZero();
            }
        }
        public void Draw() 
        {
            border.Draw();
            snek.Draw();
            apple.Draw();
        }
    }
}
