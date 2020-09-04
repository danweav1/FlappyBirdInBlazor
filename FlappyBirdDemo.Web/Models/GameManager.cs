using System.ComponentModel;
using System.Threading.Tasks;

namespace FlappyBirdDemo.Web.Models
{
    public class GameManager : INotifyPropertyChanged
    {
        private readonly int _gravity = 2;

        public event PropertyChangedEventHandler PropertyChanged;

        public BirdModel Bird { get; private set; }
        public PipeModel Pipe { get; private set; }
        public bool IsRunning { get; private set; }

        public GameManager()
        {
            Bird = new BirdModel();
            Pipe = new PipeModel();
        }

        public async void MainLoop()
        {
            IsRunning = true;
            while (IsRunning)
            {
                Bird.Fall(_gravity);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Bird)));

                Pipe.Move();
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Pipe)));

                if (Bird.DistanceFormGround <= 0)
                {
                    GameOver();
                }

                await Task.Delay(20);
            }
        }

        public void StartGame()
        {
            if (!IsRunning)
            {
                Bird = new BirdModel();
                MainLoop();
            }
        }

        public void GameOver()
        {
            IsRunning = false;
        }
    }
}