using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snake
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    };
    class Settings
    {
        public static int Width, Height, Speed, Score, Points;
        public static bool GameOver;
        public static Direction direction;
        public Settings()
        {
            Width = 16;
            Height = 16;
            Speed = 8;
            Score = 0;
            Points = 100;
            GameOver = false;
            direction = Direction.Down;
        }
    }
}