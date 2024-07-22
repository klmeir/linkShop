using Catalog.Api.ApiHandlers.Products;
using Catalog.Api.Filters;
using Catalog.Api.Middleware;
using Catalog.Infrastructure.DataSource;
using Catalog.Infrastructure.Extensions;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Reflection;

namespace Catalog.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {            
            Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();

            try
            {
                var builder = WebApplication.CreateBuilder(args);
                var config = builder.Configuration;

                builder.Host.UseSerilog((context, loggerConfiguration) =>
                {
                    loggerConfiguration.WriteTo.Console();
                    loggerConfiguration.ReadFrom.Configuration(context.Configuration);
                });

                builder.Services.AddValidatorsFromAssemblyContaining<Program>(ServiceLifetime.Singleton);

                builder.Services.AddDbContext<DataContext>(opts =>
                {
                    opts.UseSqlServer(config.GetConnectionString("db"));
                });

                // Add services to the container.                
                builder.Services.AddCors(options =>
                {
                    options.AddPolicy("CorsPolicy",
                        builder => builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader());
                });
                builder.Services.AddAuthorization();
                builder.Services.AddDomainServices();
                builder.Services.AddApplicationServices();

                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();

                builder.Services.AddMediatR(Assembly.Load("Catalog.Application"), typeof(Program).Assembly);                

                var app = builder.Build();

                ContextInitialize.Seed(app.Services);

                app.UseSerilogRequestLogging();

                // Configure the HTTP request pipeline.
                //if (app.Environment.IsDevelopment())
                //{
                    app.UseSwagger();
                    app.UseSwaggerUI();
                //}

                app.UseCors("CorsPolicy");                
                app.UseAuthorization();

                app.UseMiddleware<AppExceptionHandlerMiddleware>();
                
                app.MapGroup("/api/products").MapProducts().AddEndpointFilterFactory(ValidationFilter.ValidationFilterFactory);

                app.Run();

            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "server terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }
    }
}
