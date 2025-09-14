using BPMeasurementsERutledge7809.Data;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Pick connection string based on environment
var env = builder.Environment;

string connectionString;

if (env.IsDevelopment())
{
    // Local dev - just drop DB in project root
    connectionString = builder.Configuration.GetConnectionString("LocalConnection");
}
else
{
    // On Azure - use the special app_data folder
    connectionString = builder.Configuration.GetConnectionString("AzureConnection");
}

builder.Services.AddDbContext<BPContext>(options =>
    options.UseSqlite(connectionString));

var app = builder.Build();





// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<BPContext>();
    db.Database.Migrate(); // creates MyApp.db if missing
}

app.Run();