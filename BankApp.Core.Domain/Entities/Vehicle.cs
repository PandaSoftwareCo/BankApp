namespace BankApp.Core.Domain.Entities
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public ICollection<Mileage>? Mileages { get; set; } = new HashSet<Mileage>();
    }
}
