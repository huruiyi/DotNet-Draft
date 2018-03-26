using ASP.NETCore.Interfaces;
using ASP.NETCore.Models;
using ASP.NETCore.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ASP.NETCore
{
    //public class Startup
    //{
    //    public void ConfigureServices(IServiceCollection services)
    //    {
    //        services.AddMvc();

    //        // Adds a default in-memory implementation of IDistributedCache.
    //        services.AddDistributedMemoryCache();

    //        services.AddSession(options =>
    //        {
    //            // Set a short timeout for easy testing.
    //            options.IdleTimeout = TimeSpan.FromSeconds(10);
    //            options.Cookie.HttpOnly = true;
    //        });
    //    }

    //    public void Configure(IApplicationBuilder app)
    //    {
    //        app.UseSession();
    //        app.UseMvcWithDefaultRoute();
    //    }
    //}

    public class Startup
    {
        // 调用顺序是先ConfigureServices后Configure。
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            // Adds a default in-memory implementation of IDistributedCache.
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
            });

            #region Authentication

            /*
          *  WindowsAuthSample 配置 launchSettings.json:
             {
               "iisSettings": {
                 "windowsAuthentication": true,
                 "anonymousAuthentication": false,
                 "iisExpress": {
                   "applicationUrl": "http://localhost:52171/",
                   "sslPort": 0
                 }
               }
             }
          */

            //  IIS
            //  IISDefaults requires the following import:
            //  using Microsoft.AspNetCore.Server.IISIntegration;
            //  services.AddAuthentication(IISDefaults.AuthenticationScheme);

            //  HTTP.sys
            //  HttpSysDefaults requires the following import:
            //  using Microsoft.AspNetCore.Server.HttpSys;
            // services.AddAuthentication(HttpSysDefaults.AuthenticationScheme);

            #endregion Authentication

            #region IOC

            //services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase());

            // Register application services.
            //services.AddScoped<ICharacterRepository, CharacterRepository>();
            //services.AddTransient<IOperationTransient, Operation>();
            //services.AddScoped<IOperationScoped, Operation>();
            //services.AddSingleton<IOperationSingleton, Operation>();
            //services.AddSingleton<IOperationSingletonInstance>(new Operation(Guid.NewGuid()));
            //services.AddTransient<OperationService, OperationService>();

            services.AddTransient<IOperationTransient, Operation>();
            services.AddTransient<OperationService, OperationService>();
            services.AddScoped<ICharacterRepository, CharacterRepository>();
            services.AddScoped<IOperationScoped, Operation>();
            services.AddSingleton<IOperationSingleton, Operation>();
            services.AddSingleton<IOperationSingletonInstance>(new Operation(Guid.NewGuid()));

            #endregion IOC
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            #region WindowsIdentity

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //    try
            //    {
            //        var user = (WindowsIdentity)context.User.Identity;

            //        await context.Response.WriteAsync($"User: {user.Name}\tState: {user.ImpersonationLevel}\n");

            //        WindowsIdentity.RunImpersonated(user.AccessToken, () =>
            //        {
            //            var impersonatedUser = WindowsIdentity.GetCurrent();
            //            var message = $"User: {impersonatedUser.Name}\tState: {impersonatedUser.ImpersonationLevel}";

            //            var bytes = Encoding.UTF8.GetBytes(message);
            //            context.Response.Body.Write(bytes, 0, bytes.Length);
            //        });
            //    }
            //    catch (Exception e)
            //    {
            //        await context.Response.WriteAsync(e.ToString());
            //    }
            //});

            #endregion WindowsIdentity

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            /*
             * https://docs.microsoft.com/zh-cn/aspnet/core/fundamentals/app-state?tabs=aspnetcore2x
             * https://docs.microsoft.com/zh-cn/aspnet/core/fundamentals/middleware/index?tabs=aspnetcore2x#ordering
             排序对于中间件组件至关重要。 在前面的示例中，在 UseMvcWithDefaultRoute 之后调用 UseSession 时会发生 InvalidOperationException 类型的异常。 有关详细信息，请参阅中间件排序。
             */
            app.UseSession();
            app.UseMvcWithDefaultRoute();
            app.UseStaticFiles();
        }
    }
}