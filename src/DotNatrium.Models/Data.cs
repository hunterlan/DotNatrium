namespace DotNatrium.Models
{
    public class Data
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public string Symbol { get; set; } = "";

        public string Description { get; set; } = "";

        public double Count {get; set; }

        public int TypeMeasurementId {get; set;}

        public virtual TypeMeasurement TypeMeasurement { get; set; } = null!;
    }
}