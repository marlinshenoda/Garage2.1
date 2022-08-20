namespace Garage2._0.Models
{
    public class VehicleTypeEntity
    {
        public int Id { get; set; }

        public string Category { get; set; }

        public int Size { get; set; }

        IEnumerable<Vehicle> vehicles { get; set; } = new List<Vehicle>();
    }
}
