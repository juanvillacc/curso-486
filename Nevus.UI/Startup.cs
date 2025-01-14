using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Nevus.Data;
using Nevus.Data.Repositories;
using Nevus.Services;
using Nevus.UI.Data;
using Nevus.UI.Hubs;
using System;
using System.IO;

namespace Nevus.UI
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
            services.AddTransient<IMemoryCache, MemoryCache>();
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(cc));
            services.AddDbContext<IdentityAppDbContext>(options => options.UseSqlServer(cc));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<IdentityAppDbContext>();
            services.AddControllersWithViews();
            services.AddTransient<ICiudadRepository, CiudadRepository>();
            services.AddTransient<ICiudadService, CiudadService>();
            services.AddTransient<IDepartamentoService, DepartamentoService>();

            services.AddSession(option =>
            {
                option.IdleTimeout = TimeSpan.FromSeconds(10);
            }
             );
            services.AddSignalR();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // creando midd personalizado
            app.Use(async (context, next) =>
            {
                // alguna logica
                await next();
            });

            if (env.IsDevelopment())
            {
                Console.WriteLine("Entro por desarrollo");
                app.UseDeveloperExceptionPage();
            }
            else if (env.IsStaging() || env.IsProduction())
            {
                Console.WriteLine("Entro por production");
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            // creacion de un proveedor de archivos estaticos
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "ArchivosStaticos")),

            }); ;
            
            app.UseSession();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Ciudad}/{action=Index}/{id?}");
                endpoints.MapHub<ChatHub>($"/{nameof(ChatHub)}");
            });
            

        }
    }
}
