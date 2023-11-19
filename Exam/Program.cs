using Exam.Data;
using Exam.Data.Cart;
using Exam.Data.Services;
using Exam.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<AppDbContext>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));
//Services configuration
builder.Services.AddSession();

builder.Services.AddScoped<IGuestsService, GuestsService>();
builder.Services.AddScoped<IOrganizersService, OrganizersService>();
builder.Services.AddScoped<ILocationsService, LocationsService>();
builder.Services.AddScoped<IEventsService, EventsService>();
builder.Services.AddScoped<IOrdersService, OrdersService>();

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sc => ShoppingCart.GetShoppingCart(sc));

//Authentication and authorization
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false).
    AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddMemoryCache();
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options=>{ options.LoginPath = "/login"; });

builder.Services.AddControllersWithViews();
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<AppDbContext>();
        context.Database.Migrate(); // Ensure the database is created and migrated
        AppDbInitializer.Seed(app); // Seed the database
        AppDbInitializer.SeedUsersAndRolesAsync(app);
        Console.WriteLine($"seed is done");

    }
    catch (Exception ex)
    {
        // Handle any errors while seeding the database
        Console.WriteLine($"An error occurred while seeding the database: {ex.Message}");
    }
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
