using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Gproject.DataDB;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.ProjectModel;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Gproject.Interfaces;
using Gproject.Services;
//using static System.Collections.Immutable.ImmutableDictionary<TKey, TValue>;

namespace WebApplication10
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

            services.AddControllers();
          
            services.AddDbContext<DataProjectContext>(o => o.UseSqlServer("Server=(localdb)\\ProjectsV13;Database=DataProject;Trusted_Connection=True;"));
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApplication10", Version = "v1" });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First()); //This line

            });

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
             .AddJwtBearer(options =>
             {
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     ValidateIssuer = true,
                     ValidateAudience = true,
                     ValidateLifetime = true,
                     ValidateIssuerSigningKey = true,
                     ValidIssuer = Configuration["Jwt:Issuer"],
                     ValidAudience = Configuration["Jwt:Audience"],
                     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration
                     ["Jwt:Key"]))
                 };

             });

            //services.AddTransient<Gproject.Models.LaserModels>();
            services.AddScoped<Gproject.Interfaces.IContacts, Gproject.Services.ContactsService>();
            services.AddScoped<Gproject.Interfaces.IEmployees, Gproject.Services.EmployeesService>();
            //services.AddScoped<Gproject.Interfaces.IAppointments, Gproject.Services.AppointmentsService>();
            services.AddScoped<Gproject.Interfaces.IAccounts, Gproject.Services.AccountsService>();
            services.AddScoped<Gproject.Interfaces.IAttendance, Gproject.Services.AttendanceServic>();
            services.AddScoped<Gproject.Interfaces.IInquiries, Gproject.Services.IinquiriesService>();
            services.AddScoped<Gproject.Interfaces.ILasers, Gproject.Services.LasersService>();
            services.AddScoped<Gproject.Interfaces.IRoom, Gproject.Services.RoomsService>();
            services.AddScoped<Gproject.Interfaces.ISpecialEvents, Gproject.Services.SpecialEvensService>();
            services.AddScoped<Gproject.Interfaces.ITreats, Gproject.Services.TreatsService>();
            services.AddScoped<Gproject.Interfaces.IWorkHours, Gproject.Services.WorkHoursService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApplication10 v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseCors(x => x
                      .AllowAnyMethod()
                      .AllowAnyHeader()
                      .SetIsOriginAllowed(origin => true));

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
