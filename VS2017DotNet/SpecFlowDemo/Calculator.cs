namespace SpecFlowDemo
{
    public class Calculator
    {
        public double First { get; set; }

        public double Second { get; set; }

        public double Result { get; set; }

        public void Add()
        {
            Result = First + Second;
        }

        public void Subtraction()
        {
            Result = First - Second;
        }
    }
}
