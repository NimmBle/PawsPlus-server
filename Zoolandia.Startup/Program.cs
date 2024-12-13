using Zoolandia.Application;
using Zoolandia.Domain;
using Zoolandia.Infrastructure;
using Zoolandia.Infrastructure.Common.Persistence;
using Zoolandia.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddDomain()
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddWebComponents()
    .AddEndpointsApiExplorer()
    .AddControllers();

builder.Logging.AddConsole();
builder.Logging.AddDebug();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    DataSeed.SeedData(services).Wait();
}
app.UseHttpsRedirection();
app.UseCors(opt => opt
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
);
app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI(opt => opt
    .SwaggerEndpoint("/swagger/v1/swagger.json", "v1"));
app.UseAuthorization();
app.MapControllers();
app.Run();