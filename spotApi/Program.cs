using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using spotApi.Models;
using spotApi.Repo;
using spotApi.Repo.Implements;
using spotApi.Repo.Interface;
using System;

var builder = WebApplication.CreateBuilder(args);

// Menambahkan konfigurasi
builder.Services.AddControllers();
// Mengonfigurasi layanan
builder.Services.AddScoped<IDapperContext, DapperContext>();
builder.Services.AddScoped<IBaseRepository<Product>, ProductReposiory>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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


//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
