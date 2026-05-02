using EShop.DataLayer.EfCode;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<EfDbContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

app.UseStaticFiles();
app.MapDefaultControllerRoute();

app.Run();
