namespace Demo2
{
    public class AutoSystem
    {
        private ICar car;

        public AutoSystem(ICar car)
        {
            this.car = car;
        }

        public void RunCar()
        {
            car.Run();
        }

        public void StopCar()
        {
            car.Stop();
        }

        public void TurnCar()
        {
            car.Turn();
        }
    }
}