using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PilotWorksAPI.Core.DataLayer;


namespace PilotWorksAPI_ForRedis
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            /* Added
            var builder = new ConfigurationBuilder();
            builder.SetBasePath()
            Configuration = builder.Build();
            */
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            //services.Configure<StackExchange.Redis.ConfigurationOptions>(Configuration.GetSection("redis"));

            //services.AddDistributedRedisCache(options =>
            //{
            //    options.InstanceName = Configuration.GetValue<string>("redis:name");
            //    options.Configuration = Configuration.GetValue<string>("redis:host");
            //});

            services.AddScoped<IPilotWorksRepository, PilotWorksRepository>();

            //services.AddScoped<IConnectionMultiplexer>(provider => ConnectionMultiplexer.Connect(Configuration.GetSection("ConnectionStrings"));
            //services.AddScoped<StackExchange.Redis.IConnectionMultiplexer>(provider => StackExchange.Redis.ConnectionMultiplexer.Connect(Configuration["ConnectionStrings"]));

            //services.AddScoped<IPilotWorksRepository, PilotWorksRepository>();

            services.AddOptions();

            services.Configure<AppSettings>(Configuration.GetSection("ConnectionStrings"));

            services.AddSingleton<IConfiguration>(Configuration);

            // added myself
            //services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /*
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
        */
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            //app.UseSession();

            app.UseMvc();
        }
    }
}
