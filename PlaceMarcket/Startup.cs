using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace PlaceMarcket
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

            services.AddDbContext<DAL.DB>(i => i.UseSqlServer(Configuration.GetConnectionString("Marcket")));

            services.AddIdentity<be.user, IdentityRole>(option =>
            {
                option.Password.RequireDigit = false;
                option.Password.RequireLowercase = false;
                option.Password.RequireUppercase = false;
                option.Password.RequiredLength = 1;
                option.Password.RequireNonAlphanumeric = false;
                option.SignIn.RequireConfirmedPhoneNumber = false;
                option.SignIn.RequireConfirmedEmail = false;
                option.SignIn.RequireConfirmedAccount = false;

            })
                .AddUserManager<UserManager<be.user>>()
                .AddRoles<IdentityRole>()
                .AddRoleManager<RoleManager<IdentityRole>>()
                .AddEntityFrameworkStores<DAL.DB>();

            services.ConfigureApplicationCookie(option =>
            {
                option.AccessDeniedPath = "/admin/AccessDenied";
                option.Cookie.Name = "login";
                option.Cookie.HttpOnly = true;
                option.ExpireTimeSpan = TimeSpan.FromDays(1);
                option.LoginPath = "/admin/login_singin";
                option.SlidingExpiration = false;
            });

            services.AddSession(option =>
            {
                option.IdleTimeout = TimeSpan.FromDays(7);
            });

            services.AddControllersWithViews().AddRazorRuntimeCompilation();



            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                //builder.WithOrigins("http://localhost")
                //.AllowAnyMethod()
                //       .WithHeaders(HeaderNames.AccessControlAllowHeaders, "Content-Type")
                //       .AllowAnyHeader();
                builder
                .WithHeaders("Access-Control-Allow-Origin: http://jahaneyadak.ir",
                             "Access-Control-Allow-Credentials: true")
                .AllowAnyOrigin()
                 .AllowAnyMethod()
                 .AllowAnyHeader();


            }));
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            //app.UseCors("MyPolicy");
            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=customer}/{action=Index}/{id?}");
            });
        }
    }
}
