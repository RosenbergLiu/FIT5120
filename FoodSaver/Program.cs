using Microsoft.EntityFrameworkCore;
using FoodSaver.Data;
using Syncfusion.Licensing;


var builder = WebApplication.CreateBuilder(args);

SyncfusionLicenseProvider.RegisterLicense(builder.Configuration["Syncfusion"]);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<FoodSaverContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FoodSaverContext") ?? throw new InvalidOperationException("Connection string 'FoodSaverContext' not found.")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();