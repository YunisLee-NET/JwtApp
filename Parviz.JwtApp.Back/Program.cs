using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Parviz.JwtApp.Back.Core.Application.Interfaces;
using Parviz.JwtApp.Back.Core.Application.Mappings;
using Parviz.JwtApp.Back.Persistance.Context;
using Parviz.JwtApp.Back.Persistance.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<JwtContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("LocalDb"));
});
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

//Burada Assembly ifadesi C#-da exe ve dll fayllarinin umumi adidir. Burada umumi olaraq bu fayllar icinden bizim hal hazirda oldugumuz faylin yerini alir GetExecutingAssembly();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddAutoMapper(opt =>
{
    opt.AddProfiles(new List<Profile>()
    {
        new ProductProfile()
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
