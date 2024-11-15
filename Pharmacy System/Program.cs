using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pharmacy_System.Data;
using Pharmacy_System.Models;
//using Pharmacy_System.Services;
using Pharmacy_System.Data;
using System.Globalization;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<RegisterDb>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RegisterDb") ?? throw new InvalidOperationException("Connection string 'Patient_RegistrationContext' not found.")));


// Bind LdapSettings
//builder.Services.Configure<LdapSettings>(builder.Configuration.GetSection("LdapSettings"));
// Add LDAP authentication service
//builder.Services.AddScoped<LdapAuthenticationService>();

var cultureInfo = new CultureInfo("en-GB");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".AdventureWorks.Session";
    options.IdleTimeout = TimeSpan.FromMinutes(20);
    options.Cookie.IsEssential = true;
});

builder.Services.AddRazorPages();
builder.Services.AddHttpContextAccessor();


var app = builder.Build();
app.UseSession();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.MapRazorPages();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Users}/{action=Signin}/{id?}");

app.Run();
