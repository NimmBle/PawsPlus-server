using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Zoolandia.Server.Data;
using Zoolandia.Server.Infrastructure.Extentions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddDatabase(builder.Configuration)
    .AddIdentity()
    .AddEndpointsApiExplorer()
    .AddSwagger()
    .AddControllers();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI(opt => opt
    .SwaggerEndpoint("/swagger/v1/swagger.json", "v1"));
app.UseAuthorization();
app.MapControllers();
app.Run();