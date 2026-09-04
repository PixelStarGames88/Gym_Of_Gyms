using Gym_Of_Gyms.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>
    (options => options.UseNpgsql(builder.
    Configuration.GetConnectionString("DefaultConnection")!
    ));

builder.Services.AddDefaultIdentity<ApplicationUser>
    (options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddRazorPages();

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseExceptionHandler("/Home/Error");
app.UseStatusCodePagesWithReExecute("/Home/Error/{0}");

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=UserBody}/{id?}");

app.MapRazorPages();

app.Run();