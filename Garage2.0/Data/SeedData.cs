using Bogus;
using Garage2._0.Models;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Garage2._0.Data
{
    public class SeedData
    {
       private static Faker faker = default!;
        public static async Task InitVehicleTypeAsync(Garage2_0Context db)
        {
            if (await db.VehicleType.AnyAsync()) return;

            var vehicleTypes = GenerateVehicleTypes();
            await db.AddRangeAsync(vehicleTypes);

            var parkingSpaces = GetParkingSpots();
            await db.AddRangeAsync(parkingSpaces);
          

            await db.SaveChangesAsync();
        }

        private static IEnumerable<ParkingSpace> GetParkingSpots()
        {
            var parkingSpaces = new List<ParkingSpace>
            {
                new ParkingSpace{ NumberSpot = "A1"},
                new ParkingSpace{ NumberSpot = "A2"},
                new ParkingSpace{ NumberSpot = "A3"},
                new ParkingSpace{ NumberSpot = "A4"},
                new ParkingSpace{ NumberSpot = "A5"},
                new ParkingSpace{ NumberSpot = "B1"},
                new ParkingSpace{ NumberSpot = "B2"},
                new ParkingSpace{ NumberSpot = "B3"},
                new ParkingSpace{ NumberSpot = "B4"},
                new ParkingSpace{ NumberSpot = "B5"}
            };

            return parkingSpaces;
        }

        private static IEnumerable<VehicleTypeEntity> GenerateVehicleTypes()
        {
            var vehicleTypes = new List<VehicleTypeEntity>
         {
             new VehicleTypeEntity{ Category = "Car", Size = 1},
             new VehicleTypeEntity{ Category = "Truck", Size = 3},
             new VehicleTypeEntity{ Category = "Boat", Size = 2},
             new VehicleTypeEntity{ Category = "Airplane", Size = 5}
         };

            return vehicleTypes;
        }
    }
}
