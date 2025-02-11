using CleanArchitecture.API.Extensions;
using CleanArchitecture.Infrastructure.Middlewares;

var builder = WebApplication.CreateBuilder(args);
builder
    .AddServices()
    .Services.ConfigureCorsPolicy();

var app = builder.Build();
app.RegisterEndpointsFromAssembly(typeof(Program).Assembly);
app.UseCongigurations();
app.UseMiddleware<GlobalErrorHandlerMiddleware>();


app.Run();


