using Zoolandia.Application;
using Zoolandia.Domain;
using Zoolandia.Infrastructure;
using Zoolandia.Infrastructure.Common.Persistence;
using Zoolandia.Web;
using Zoolandia.Web.Middleware;

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
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseInnerExceptionHandler();
    app.UseHsts();
}

// using (var scope = app.Services.CreateScope())
// {
//     var services = scope.ServiceProvider;
//     DataSeed.SeedData(services).Wait();
// }

app
    .UseHttpsRedirection()
    .UseRouting()
    .UseCors(opt => opt
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader())
    .UseSwagger()
    .UseSwaggerUI(opt => opt
        .SwaggerEndpoint("/swagger/v1/swagger.json", "v1"))
    .UseAuthorization()
    .UseAuthorization()
    .UseEndpoints(endpoints => endpoints
        .MapControllers()
    );
    
app.Run();