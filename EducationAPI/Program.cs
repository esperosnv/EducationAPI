using EducationAPI.Data.Context;
using EducationAPI.Data.DAL.Interfaces;
using EducationAPI.Data.Entities;
using EducationAPI.Data.DAL.Repositories;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using System.Text;
using EducationAPI.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//DataBase
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<EducationAPIContext>();

builder.Services.AddScoped<IBaseRepository<Author>, AuthorRepository>();
builder.Services.AddScoped<IBaseRepository<Material>, MaterialRepository>();
builder.Services.AddScoped<IBaseRepository<MaterialType>, MaterialTypeRepository>();
builder.Services.AddScoped<IBaseRepository<Review>, ReviewRepository>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddScoped<IMaterialTypeService, MaterialTypeService>();
builder.Services.AddEndpointsApiExplorer();






var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
