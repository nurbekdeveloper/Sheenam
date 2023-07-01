//=======================
//Coperight(c)  Coalition  of Good  -  Hearted  Enginners 
// Free To Use Comfort and Peace 
//======================




using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Sheenam.Api.Brokers.Storages;

namespace Sheenam.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration) =>
        
            Configuration = configuration;
        

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var infoApi = new OpenApiInfo
            {
                Title = "Sheenam.Api",
                Version = "v1"
            };

            services.AddControllers();
            services.AddDbContext<StorageBroker>();
            services.AddTransient<IStorageBroker , StorageBroker>();
            services.AddSwaggerGen(options =>

                options.SwaggerDoc(
                    name: "v1",
                    info: infoApi)
                ); 
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment envorement)
        {
            if (envorement.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                options.SwaggerEndpoint(
                    url :"/swagger/v1/swagger.json", 
                    name:"Sheenam.Api v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
   
                endpoints.MapControllers()
            );
        }
    }
}
