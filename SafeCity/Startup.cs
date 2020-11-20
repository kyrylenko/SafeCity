using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SafeCity.Core;
using SafeCity.Core.Repositories;
using SafeCity.Services;

namespace SafeCity
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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(jwt => jwt.UseGoogle(
                    clientId: Configuration["Authentication:Google:ClientId"]));

            services.AddControllers().AddNewtonsoftJson();

            services.AddHttpContextAccessor();

            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IDonationRepository, DonationRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<ILiqPayService>(x =>
                new LiqPayService(Configuration["LiqPay:PublicKey"], Configuration["LiqPay:PrivateKey"]));

            services.AddAutoMapper(typeof(Startup).Assembly);

            services.AddMvc(p =>
            {
                p.EnableEndpointRouting = false;
            });

            services.AddDbContext<SafeCityContext>(
                opt => opt.UseNpgsql(Configuration["ConnectionStrings:SafeCityConnectionString"]));

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseMvc();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            //app.UseRouting();

            app.UseAuthentication();

            app.UseMvcWithDefaultRoute();

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
