using AutoMapper;
using Garage2._0.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Garage2._0.Services;

public class VehicleTypeService : IVehicleTypeService
{
    private readonly Garage2_0Context _context;

    public VehicleTypeService(Garage2_0Context context)
    {
        _context = context;
    }

    public async Task<IEnumerable<SelectListItem>> GetVehiclesType()
    {
        return await _context.VehicleType
                    .Select(m => new SelectListItem
                    {
                        Text = m.Category.ToString(),
                        Value = m.Id.ToString()
                    })
                    .ToListAsync();
    }



}
