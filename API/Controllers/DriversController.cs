using API.Data;
using API.DTOs;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[Authorize]
public class DriversController : BaseApiController
{
    private readonly DataContext _context;

    public DriversController(DataContext context)
    {
        _context = context;
    }

    [HttpGet("get-drivers")]
    public async Task<ActionResult<IEnumerable<Driver>>> GetDrivers()
    {
        return await _context.Drivers.ToListAsync();
    }

    [HttpGet("get-driver/{id}")]
    public async Task<ActionResult<Driver>> GetDriver(int id)
    {
        return await _context.Drivers.FindAsync(id);
    }

    [HttpPost("create-vehicle")]
    public async Task<ActionResult> CreateDriver(CreateDriverDto dto)
    {
        var driver = new Driver      
        {
           FirstName = dto.FirstName,
           LastName = dto.LastName,
           LicenseNumber = dto.LicenseNumber
        };

        _context.Drivers.Add(driver);

        if(await _context.SaveChangesAsync() > 0)
            return Ok(); 

        return BadRequest("Problem creating driver");
    }

    [HttpPut("update-driver/{id}")]
    public async Task<ActionResult> UpdateDriver(DriverDto dto)
    {
        var driver = await _context.Drivers.FindAsync(dto.Id);

        if (driver == null) 
            return NotFound();

        driver.FirstName = dto.FirstName;
        driver.LastName = dto.LastName;
        driver.LicenseNumber = dto.LicenseNumber;

        _context.Entry(driver).State = EntityState.Modified;

        if (await _context.SaveChangesAsync() > 0) 
            return Ok();

        return BadRequest("Failed to update driver");
    }

    [HttpDelete("delete-driver/{id}")]
    public async Task<IActionResult> DeleteDriver(int id)
    {
        var driver = await _context.Drivers.FindAsync(id);

        if (driver == null) 
            return NotFound();
        
        _context.Drivers.Remove(driver);

        if(await _context.SaveChangesAsync() > 0) 
            return Ok();

        return BadRequest("Failed to delete driver");
    }
}
