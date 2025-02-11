using CleanArchitecture.API.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder
    .AddServices()
    .Services.ConfigureCorsPolicy();

var app = builder.Build();
app.RegisterEndpointsFromAssembly(typeof(Program).Assembly); 
app.UseCongigurations();

app.Run();


