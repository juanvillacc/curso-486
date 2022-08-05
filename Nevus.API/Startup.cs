using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Nevus.Data;
using Nevus.Data.Repositories;
using Nevus.Services;
using System;

namespace Nevus.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var cc = Configuration.GetConnectionString("Server");

            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(cc));

            services.AddTransient<ICiudadRepository, CiudadRepository>();
            services.AddTransient<ICiudadService, CiudadService>();
            services.AddTransient<IDepartamentoService, DepartamentoService>();

            services.AddControllers();
            services.AddSignalR(hubOptions =>
            {
                hubOptions.HandshakeTimeout = TimeSpan.FromSeconds(30);
                hubOptions.KeepAliveInterval = TimeSpan.FromSeconds(50);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            

        }
    }
}
