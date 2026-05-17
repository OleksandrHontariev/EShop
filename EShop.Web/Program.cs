using EShop.DataLayer.EfCode;
using Microsoft.EntityFrameworkCore;
using EShop.Web.HelperExtensions;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<EfDbContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

app.UseStaticFiles();
await app.SetupDatabaseAsync();
app.MapDefaultControllerRoute();

app.Run();
