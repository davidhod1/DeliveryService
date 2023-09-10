using API.Data;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[Authorize]
public class VehiclesController : BaseApiController
{
    private readonly DataContext _context;

    public VehiclesController(DataContext context)
    {
        _context = context;
    }

    [HttpGet("get-vehicles")]
    public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehicles()
    {
        return await _context.Vehicles.ToListAsync();
    }

    [HttpGet("get-vehicle/{id}")]
    public async Task<ActionResult<Vehicle>> GetVehicle(int id)
    {
        return await _context.Vehicles.FindAsync(id);
    }

    [HttpGet("get-gpslocation/{id}")]
    public async Task<ActionResult<VehicleLocationDto>> GetGPSLocation(int id)
    {
        var vehicle = await _context.Vehicles.FindAsync(id);
        
        if (vehicle == null) 
            return NotFound();

        var vehicleLocationDto = new VehicleLocationDto
        {
            XCoordinate = vehicle.XCoordinate,
            YCoordinate = vehicle.YCoordinate
        };

        return Ok(vehicleLocationDto);
    }

  
    [HttpPost("add-vehicle")]
    public async Task<ActionResult> CreateVehicle(CreateVehicleDto createVehicle)
    {
        var vehicle = new Vehicle  
        {
            Model = createVehicle.Model,
            RegistrationNumber = createVehicle.RegistrationNumber,
            ProductionYear = createVehicle.ProductionYear,
            MaxLoadCapacity = createVehicle.MaxLoadCapacity,
            AdditionalInfo = createVehicle.AdditionalInfo,
            XCoordinate = createVehicle.XCoordinate,
            YCoordinate = createVehicle.YCoordinate
        };

        _context.Vehicles.Add(vehicle);

        if(await _context.SaveChangesAsync() > 0)
            return Ok();

        return BadRequest("Problem adding vehicle");
    }

    [HttpPut("update-vehicle/{id}")]
    public async Task<ActionResult> UpdateVehicle(UpdateVehicleDto updateVehicleDto)
    {
        var vehicle = await _context.Vehicles.FindAsync(updateVehicleDto.Id);

        if (vehicle == null) 
            return NotFound();

        vehicle.Model = updateVehicleDto.Model;
        vehicle.RegistrationNumber = updateVehicleDto.RegistrationNumber;
        vehicle.ProductionYear = updateVehicleDto.ProductionYear;
        vehicle.MaxLoadCapacity = updateVehicleDto.MaxLoadCapacity;
        vehicle.AdditionalInfo = updateVehicleDto.AdditionalInfo;

        _context.Entry(vehicle).State = EntityState.Modified;

        if (await _context.SaveChangesAsync() > 0) 
            return Ok();

        return BadRequest("Failed to update vehicle");
    }

    [HttpDelete("delete-vehicle/{id}")]
    public async Task<IActionResult> DeleteVehicle(int id)
    {
        var vehicle = await _context.Vehicles.FindAsync(id);

        if (vehicle == null) 
            return NotFound();
        
        _context.Vehicles.Remove(vehicle);

        if(await _context.SaveChangesAsync() > 0) 
            return Ok();

        return BadRequest("Failed to delete vehicle");
    }
}


