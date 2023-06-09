using DemoCyberSecurite.Api.Bll.Repositories; 
using DemoCyberSecurite.Api.Bll.Services;
using DR = DemoCyberSecurite.Api.Dal.Repositories;
using DS = DemoCyberSecurite.Api.Dal.Services;
using System.Data;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDbConnection>(sp => new SqlConnection(configuration.GetConnectionString("default")));
builder.Services.AddScoped<DR.IAuthRepository, DS.AuthService>();
builder.Services.AddScoped<IAuthRepository, AuthService>();


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
