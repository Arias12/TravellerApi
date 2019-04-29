using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TravellerApi
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //var mappingConfig = new MapperConfiguration(mc =>
            //{
            //    mc.AddProfile(new MapperClass());
            //});

            //IMapper mapper = mappingConfig.CreateMapper();
            //services.AddSingleton(mapper);

            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<MapperClass>();
                cfg.ValidateInlineMaps = false;
            });


            services.AddAutoMapper();


            #region ServiceExtensionClass

            services.ConfigureCors();
            services.ConfigureMySqlContext(Configuration);
            services.ConfigureIISIntegration();
            services.ConfigureRepositoryWrapper();

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();

            app.UseHttpsRedirection();
            app.UseCors("CorsPolicy");
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}