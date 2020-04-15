using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SPBUMonitoringServices.Contexts;
using SPBUMonitoringServices.Repository;
using SPBUMonitoringServices.Interfaces;

namespace SPBUMonitoringServices {

    public class Startup {

        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services) {
            services.AddCors(options => {
            options.AddPolicy(MyAllowSpecificOrigins,
                builder => {
                    builder.WithOrigins("http://localhost:4000", "http://10.10.131.226:5000", "*");
                });
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddMvc()
                .AddJsonOptions(
                    options => options.SerializerSettings.ReferenceLoopHandling =
                    Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );

            services.AddDbContext<DasboardsContext>(options => options.UseMySQL(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<EdcHeartBeatContext>(options => options.UseMySQL(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<EdcStatusContext>(options => options.UseMySQL(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IDashboardsRepository, DashboardsRepository>();
            services.AddScoped<IEdcHeartBeat, EdcHeartBeatRepository>();
            services.AddScoped<IEdcStatus, EdcStatusRepository>();

            services.AddDbContext<EdcConfigContext>(options => options.UseMySQL(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IEdcConfig, EdcConfigRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseHsts();
            }

            app.UseCors(MyAllowSpecificOrigins);
            app.UseHttpsRedirection();
            app.UseMvc();
        }

    }
}
