using Microsoft.EntityFrameworkCore;
using XMLWebApiCore.Models.DBClasses;
using XMLWebApiCore.BL;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<FileServiceContext>(o=>o.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));


builder.Services.AddScoped<IFileService,FileService>();
builder.Services.AddScoped<IJsonService,JsonService>();
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
