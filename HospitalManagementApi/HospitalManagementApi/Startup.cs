using HospitalManagementApi.DAL.IRepositories;
using HospitalManagementApi.DAL.Repositories;
using HospitalManagementApi.Helper;
using HospitalManagementApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementApi
{
    public class Startup
    {
        private readonly string _loginOrigin = "_localorigin";
        public IConfiguration _iConfiguration;
        public Startup(IConfiguration iConfiguration)
        {
            _iConfiguration = iConfiguration;

        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<JWTConfig>(_iConfiguration.GetSection("JWTConfig"));
            services.AddDbContext<HospitalManagementContext>(options => options.UseSqlServer(_iConfiguration.GetConnectionString("HospitalManagementDB")));
            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<HospitalManagementContext>();
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                var key = Encoding.ASCII.GetBytes(_iConfiguration["JWTConfig:Key"]);
                var issuer = _iConfiguration["JWTConfig:Issuer"];
                var audience = _iConfiguration["JWTConfig:Audience"];
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    RequireExpirationTime = true,
                    ValidIssuer = issuer,
                    ValidAudience = audience
                };
            });
            services.AddCors(opt =>
            {
                opt.AddPolicy(_loginOrigin, builder =>
                {
                    builder.AllowAnyOrigin();
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();


                });
            });
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HospitalManagementApi", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please insert token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement{
                     {
                         new OpenApiSecurityScheme{
                             Reference=new OpenApiReference  {
                                    Type=ReferenceType.SecurityScheme,
                                    Id="Bearer"
                             }
                         },
                         new string[]{}

                     }

              });
            });

            services.AddScoped<IDoctorsInfoRepository, DoctorsInfoRepository>();
            services.AddScoped<ITestInfoRepository, TestInfoRepository>();
            services.AddScoped<ITestCategoryRepository, TestCategoryRepository>();
            services.AddScoped<IPatientAdmissionInfoRepository, PatientAdmissionInfoRepository>();
            services.AddScoped<IPatientInfoRepository, PatientInfoRepository>();
            services.AddScoped<IAppointmentInfoRepository, AppointmentInfoRepository>();
            services.AddScoped<IOutDoorConsultancyRepository, OutDoorConsultancyRepository>();
            services.AddScoped<ICabinInfoRepository, CabinInfoRepository>();
            services.AddScoped<IWardInfoRepsoitory, WardInfoRepository>();
            services.AddScoped<ICabinTypeRepository, CabinTypeInfoRepository>();
            services.AddScoped<IBedInfoRepsoitory, BedInfoRepository>();
            services.AddScoped<IPatientTestingInfoRepository, PatientTestingInfoRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProduct_In_The_OrderRepository, Product_In_The_OrderRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IDesignationRepository, DesignationRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IEducationRepository, EducationRepository>();
            services.AddScoped<IExperienceRepository, ExperienceRepository>();
            services.AddScoped<IPatientMedicineInfoRepository, PatientMedicineInfoRepository>();

            services.AddMvc()
            .ConfigureApiBehaviorOptions(options => {
                options.SuppressModelStateInvalidFilter = true;
            }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HospitalManagementApi v1"));
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "HospitalManagementApi v1");
            });
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseCors(_loginOrigin);
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
