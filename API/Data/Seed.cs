using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class Seed
{
    public static async Task SeedDatabase(DataContext context)
    {
       if(await context.Users.AnyAsync()) return;

       var userData = await File.ReadAllTextAsync("Data/UserSeedData.json"); 

       var options = new JsonSerializerOptions{PropertyNameCaseInsensitive = true};

       var users = JsonSerializer.Deserialize<List<AppUser>>(userData, options);

       foreach (var user in users)
       {
            using var hmac = new HMACSHA512();

            user.UserName = user.UserName.ToLower();
            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("12345"));
            user.PasswordSalt = hmac.Key;

            context.Users.Add(user);
       }

       await context.SaveChangesAsync();

       await SeedDrivers(context);
       await SeedVehicles(context);
    }

    public static async Task SeedDrivers(DataContext context)
    {
        if(await context.Drivers.AnyAsync()) return;

        var driversData = await File.ReadAllTextAsync("Data/DriversSeedData.json");

        var options = new JsonSerializerOptions{PropertyNameCaseInsensitive = true};

        var drivers = JsonSerializer.Deserialize<List<Driver>>(driversData, options);

        foreach (var driver in drivers)
       {
            context.Drivers.Add(driver);
       }

       await context.SaveChangesAsync();
    }

    public static async Task SeedVehicles(DataContext context)
    {
        if(await context.Vehicles.AnyAsync()) return;

        var vehiclesData = await File.ReadAllTextAsync("Data/VehiclesSeedData.json");

        var options = new JsonSerializerOptions{PropertyNameCaseInsensitive = true};

        var vehicles = JsonSerializer.Deserialize<List<Vehicle>>(vehiclesData, options);

        foreach (var vehicle in vehicles)
       {
            context.Vehicles.Add(vehicle);
       }

       await context.SaveChangesAsync();
    }
}
