using Common.WebApi.Configuration;
using Common.WebApi.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

namespace Common.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            _appConfiguration = configuration;
        }

        public IConfiguration _appConfiguration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.Configure<AppSettings>(_appConfiguration.GetSection("AppSettings"));

            var serviceConfiguration = _appConfiguration
                .GetSection(nameof(AppSettings))
                .Get<AppSettings>();

            services.AddDbContextPool<DatabaseContext>(options =>
            {
                options.UseSqlite(serviceConfiguration.Database.ConnectionString)
                    .EnableDetailedErrors()
                    .EnableSensitiveDataLogging();
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
