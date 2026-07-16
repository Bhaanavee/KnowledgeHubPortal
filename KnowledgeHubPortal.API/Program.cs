using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerUI;
using KnowledgeHubPortal.Business.Interfaces;
using KnowledgeHubPortal.Data;

namespace KnowledgeHubPortal.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            // Register repositories for dependency injection
            builder.Services.AddScoped<IArticleRepository, ArticlesRepository>();

            // Register Swagger
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Knowledge Hub Portal API",
                    Version = "v1",
                    Description = "REST API built using ASP.NET Core 10",
                    Contact = new OpenApiContact
                    {
                        Name = "Venkat Shiva Reddy",
                        Email = "venkatshiva.reddy@gmail.com"
                    }
                });
            });




            var app = builder.Build();

            // Enable Swagger
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();

                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Knowledge Hub Portal API V1");
                    options.DocumentTitle = "Knowledge Hub Portal API Documentation";
                });
            }


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}