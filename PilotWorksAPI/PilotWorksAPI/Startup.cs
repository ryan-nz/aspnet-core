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
using Microsoft.EntityFrameworkCore;

namespace PilotWorksAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            //var builder = new ConfigurationBuilder();
            //builder.SetBasePath()
            //Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Added manually myself
            //services.AddDbContext<AdventureWorksDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc();

            services.AddEntityFrameworkSqlServer().AddDbContext<PilotWorksDbContext>();

            services.AddScoped<IEntityMapper, PilotWorksEntityMapper>();
            services.AddScoped<IPilotWorksRepository, PilotWorksRepository>();

            services.AddOptions();

            //services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.Configure<AppSettings>(Configuration.GetSection("ConnectionStrings"));

            services.AddSingleton<IConfiguration>(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();

            AddDataIntoDatabaseForDevStage(app);
        }

        private void AddDataIntoDatabaseForDevStage(IApplicationBuilder app)
        {
            // added from Code-First approach
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    //services.Configure<AppSettings>(optionsSetup =>
                    //{
                    //    //get from config.json file
                    //    optionsSetup.ConnectionString = Configuration.GetConnectionString("DefaultConnection");
                    //});

                    var context = GetAdventureWorksDbContext();
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }
        }

        private PilotWorksDbContext GetAdventureWorksDbContext()
        {
            string strDefaultConnection = Configuration.GetConnectionString("DefaultConnection");
            AppSettings appSettings = new AppSettings();
            appSettings.DefaultConnection = strDefaultConnection;

            var iappSettings = Options.Create(appSettings);

            return new PilotWorksDbContext(iappSettings, new PilotWorksEntityMapper());
        }
    }
}
