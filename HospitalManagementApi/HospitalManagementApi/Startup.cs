using HospitalManagementApi.DAL.IRepository;
using HospitalManagementApi.DAL.Repositories;
using HospitalManagementApi.ViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
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

namespace HospitalManagementApi
{
    public class Startup
    {
        private readonly string _localOrigin = "_localOrigin";
        private readonly IConfiguration iConfiguration;
        public Startup(IConfiguration _iConfiguration)
        {
            iConfiguration = _iConfiguration;

        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<HospitalManagementSystemContext>(options => options.UseSqlServer(iConfiguration.GetConnectionString("HospitalDB")));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HospitalManagementApi", Version = "v1" });
            });


            services.AddScoped<IDoctorsInfoRepository, DoctorsInfoRepository>();
<<<<<<< HEAD

            services.AddScoped<IWordInfoRepsoitory, WordInfoRepository>();

            //services.AddScoped<ICabinInfoRepository, CabinInfoRepository>();

            services.AddCors();
=======
            services.AddScoped<IWardInfoRepsoitory, WardInfoRepository>();
            services.AddScoped<ICabinInfoRepository, CabinInfoRepository>();
            services.AddScoped<IBedInfoRepository, BedInfoRepository>();
            services.AddScoped<IAppointmentInfoRepository, AppointmentInfoRepository>();
            services.AddScoped<ITestInfoRepository, TestInfoRepository>();
            services.AddScoped<IOutDoorConsultancyRepository, OutDoorConsultancyRepository>();
            services.AddScoped<ILabandTestEntry, LabandTestEntryInfoRepository>();


            services.AddCors(opt =>
            {
                opt.AddPolicy(_localOrigin, builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                });
            });
>>>>>>> d553aee8a1ed7a4df11e28f99813e6f6e67aeb79
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
           
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HospitalManagementApi v1"));
            }

            app.UseHttpsRedirection();
            app.UseCors(_localOrigin);
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
