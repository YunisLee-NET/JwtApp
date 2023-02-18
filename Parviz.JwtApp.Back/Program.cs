using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Parviz.JwtApp.Back.Core.Application.Interfaces;
using Parviz.JwtApp.Back.Core.Application.Mappings;
using Parviz.JwtApp.Back.Infrastucture.Tools;
using Parviz.JwtApp.Back.Persistance.Context;
using Parviz.JwtApp.Back.Persistance.Repositories;
using System.Reflection;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//Add JWT
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata = false;
    opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidIssuer = JwtTokenDefaults.ValidIssuer,
        ValidAudience = JwtTokenDefaults.ValidAudience,

        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF32.GetBytes(JwtTokenDefaults.SigningKey)),
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true, // Token zamanini yoxlayir ki, vaxti kecib ya nece
        ClockSkew = TimeSpan.Zero, //server ile klient arasinda gecikmeni sifira endirir
    };
});


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
        new ProductProfile(),
        new CategoryProfile()
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



app.UseAuthentication();  //Sisteme girisine icaze verir.
app.UseAuthorization();  //Role gore girise icaze verir.

app.MapControllers();

app.Run();
