using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Garage2._0.Models;
using Garage2._0.Models.ViewModels;

namespace Garage2._0.Data
{
    public class Garage2_0Context : DbContext
    {
        public Garage2_0Context (DbContextOptions<Garage2_0Context> options)
            : base(options)
        {
        }

        public DbSet<Garage2._0.Models.ParkedVehicle>? ParkedVehicle { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<ParkedVehicle>().HasData(
        //      new ParkedVehicle { Id = 1, Type = VehicleType.Motorcycle, RegNr = "ABC123", Color = "Red", Brand = "Ford", Model = "2", NrOfWheels = 4 },
        //      new ParkedVehicle { Id = 2, Type = VehicleType.Car, RegNr = "DEF234", Color = "Blue", Brand = "Ford", Model = "2", NrOfWheels = 4},
        //      new ParkedVehicle { Id = 3, Type = VehicleType.Boat, RegNr = "GHI345", Color = "Green", Brand = "Ford", Model = "2", NrOfWheels = 4 },
        //      new ParkedVehicle { Id = 4, Type = VehicleType.Motorcycle, RegNr = "JKL456", Color = "Yellow", Brand = "Ford", Model = "2", NrOfWheels = 4}

        //    );
        //}


        public DbSet<Garage2._0.Models.Member> Member => Set<Member>();


        public DbSet<Garage2._0.Models.Vehicle>? Vehicle { get; set; }
        public DbSet<Garage2._0.Models.VehicleTypeEntity>? VehicleType { get; set; }
        public DbSet<Garage2._0.Models.Park>? Park { get; set; }
        public DbSet<Garage2._0.Models.ParkingSpace>? ParkingSpace { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Member>().HasData(
            //    new Member { Id = 1, FirstName = "John", LastName = "Doe", PerNr = "123456" },
            //    new Member { Id = 2, FirstName = "Jane", LastName = "Doe", PerNr = "123" }
            //);
            //modelBuilder.Entity<VehicleTypeEntity>().HasData(
            //    new VehicleTypeEntity { Id = 1, Category = "Car", Size = 1 }
            //);

            //modelBuilder.Entity<Vehicle>().HasData(
            //    new Vehicle { Id = 1, RegNr = "AAA111", Color = "Red", Brand = "Volvo", Model = "V20", NrOfWheels = 4, MemberId = 1, VehicleTypeEntityId = 1 },
            //    new Vehicle { Id = 2, RegNr = "BBB222", Color = "Black", Brand = "Mercedes", Model = "X100", NrOfWheels = 4, MemberId = 1, VehicleTypeEntityId = 1 },
            //    new Vehicle { Id = 3, RegNr = "CCC333", Color = "White", Brand = "Ferrari", Model = "E-Type", NrOfWheels = 4, MemberId = 1, VehicleTypeEntityId = 1 },
            //    new Vehicle { Id = 4, RegNr = "DDD444", Color = "Blue", Brand = "Volvo", Model = "V20", NrOfWheels = 4, MemberId = 2, VehicleTypeEntityId = 1 }
            //);

            //modelBuilder.Entity<ParkingSpace>().HasData(
            //    new ParkingSpace { Id = 1, NumberSpot = "A1" },
            //    new ParkingSpace { Id = 2, NumberSpot = "A2" },
            //    new ParkingSpace { Id = 3, NumberSpot = "A3" },
            //    new ParkingSpace { Id = 4, NumberSpot = "A4" }
            //);
        }
    }
}
