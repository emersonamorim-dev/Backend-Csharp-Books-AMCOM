using Backend_Books.Config;
using Backend_Books.Models;
using Backend_Books.Services;
using Backend_Books.Views.Repository;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adicionando configurações específicas do projeto
builder.Services.AddSingleton<BookService>();
builder.Services.AddSingleton<BookRepository>();

// Configuração do MongoDB
var mongoDbSettings = builder.Configuration.GetSection("MongoDbSettings").Get<MongoDbSettings>();
builder.Services.AddSingleton(mongoDbSettings);

builder.Services.AddSingleton<IMongoClient, MongoClient>(s =>
{
    return new MongoClient(mongoDbSettings.ConnectionString);
});

builder.Services.AddSingleton<BookRepository>();

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

