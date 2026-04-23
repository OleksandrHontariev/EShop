using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using EShop.DataLayer.EfCode;
using Microsoft.EntityFrameworkCore;

IConfigurationRoot config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

var services = new ServiceCollection();
services.AddDbContext<EfDbContext>(options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

Console.ReadLine();