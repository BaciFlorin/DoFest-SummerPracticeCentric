using DoFest.Persistence;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DoFest.API
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
            services.AddCors();

            //inregistrarea repository-urilor
            services.AddDbContext<DoFestContext>(config =>
                config.UseSqlServer(Configuration.GetConnectionString("TripsConnection")));
            
            
            services
                .AddMvc()
                .AddFluentValidation();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app
            //    .UseSwagger()
            //    .UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Trips API"));

            app
                .UseHttpsRedirection()
                .UseRouting()
                .UseCors(options => options.AllowAnyOrigin().AllowAnyMethod())
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
