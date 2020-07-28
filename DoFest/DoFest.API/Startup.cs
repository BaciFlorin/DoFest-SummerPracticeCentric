using System.Text;
using AutoMapper;
using DoFest.API.Extensions;
using DoFest.Business.Identity;
using DoFest.Business.Identity.Models;
using DoFest.Business.Identity.Models.Notifications;
using DoFest.Business.Identity.Services.Implementations;
using DoFest.Business.Identity.Services.Interfaces;
using DoFest.Business.Identity.Validators;
using AutoMapper;
using DoFest.Business.Activities;
using DoFest.Business.Activities.Models.Content.Ratings;
using DoFest.Business.Activities.Services.Implementations;
using DoFest.Business.Activities.Services.Interfaces;
using DoFest.Business.Activities.Validators;
using DoFest.Business.Activities;
using DoFest.Business.Activities.Models.Content.Comment;
using DoFest.Business.Activities.Services.Implementations;
using DoFest.Business.Activities.Services.Interfaces;
using DoFest.Business.Activities.Validators.Content;
using DoFest.Persistence;
using DoFest.Persistence.Activities;
using DoFest.Persistence.Activities.Places;
using DoFest.Persistence.Authentication;
using DoFest.Persistence.Authentication.Type;
using FluentValidation;
using DoFest.Persistence.BucketLists;
using DoFest.Persistence.Notifications;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
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

            services
                .AddScoped<IAuthenticationService, AuthenticationService>()
                .AddScoped<INotificationService, NotificationService>()
                .AddScoped<IPasswordHasher, PasswordHasher>();

            AddAuthentication(services);

            services.AddDbContext<DoFestContext>(config =>
                config.UseSqlServer(Configuration.GetConnectionString("DoFestConnection")))
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IUserTypeRepository, UserTypeRepository>()
                .AddScoped<ICityRepository, CityRepository>()
                .AddScoped<IStudentRepository, StudentRepository>()
                .AddScoped<INotificationRepository, NotificationRepository>()
                .AddScoped<IActivitiesRepository, ActivitiesRepository>()
                .AddScoped<IBucketListRepository, BucketListRepository>();

            services
                .AddAutoMapper(config =>
                {
                    config.AddProfile<AuthenticationMappingProfile>();
                    config.AddProfile<NotificationMappingProfile>();
                })
                .AddHttpContextAccessor()
                .AddSwagger()
                .AddControllers()
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore); ;
            
            services
                .AddMvc()
                .AddFluentValidation();

            services.AddTransient<IValidator<RegisterModel>, UserRegisterModelValidator>()
                .AddTransient<IValidator<NewPasswordModelRequest>, NewPasswordModelValidator>()
                .AddTransient<IValidator<LoginModelRequest>, LoginModelValidator>()
                .AddTransient<IValidator<CreateNotificationModel>, CreateNotificationModelValidator>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DoFest V1");
            });

            app
                .UseHttpsRedirection()
                .UseRouting()
                .UseCors(options => options.AllowAnyOrigin().AllowAnyMethod())
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints => endpoints.MapControllers());
        }

        private void AddAuthentication(IServiceCollection services)
        {
            var jwtOptions = Configuration.GetSection("JwtOptions").Get<JwtOptions>();
            services.Configure<JwtOptions>(Configuration.GetSection("JwtOptions"));

            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = true;
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtOptions.Key)),
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidIssuer = jwtOptions.Issuer,
                        ValidAudience = jwtOptions.Audience
                    };
                });
        }
    }
}
