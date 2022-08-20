using AutoMapper;
using Garage2._0.Models;
using Garage2._0.Models.ViewModels;

namespace Garage2._0.AutoMapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Vehicle, VehicleIndexViewModel>();
            CreateMap<Vehicle, CreateVehicleViewModel>().ReverseMap();
             CreateMap<Vehicle, VehicleEditViewModel>().ReverseMap();
            CreateMap<Vehicle, VehicleDetailsViewModel>();
             
        }
    }
}
