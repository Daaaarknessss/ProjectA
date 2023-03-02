using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BusStop.Data;
using Microsoft.AspNetCore.Identity;
using BusStop.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BusStopContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BusStopContext") ?? throw new InvalidOperationException("Connection string 'BusStopContext' not found.")));
builder.Services.AddDbContext<DataBusStopContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DataBusStopContextConnection") ?? throw new InvalidOperationException("Connection string 'BusStopContext' not found.")));

builder.Services.AddDefaultIdentity<BusStopUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<DataBusStopContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
