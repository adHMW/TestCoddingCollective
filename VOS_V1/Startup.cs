using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//using Rotativa.AspNetCore;
using VOS_V1.Contexts;
using VOS_V1.Services;
using Microsoft.EntityFrameworkCore;
using Rotativa.AspNetCore;
using Newtonsoft.Json.Serialization;
using VOS_V1.Utility;
using Microsoft.AspNetCore.Http.Features;

namespace VOS_V1
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
            //services.Configure<CookiePolicyOptions>(options =>
            //{
            //    // This lambda determines whether user consent for non-essential cookies is needed for a given request.
            //    options.CheckConsentNeeded = context => true;
            //    options.MinimumSameSitePolicy = SameSiteMode.None;
            //});


            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //services.AddDbContext<VOSDBContext>(options =>
            //   options.UseOracle(Configuration.GetConnectionString("LocalConnection")));
            services.Configure<FormOptions>(options => {
                options.ValueCountLimit = int.MaxValue;
            });

            services.AddDbContext<VOSDBContext>(options =>
               options.UseOracle(Configuration.GetConnectionString("DevConnection")));

            //services.AddDbContext<VOSDBContext>(options =>
            //   options.UseOracle(@"User Id=vos;Password=Bii123456;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SID=ORCL)));"));

            // options.UseSqlServer(Configuration.GetConnectionString("HomeConnection"), builder => builder.UseRowNumberForPaging()));
            services.AddScoped<IAuthService>(x => 
            
            
            new AuthService(x.GetRequiredService<VOSDBContext>(), Configuration.GetValue<string>("LDAPAuth:Domain")));
            
            
            
            services.AddScoped<ILogService, LogService>();
            services.AddScoped<IDashboardService, DashboardService>();
            services.AddScoped<IMailTemplateServices, MailTemplateServices>();
            services.AddMvc()
                .AddSessionStateTempDataProvider();
            services.AddMemoryCache();
            services.AddSession();

            services
    .AddMvc()
    .AddJsonOptions(opt => opt.SerializerSettings.ContractResolver
        = new DefaultContractResolver());

            services.AddMvc(option =>
            {
                        // add the custom binder at the top of the collection
                        option.ModelBinderProviders.Insert(0, new DateTimeModelBinderProvider());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //[Obsolete]
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,  Microsoft.AspNetCore.Hosting.IHostingEnvironment env2)
        {
            var cultureInfo = new System.Globalization.CultureInfo("id-ID");
            System.Globalization.CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            System.Globalization.CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseCookiePolicy();
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Login}/{action=Index}/{id?}");
            });
            
            RotativaConfiguration.Setup(env);
        }
        

    }
}
