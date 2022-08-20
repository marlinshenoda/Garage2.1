using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Garage2._0.Data;
using Garage2._0.Models;
using AutoMapper;
using Garage2._0.Models.ViewModels;
using Bogus;



namespace Garage2._0.Controllers
{
    public class VehiclesController : Controller
    {
        private readonly Garage2_0Context _context;
        private readonly IMapper mapper;

        public VehiclesController(Garage2_0Context context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        // GET: Vehicles
        public async Task<IActionResult> Index()
        {
            var viewModel = await mapper.ProjectTo<VehicleIndexViewModel>(_context.Vehicle)
                  .OrderByDescending(s => s.Id)
                  .ToListAsync();

            return View(viewModel);
        }
        
        // GET: Vehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Vehicle == null)
            {
                return NotFound();
            }

            //var vehicle = await mapper.ProjectTo<VehicleDetailsViewModel>(_context.Vehicle)
            //                            .FirstOrDefaultAsync(s => s.Id == id);
            var vehicle = _context.Vehicle.Include(n => n.VehicleTypeEntity).Include(o => o.Member).FirstOrDefault(m => m.Id == id);
            if (vehicle == null)
            {
                return NotFound();
            }
            var viewModel = new VehicleDetailsViewModel();
            viewModel.Id = vehicle.Id;
            viewModel.FullName = vehicle.Member.FullName;
            viewModel.PerNr = vehicle.Member.PerNr;
            viewModel.RegNr = vehicle.RegNr;
            viewModel.Color = vehicle.Color;
            viewModel.Brand = vehicle.Brand;
            viewModel.Model = vehicle.Model;
            viewModel.NrOfWheels = vehicle.NrOfWheels;
            viewModel.Type = vehicle.VehicleTypeEntity.Category;
            //var vehicle = await _context.Vehicle
            //    .Include(v => v.Member)
            //    .FirstOrDefaultAsync(m => m.Id == id);

            return View(viewModel);
        }

        // GET: Vehicles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( CreateVehicleViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var vehicleTypeEntity = _context.VehicleType.FirstOrDefault(vehicleType => vehicleType.Id == viewModel.VehicleTypeEntityId);
                var memberEntity = _context.Member.FirstOrDefault(member => member.Id == viewModel.MemberId);
                var vehicle = mapper.Map<Vehicle>(viewModel);

                var vehicleEntity = mapper.Map<Vehicle>(viewModel);
                vehicleEntity.VehicleTypeEntity = vehicleTypeEntity;
                vehicleEntity.Member = memberEntity;

                _context.Add(vehicle);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "" + vehicleTypeEntity.Category + " with registration number " + vehicle.RegNr + " parked successfully ";

                return RedirectToAction(nameof(Index));

            }
            return View(viewModel);
        }
        //Search by regNr

        public async Task<IActionResult> Filter(string regNr, int? type, ParkingSpacesViewModel vM)
        {
            var vehicles = string.IsNullOrWhiteSpace(regNr) ?
                                   _context.ParkingSpace :
                                  _context.ParkingSpace
                                  .Include(n => n.Park)
                                  .ThenInclude(o => o.Vehicle)
                                  .ThenInclude(v => v.Member)
                                  .Where(m => m.Park.Vehicle.RegNr
                                  .StartsWith(regNr));


            vehicles = type == null ?
                             vehicles :
                             vehicles.Where(m => m.Park.Vehicle.VehicleTypeEntityId == type);


            var viewModel = vehicles.Select(p => new ParkingSpacesViewModel
            {
                RegNr = p.Park.Vehicle.RegNr,
                Id = p.Id,
                ArrivalTime = p.Park.ArrivalTime,
                Type = p.Park.Vehicle.VehicleTypeEntity.Category,
                FullName = p.Park.Vehicle.Member.FullName,
                NumberSpot = p.NumberSpot,
                VehicleId = p.Park.Vehicle.Id,
                Occupied = true
               
            });

            return View(nameof(ParkingSpaceIndex), viewModel);

        }





        // GET: Vehicles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Vehicle == null)
            {
                return NotFound();
            }
            var vehicle = await mapper.ProjectTo<VehicleEditViewModel>(_context.Vehicle)
                                      .FirstOrDefaultAsync(s => s.Id == id);
          //  var vehicle = await _context.Vehicle.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
          //  ViewData["MemberId"] = new SelectList(_context.Member, "Id", "Id", vehicle.MemberId);
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, VehicleEditViewModel viewModel)
        {
            if (id != viewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var vehicle = await _context.Vehicle.Include(s => s.VehicleTypeEntity)
                       .FirstOrDefaultAsync(s => s.Id == id);

                    mapper.Map(viewModel, vehicle);
                    _context.Update(vehicle);
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExists(viewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                TempData["SuccessMessage"] = " Vehicle Edited Successfully ";

                return RedirectToAction(nameof(Index));
            }

           // ViewData["MemberId"] = new SelectList(_context.Member, "Id", "Id", vehicle.MemberId);
            return View(viewModel);
        }
        public IActionResult IsRegNrUsed(string RegNr, int Id)
        {
            var regNr = _context.Vehicle.FirstOrDefault(m => m.RegNr == RegNr);
            if (regNr == null || regNr.Id == Id)
            {
                return Json(true);
            }

            else
            {
                return Json(false);
            }


        }
        // GET: Vehicles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Vehicle == null)
            {
                return NotFound();
            }

            var vehicle = _context.Vehicle.
                Include(n => n.VehicleTypeEntity).
                Include(o => o.Member).
                Include(p => p.Park).
                ThenInclude(q => q.Spaces).
                FirstOrDefault(m => m.Id == id);

            var viewModel = new VehicleDeleteViewModel();
            viewModel.Id = vehicle.Id;
            viewModel.RegNr = vehicle.RegNr;
            viewModel.Color = vehicle.Color;
            viewModel.Brand = vehicle.Brand;
            viewModel.Model = vehicle.Model;
            viewModel.Type = vehicle.VehicleTypeEntity.Category;
            viewModel.NrOfWheels = vehicle.NrOfWheels;
            viewModel.Name = vehicle.Member.FullName;
            viewModel.PerNr = vehicle.Member.PerNr;
            viewModel.Parked = vehicle.Park != null ? true : false;
            viewModel.ParkingSpace = vehicle.Park != null ? vehicle.Park.Spaces.FirstOrDefault().NumberSpot : null;

            return View(viewModel);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Vehicle == null)
            {
                return Problem("Entity set 'Garage2_0Context.Vehicle'  is null.");
            }
            var vehicle = await _context.Vehicle.FindAsync(id);
            var park = _context.Park.FirstOrDefault(m => m.VehicleId == vehicle.Id);
            if(park != null)
            {
                return Problem("Can't delete a vehicle that is parked in the garage.");
            }

            if (vehicle != null)
            {
                _context.Vehicle.Remove(vehicle);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Search(string term)
        {

            return Json(
                await _context.Member
                .Where(member => member.FirstName.Contains(term) || member.PerNr.Contains(term))
                //.Select(member => new { member.Id, Label = member.Name, member.PersonNr, member.Email })
                .ToListAsync());
        }
        public IActionResult Park()
        {
            return View();
        }

        public IActionResult CheckOut(int id)
        {
            var park = _context.Park.Include(n => n.Spaces).FirstOrDefault(m => m.Id == id);
            var parkedVehicle = _context.Vehicle.Include(o => o.Member).FirstOrDefault(m => m.Id == park.VehicleId);
            
            var viewModel = new CheckOutViewModel();
            viewModel.Id =  park.Id;
            viewModel.RegNr = parkedVehicle.RegNr;
            viewModel.Color = parkedVehicle.Color;
            viewModel.Brand = parkedVehicle.Brand;
            viewModel.Model = parkedVehicle.Model;
            viewModel.Type = _context.VehicleType.FirstOrDefault(m => m.Id == parkedVehicle.VehicleTypeEntityId).Category;
            viewModel.NrOfWheels = parkedVehicle.NrOfWheels;
            viewModel.ArrivalTime = park.ArrivalTime;
            viewModel.LeaveTime = DateTime.Now;
            viewModel.TimeParked = Math.Round((viewModel.LeaveTime - viewModel.ArrivalTime).TotalHours, 2);
            viewModel.Price = Math.Round(viewModel.TimeParked * 10, 1);
            viewModel.FullName = parkedVehicle.Member.FullName;
            viewModel.PerNr = parkedVehicle.Member.PerNr;
            viewModel.ParkSpace = park.Spaces.FirstOrDefault().NumberSpot;
            return View(viewModel);
        }

        public IActionResult UnPark()
        {
            return View();
        }

        [HttpPost]
        [AcceptVerbs("GET", "POST")]
        public IActionResult GetVehicle(string RegNr)
        {
            var regNr = _context.Vehicle.FirstOrDefault(m => m.RegNr == RegNr);
            if (regNr == null)
            {
                return NotFound();
            }

            else
            {
                return RedirectToAction(nameof(Details), new { id = regNr.Id }); //Vehicles/delete?id=123
            }
        }

        [HttpPost]
        [AcceptVerbs("GET", "POST")]
        public IActionResult ParkVehicle(string RegNr)
        {
            var regNr = _context.Vehicle.FirstOrDefault(m => m.RegNr == RegNr);
            if (regNr == null)
            {
                return NotFound();
            }

            else
            {
                var prkSpace = _context.ParkingSpace?.FirstOrDefault(m => m.Park == null);

                if (prkSpace == null || regNr.Park != null)
                {
                    return RedirectToAction(nameof(ParkingSpaceIndex));
                }

                var park = new Park();
                park.ArrivalTime = DateTime.Now;
                park.VehicleId = regNr.Id;
                park.Vehicle = regNr;
                park.Spaces.Add(prkSpace);


                regNr.Park = park;

                _context.Add(park);
                //regNr.Park = park;
                _context.SaveChanges();

                return RedirectToAction(nameof(ParkingSpaceIndex));
            }
        }

        [HttpPost]
        [AcceptVerbs("GET", "POST")]
        public IActionResult CheckOutVehicle(string RegNr)
        {
            var regNr = _context.Vehicle.Include(n => n.Park).FirstOrDefault(m => m.RegNr == RegNr);
            if (regNr == null)
            {
                return NotFound();
            }
            else
            {
                return RedirectToAction(nameof(CheckOut), new { id = regNr.Park.Id });
            }
        }

        private bool VehicleExists(int id)
        {
          return (_context.Vehicle?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        //Remote validation to check if regNr exists
        [AcceptVerbs("GET", "POST")]
        public IActionResult NoVehicle(string RegNr)
        {
            var selectedV = _context.Vehicle!.Include(v => v.Park).FirstOrDefault(m => m.RegNr.Equals(RegNr));
            if(_context.ParkingSpace.FirstOrDefault(m => m.Park == null) == null)
            {
                return Json("The garage is full.");
            }

            if (selectedV == null)
            {
                return Json($"There is no Vehicle with RegNr {RegNr}.");
                //return Json(false);
            }
            else if (selectedV.Park != null)
            {
                return Json("This vehicle is already parked in the garage.");
            }

            else
            {
                return Json(true);
            }
        }

        //Remote validation to check if regNr exists
        [AcceptVerbs("GET", "POST")]
        public IActionResult UnparkSearch(string RegNr)
        {
            var selectedV = _context.Vehicle!.Include(v => v.Park).FirstOrDefault(m => m.RegNr.Equals(RegNr));
            if (selectedV == null)
            {
                return Json($"There is no Vehicle with RegNr {RegNr}.");
                //return Json(false);
            }
            else if (selectedV.Park == null)
            {
                return Json("This vehicle is not parked in the garage.");
            }

            else
            {
                return Json(true);
            }
        }

        public async Task<IActionResult> ParkingSpaceIndex()
        {
            var model = _context.ParkingSpace!.Select(v => new ParkingSpacesViewModel
            {
                Id = v.Park != null ? v.Park.Id : 0,
                NumberSpot = v.NumberSpot,
                Occupied = v.Park != null ? true : false,

                ArrivalTime = v.Park != null ? v.Park.ArrivalTime : DateTime.MinValue,
                RegNr = v.Park != null ? v.Park.Vehicle.RegNr : "---",
                Type = v.Park != null ? v.Park.Vehicle.VehicleTypeEntity.Category : "---",
                FullName = v.Park != null ? v.Park.Vehicle.Member.FullName : "---",
                VehicleId = v.Park != null ? v.Park.Vehicle.Id : 0

            });

            return View(await model.ToListAsync());

        }

        [HttpPost, ActionName("Receipt")]
        public IActionResult Receipt(int id)
        {
            if (_context.Park == null)
            {
                return Problem("Entity set 'Garage2_0Context.Park'  is null.");
            }
            var parkedVehicle = _context.Park.Include(n => n.Spaces).FirstOrDefault(m => m.Id == id);
            var vehicle = _context.Vehicle.Include(n => n.Member).Include(o => o.VehicleTypeEntity).FirstOrDefault(m => m.Id == parkedVehicle.VehicleId);

            var viewModel = new ParkReceiptViewModel();
            viewModel.Type = vehicle.VehicleTypeEntity.Category;
            viewModel.RegNr = vehicle.RegNr;
            viewModel.ArrivalTime = parkedVehicle.ArrivalTime;
            viewModel.LeaveTime = DateTime.Now;
            viewModel.TimeParked = Math.Round((viewModel.LeaveTime - viewModel.ArrivalTime).TotalHours, 2);
            viewModel.Price = Math.Round(viewModel.TimeParked * 10, 1);
            viewModel.FullName = vehicle.Member.FullName;
            viewModel.PerNr = vehicle.Member.PerNr;

            if (parkedVehicle != null)
            {
                //vehicle.Park = null;

                _context.Park.Remove(parkedVehicle);
            }

            _context.SaveChangesAsync();

            return View(viewModel);
        }

        
        [HttpPost, ActionName("ParkDelete")]
        public IActionResult ParkDelete(int id)
        {
            if (_context.Park == null)
            {
                return Problem("Entity set 'Garage2_0Context.Park'  is null.");
            }
            var parkedVehicle = _context.Park.Include(n => n.Spaces).FirstOrDefault(m => m.Id == id);
            //var vehicle = _context.Vehicle.FirstOrDefault(m => m.Id == parkedVehicle.VehicleId);
            
            if (parkedVehicle != null)
            {
                //vehicle.Park = null;

                _context.Park.Remove(parkedVehicle);
            }

            _context.SaveChanges();

            return RedirectToAction(nameof(ParkingSpaceIndex));
        }
    }
}
