using FutureValue.Application.Commands;
using FutureValue.Application.Interfaces;
using FutureValue.Application.Queries;
using FutureValue.Domain;
using FutureValue.Persistence;
using FutureValue.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using FutureValue.API.Model;

namespace FutureValue.API
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
            //inject appsettings
            services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));

            services.AddControllers()
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            //dbcontext
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<AuthenticationContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //scopes
            services.AddScoped<IFutureValueRepository, FutureValueRepository>();
            services.AddScoped<IFutureValueQueries, FutureValuesQueries>();
            services.AddScoped<IFutureValueCommands, FutureValueCommands>();
            services.AddScoped<IExecutionDetailsRepository, ExecutionDetailsRepository>();
            services.AddScoped<IExecutionDetailsQueries, ExecutionDetailsQueries>();
            services.AddScoped<IExecutionDetailsCommands, ExecutionDetailsCommands>();

            services.AddDefaultIdentity<ApplicationUser>()
                .AddEntityFrameworkStores<AuthenticationContext>();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 8;
                options.Password.RequireUppercase = false;
            });

            //JWT Authentication
            var key = Encoding.UTF8.GetBytes(Configuration["ApplicationSettings:JWT_Secret"].ToString());
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x => {
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key), //assigning secret key
                    ValidateIssuer = false,
                    ValidateAudience = false, // can set targeted audience for the token,
                    ClockSkew = TimeSpan.Zero //checking for expiration, since no time zone difference bet client & server I have set this to zero
                };
            });

            services.AddCors();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FutureValue.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options => options.WithOrigins(Configuration["ApplicationSettings:Client_URL"].ToString())
            .AllowAnyMethod()
            .AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FutureValue.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
