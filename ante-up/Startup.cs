using System;
using ante_up.Common.Interfaces.Data.Context;
using ante_up.Data;
using ante_up.Hubs;
using ante_up.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using Microsoft.OpenApi.Models;

namespace ante_up
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "AllowCORS";

        private readonly string _anteUp = Environment.GetEnvironmentVariable("conn_string_ante_up");
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            
            services.AddDbContext<IAnteUpContext, AnteUpContext>(options => 
                options.UseMySql(_anteUp, 
                    ServerVersion.AutoDetect(_anteUp)));
            
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo {Title = "ante_up", Version = "v1"}); });
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins("localhost:3000",
                                            "localhost:6000",
                                            "zealous-clarke-145490.netlify.app");
                    });
            }); 
            services.AddSignalR(e => {
                e.MaximumReceiveMessageSize = 102400000;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                IdentityModelEventSource.ShowPII = true; 
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ante_up v1"));
            }
            else
            {
                IdentityModelEventSource.ShowPII = true; 
                app.UseHsts();
            }
            
            using (IServiceScope scope = app.ApplicationServices.CreateScope())
            using (var context = scope.ServiceProvider.GetService<IAnteUpContext>())
            {
                context.Database.EnsureCreated();
            }
            
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true)
                .AllowCredentials());
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseStaticFiles();
            
            app.UseMiddleware<ExceptionHandler>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<AnteHub>("/antehub");
            });

            app.Run(async (context) => {
                await context.Response.WriteAsync("404 Error - Page not found");
            });
        }
    }
}