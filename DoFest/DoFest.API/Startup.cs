using AutoMapper;
using DoFest.Business;
using DoFest.Business.Services.Implementations;
using DoFest.Business.Services.Interfaces;
using DoFest.Persistence;
using DoFest.Persistence.Activities;
using DoFest.Persistence.Authentication;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

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
                config.UseSqlServer(Configuration.GetConnectionString("DoFestConnection")));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IActivitiesRepository, ActivitiesRepository>();

            services.AddAutoMapper(config =>
            {
                config.AddProfile<ActivitiesMappingProfile>();
                config.AddProfile<AuthenticationMappingProfile>();
            });
            
            // Adaugare servicii
            services.AddScoped<IPhotosService, PhotosService>();
            services.AddScoped<IRatingsService, RatingsService>();
            services.AddScoped<ICommentsService, CommentsService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services
                .AddMvc()
                .AddFluentValidation();
            services.AddControllers()
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

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
