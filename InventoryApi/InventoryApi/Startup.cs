using System;
using System.Diagnostics;
using InventoryApi.Persistence;
using InventoryApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace InventoryApi
{
    public class Startup
    {
        private const string AllowedOrigins = "AllowedOrigins";
        private const string DbConnectionString = "DbConnectionString";


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var dbConnectionString = Configuration.GetSection(DbConnectionString).Value;
            services.AddScoped<IInventoryService, InventoryService>();
            services.AddControllers();
            services.AddDbContext<InventoryDbContext>(options =>
            {
                options.UseSqlite($"Data Source={dbConnectionString}");
            });
            services.AddCors(options =>
            {
                options.AddPolicy(name: AllowedOrigins,
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200", "http://pizza-api:80")
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ingredient_api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, InventoryDbContext dbContext)
        {
            EnsureDatabaseIsCreated(dbContext);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ingredient_api v1"));
            }

            app.UseRouting();
            app.UseAuthorization();
            app.UseCors(AllowedOrigins);
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private static void EnsureDatabaseIsCreated(InventoryDbContext context)
        {
            try
            {
                context.Database.EnsureCreated();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }
    }
}
