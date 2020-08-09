using System.Text;
using AutoMapper;
using DoFest.API.Extensions;
using DoFest.Business.Activities;
using DoFest.Business.Activities.Models.Content.Comment;
using DoFest.Business.Activities.Models.Content.Photos;
using DoFest.Business.Activities.Models.Content.Ratings;
using DoFest.Business.Activities.Services.Implementations;
using DoFest.Business.Activities.Services.Interfaces;
using DoFest.Business.Activities.Validators.Content;
using DoFest.Business.Identity;
using DoFest.Business.Identity.Models;
using DoFest.Business.Identity.Models.Notifications;
using DoFest.Business.Identity.Services.Implementations;
using DoFest.Business.Identity.Services.Interfaces;
using DoFest.Business.Identity.Validators;
using DoFest.Persistence;
using DoFest.Persistence.Activities;
using DoFest.Persistence.Activities.ActivityTypes;
using DoFest.Persistence.Activities.Places;
using DoFest.Persistence.Authentication;
using DoFest.Persistence.Authentication.Type;
using FluentValidation;
using DoFest.Persistence.BucketLists;
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
            // ****** General settings ******
            AddAuthentication(services);
            services
                .AddMvc()
                .AddFluentValidation();
            services
                .AddCors()
                .AddHttpContextAccessor()
                .AddSwagger()
                .AddControllers()
                .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            // ****** Add services ******
            services
                .AddScoped<IAuthenticationService, AuthenticationService>()
                .AddScoped<INotificationService, NotificationService>()
                .AddScoped<IPasswordHasher, PasswordHasher>()
                .AddScoped<IActivitiesService, ActivitiesService>()
                .AddScoped<IBucketListService, BucketListsService>()
                .AddScoped<ICommentsService, CommentsService>()
                .AddScoped<IPhotosService, PhotosService>()
                .AddScoped<IRatingsService, RatingsService>()
                .AddScoped<ICityService, CityService>()
                .AddScoped<IActivityTypesService, ActivityTypesService>()
                .AddScoped<IAdminService, AdminService>();


            // ****** Add Repositories and DbContext ******
            services.AddDbContext<DoFestContext>(config =>
                config.UseSqlServer(Configuration.GetConnectionString("DoFestConnection")))
                .AddScoped<IUserRepository, UserRepository>()
                .AddScoped<IUserTypeRepository, UserTypeRepository>()
                .AddScoped<ICityRepository, CityRepository>()
                .AddScoped<IActivitiesRepository, ActivitiesRepository>()
                .AddScoped<IBucketListsRepository, BucketListsRepository>()
                .AddScoped<IActivityTypesRepository, ActivityTypesRepository>();

            // ****** Add Mapper profiles ******
            services
                .AddAutoMapper(config =>
                {
                    config.AddProfile<AuthenticationMappingProfile>();
                    config.AddProfile<NotificationMappingProfile>();
                    config.AddProfile<ActivitiesMappingProfile>();
                    config.AddProfile<CityMappingProfile>();
                });
                
            
            
            // ****** Add validators ******
            services.AddTransient<IValidator<RegisterModel>, UserRegisterModelValidator>()
                .AddTransient<IValidator<NewPasswordModelRequest>, NewPasswordModelValidator>()
                .AddTransient<IValidator<LoginModelRequest>, LoginModelValidator>()
                .AddTransient<IValidator<NewCommentModel>, NewCommentModelValidator>()
                .AddTransient<IValidator<CreateRatingModel>, CreateRatingModelValidator>()
                .AddTransient<IValidator<CreatePhotoModel>, CreatePhotoModelValidator>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DoFest V1");
            });

            app
                .UseHttpsRedirection()
                .UseRouting()
                .UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader())
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(endpoints => endpoints.MapControllers())
                .UseSwagger();
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
