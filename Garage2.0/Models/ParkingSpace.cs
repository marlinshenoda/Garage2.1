namespace Garage2._0.Models
{
    public class ParkingSpace
    {
        public int Id { get; set; }
        public string NumberSpot { get; set; }
        public Park? Park { get; set; }
    }
}
