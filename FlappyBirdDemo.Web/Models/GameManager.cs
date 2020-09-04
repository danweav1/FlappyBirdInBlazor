using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlappyBirdDemo.Web.Models
{
    public class GameManager
    {
        private readonly int _gravity = 2;

        public event EventHandler MainLoopCompleted;

        public BirdModel Bird { get; private set; }
        public List<PipeModel> Pipes { get; private set; }
        public bool IsRunning { get; private set; }

        public GameManager()
        {
            Bird = new BirdModel();
            Pipes = new List<PipeModel>();
        }

        public async void MainLoop()
        {
            IsRunning = true;
            while (IsRunning)
            {
                MoveObjects();
                CheckForCollisions();
                ManagePipes();

                MainLoopCompleted?.Invoke(this, EventArgs.Empty);
                await Task.Delay(20);
            }
        }

        public void StartGame()
        {
            if (!IsRunning)
            {
                Bird = new BirdModel();
                Pipes = new List<PipeModel>();
                MainLoop();
            }
        }

        public void Jump()
        {
            if (IsRunning)
            {
                Bird.Jump();
            }
        }

        private void CheckForCollisions()
        {
            if (Bird.IsOnGround())
            {
                GameOver();
            }
        }

        private void ManagePipes()
        {
            if (Pipes.Count == 0 || Pipes.Last().DistanceFromLeft <= 250)
            {
                Pipes.Add(new PipeModel());
            }

            if (Pipes[0].IsOffScreen())
            {
                Pipes.Remove(Pipes[0]);
            }
        }

        public void MoveObjects()
        {
            Bird.Fall(_gravity);
            foreach (var pipe in Pipes)
            {
                pipe.Move();
            }
        }

        public void GameOver()
        {
            IsRunning = false;
        }
    }
}