using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using WalletApp.API.Exceptions;
using WalletApp.Domain.Common;
using WalletApp.Infrastructure.Common;
using WalletApp.Persistence.Context;

namespace WalletApp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WalletApp.Api", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });
            builder.Services.AddDbContext<WalletAppDbContext>(
                options => options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(WalletAppDbContext).Assembly.FullName)));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddTransient<ExceptionHandlerMiddleware>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseMiddleware<ExceptionHandlerMiddleware>();
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WalletApp.Api v1"));
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}