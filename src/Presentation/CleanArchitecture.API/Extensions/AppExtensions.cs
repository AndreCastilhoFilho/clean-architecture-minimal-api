using CleanArchitecture.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.API.Extensions;

public static class AppExtensions
{
    public static WebApplication UseCongigurations(this WebApplication app)
    {
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "Users API V1");
            });
            app.UseCors();
        }

        app.UseHttpsRedirection();
        MigrateDatabase(app);

        return app;
    }

    /// <summary>
    /// Método que aplica migrações pendentes no banco de dados, garantindo que o banco de dados fique atualizado a cada execução
    /// </summary>
    /// <param name="app"></param>
    public static void MigrateDatabase(IApplicationBuilder app)
    {
        using (var scope = app.ApplicationServices.CreateScope())
        {
            var services = scope.ServiceProvider;

            try
            {
                var context = services.GetRequiredService<ApplicationDbContext>();
                context.Database.Migrate();
            }
            catch (Exception ex)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "Ocorreu um erro na migração/alimentação dos dados");
            }
        }
    }
}
