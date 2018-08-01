using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using HotelsCombined.Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.AspNetCore.Routing;
using Microsoft.Azure.KeyVault.Models;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace HotelsCombined
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IPlaceRepository, DummyPlaceRepository>();
            services.AddMvc();
            services.AddMvcCore()
                .AddJsonFormatters(options =>
                {
                    options.Formatting = Formatting.Indented;
                    options.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
                    options.PreserveReferencesHandling = PreserveReferencesHandling.Objects;

                }).AddApiExplorer();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowPolicy",
                    policy => policy.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                );
            });
            services.AddMvc();
            
            services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
                
            }

            app.UseAuthentication();
            app.UseMvc();
            app.UseStaticFiles();

            app.UseStaticFiles();
            app.UseMvc(routes =>
			{
				routes.MapRoute(
					name: "default",
					template: "{controller=home}/{action=index}/{id?}");
			});
        }
    }
}
