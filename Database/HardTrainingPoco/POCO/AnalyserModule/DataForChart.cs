namespace HardTrainingPoco.POCO.AnalyserModule
{
    public class DataForChart
    {
        public DataForChart(float value, double date)
        {
            this.ValueOfMeasure = value;
            this.DateOfMeasurment = date;
        }

        public double DateOfMeasurment { get;  set; }
        public float ValueOfMeasure { get; set; }
    }
}