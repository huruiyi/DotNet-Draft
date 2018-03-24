using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.HttpSys;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Security.Principal;
using System.Text;
using Microsoft.AspNetCore.Server.IISIntegration;

namespace WindowsAuthSample
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // https://docs.microsoft.com/zh-cn/aspnet/core/security/authentication/windowsauth?tabs=aspnetcore2x
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            //  IIS
            //  IISDefaults requires the following import:
            //  using Microsoft.AspNetCore.Server.IISIntegration;
            services.AddAuthentication(IISDefaults.AuthenticationScheme);

            //  HTTP.sys
            //  HttpSysDefaults requires the following import:
            //  using Microsoft.AspNetCore.Server.HttpSys;
            // services.AddAuthentication(HttpSysDefaults.AuthenticationScheme);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Run(async (context) =>
           {
               try
               {
                   var user = (WindowsIdentity)context.User.Identity;

                   await context.Response.WriteAsync($"User: {user.Name}\tState: {user.ImpersonationLevel}\n");

                   WindowsIdentity.RunImpersonated(user.AccessToken, () =>
                   {
                       var impersonatedUser = WindowsIdentity.GetCurrent();
                       var message = $"User: {impersonatedUser.Name}\tState: {impersonatedUser.ImpersonationLevel}";

                       var bytes = Encoding.UTF8.GetBytes(message);
                       context.Response.Body.Write(bytes, 0, bytes.Length);
                   });
               }
               catch (Exception e)
               {
                   await context.Response.WriteAsync(e.ToString());
               }
           });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}