using BookStoreApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;    
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using RoomRentalBackEnd.DataBaseConnection;
using RoomRentalBackEnd.IRepository.IAccountRepository;
using RoomRentalBackEnd.IRepository.IAdminRepository;
using RoomRentalBackEnd.IRepository.IOwnerRepository;
using RoomRentalBackEnd.Middileware.CheckRollAuth;
using RoomRentalBackEnd.Repository.AccountRepository;
using RoomRentalBackEnd.Repository.AdminRepository;
using RoomRentalBackEnd.Repository.OwnerRepository;
using System.Text;

namespace RoomRentalBackEnd
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
            services.AddSwaggerGen();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {

                    Version = "3.0.0",
                    Title = "Room Rental Api",
                    Description = "Room Rental api",

                });
            });

            //here i am adding my custume middleware 
            //services.AddTransient<CheckRoleMiddileware>();

            services.AddTransient<IAccountRepository, AccountRepository>();
            services.AddTransient<IOwnerRepository, OwnerRepository>();
            services.AddTransient<IAdminRepository,AdminRepository>();
         
            /* services.AddDbContext<DbContextClass>();*/
            /*    second way to make it connection bitween database and project*/
            /*    services.AddDbContext<DbContextClass>(options => options.UseSqlServer("Server=.;Database=BookStoreApi;Integrated Security = True"));*/
            services.AddDbContext<DbContextConnect>(option =>
            {
                option.UseSqlServer(Configuration.GetConnectionString("RoomRentalDb"));
            });
           
            services.AddControllers();
                //json data formate service
            services.AddControllers()
        .AddNewtonsoftJson(jsonOptions =>
        {
            jsonOptions.SerializerSettings.Converters.Add(new StringEnumConverter());
        });
            /*here i am adding cores policy for all routes and method*/
            services.AddCors(option =>
            {
                option.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });
            /*this code for login autherization...................................................*/
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(option =>
            {
                option.SaveToken = true;
                option.RequireHttpsMetadata = false;
                option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["JWT:ValidAudience"],
                    ValidIssuer = Configuration["JWT:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
                };
            }).AddCookie();
            /* i am using here Identity model for using idendtity package*/
            //services.AddIdentity<IdentityUser, IdentityRole>()
            //    .AddEntityFrameworkStores<DbContextConnect>().AddDefaultTokenProviders();
            services.AddIdentity<ExtraUserModel, IdentityRole>().AddRoles<IdentityRole>().AddEntityFrameworkStores<DbContextConnect>().AddDefaultTokenProviders();
            //add swagger code here and register service here


        

            //this code form model validation error send to frontEnd with ok method and msg
            services.AddMvc()
        .ConfigureApiBehaviorOptions(options =>
        {
            //options.SuppressModelStateInvalidFilter = true;
            options.InvalidModelStateResponseFactory = actionContext =>
            {
                var modelState = actionContext.ModelState.Values;
                return new OkObjectResult(new { modelState, msg = "model wrong" });
            };
        }).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(x => x
           .AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseRouting();

           app.UseAuthorization();
            app.UseAuthentication();
            //app.UseMiddleware<CheckRoleMiddileware>();

            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("this is second middleware");

            //});
            app.UseStaticFiles();
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rating Api");
            });
            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

            });
        }
    }
}
