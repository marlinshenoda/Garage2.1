using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Garage2._0.Data;
using Garage2._0.AutoMapper;
using Garage2._0.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Garage2_0Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Garage2_0Context") ?? throw new InvalidOperationException("Connection string 'Garage2_0Context' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(MapperProfile));

builder.Services.AddScoped<IVehicleTypeService, VehicleTypeService>();
builder.Services.AddScoped<IMemberSelectService, MemberSelectServices>();

builder.Services.AddDbContext<Garage2_0Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GarageContext")));




var app = builder.Build();

// Seeddata

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<Garage2_0Context>();

    //db.Database.EnsureDeleted();
    //db.Database.Migrate();

    try
    {
        await SeedData.InitVehicleTypeAsync(db);
    }
    catch (Exception e)
    {
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogError(string.Join(" ", e.Message));
        //throw;
    }
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ParkedVehicles}/{action=Home}/{id?}");

app.Run();
