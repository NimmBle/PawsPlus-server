using PawsPlus.Application;
using PawsPlus.Infrastructure;
using PawsPlus.Web;
using PawsPlus.Web.Middleware;
using PawsPlus.Domain;
using PawsPlus.Infrastructure;

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