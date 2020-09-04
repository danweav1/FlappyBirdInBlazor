using System;

namespace FlappyBirdDemo.Web.Models
{
    public class PipeModel
    {
        public int DistanceFromLeft { get; private set; } = 500;
        public int DistanceFromBottom { get; private set; } = new Random().Next(0, 60);
        public int Speed { get; private set; } = 2;

        public bool IsOffScreen()
        {
            return DistanceFromLeft <= -60; // 60 is length of pipe so if the entire pipe is outside of the game container then we will return true
        }

        public void Move()
        {
            DistanceFromLeft -= Speed;
        }
    }
}