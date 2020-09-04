namespace FlappyBirdDemo.Web.Models
{
    public class BirdModel
    {
        public int DistanceFormGround { get; set; } = 100;

        public void Fall(int gravity)
        {
            DistanceFormGround -= gravity;
        }
    }
}