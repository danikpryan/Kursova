using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Wall.Domain;
using Wall.Domain.Repositories.Abstract;
using Wall.Domain.Repositories.EntityFramework;
using Wall.Service;

namespace Wall
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            //���������� ������ �� appsetings.json
            Configuration.Bind("Project", new Config());


            //���������� ������ ���������� ���������� � �������� ��������
            //services.AddTransient<ITextFieldsRepository, EFTextFieldsRepository>();
            services.AddTransient<IProductsRepository, EFProductsRepository>();
            //services.AddTransient<ICategoryRepository, EFCategoryRepository>();
            //services.AddTransient<IAllOrdersRepository, EFOrdersRepository>();
            //services.AddTransient<ICheckOrdersRepository, EFCheckOrdersRepository>();
            services.AddTransient<DataManager>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddScoped(sp => DeliveryCart.GetCart(sp));

            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddMemoryCache();
            services.AddSession();

            //���������� �������� � ��
            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(Config.ConnectionString));

            //����������� identity �������
            services.AddIdentity<IdentityUser, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            //����������� authentication cookie
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "newsAuth";
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/account/Login";
                options.AccessDeniedPath = "/account/accessdenied";
                options.SlidingExpiration = true;
            });
            //services.AddMvc(option => option.EnableEndpointRouting = false);

            //����������� �������� ����������� ��� Admin area
            services.AddAuthorization(x =>
            {
                x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
            });

            //��������� ������� ��� ������������ � ������������� (MVC)
            services.AddControllersWithViews(x =>
            {
                x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
            })
                //���������� ������������� � asp.net core 3.0
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSession();
            app.UseMvc();
            //���������� ��������� ��������� ������ � ���������� (css, js � �.�.)
            app.UseStaticFiles();

            //���������� ������� �������������
            app.UseRouting();

            //���������� �������������� � �����������
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            //������������� ������ ��� �������� (���������)
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("admin", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute("show",  "Wall/{action}/{id?}", defaults: new { Controller = "Products", action = "Show" });
            });

            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDbContext context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            }
        }
    }
}
