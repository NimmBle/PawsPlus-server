using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using PawsPlus.Application;
using PawsPlus.Domain;
using PawsPlus.Infrastructure;
using PawsPlus.Server;
using PawsPlus.Web;
using PawsPlus.Web.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDomain()
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddWebComponents()
    .AddEndpointsApiExplorer();

FirebaseInitializer.EnsureInitialized();

var app = builder.Build();

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
    .UseSwaggerUI(opt =>
        {
            opt.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            opt.RoutePrefix = string.Empty;
        }
    )
    .UseAuthorization()
    .UseAuthorization()
    .UseEndpoints(endpoints => endpoints
        .MapControllers()
    )
    .Initialize();
    
app.Run();

public partial class Program { }