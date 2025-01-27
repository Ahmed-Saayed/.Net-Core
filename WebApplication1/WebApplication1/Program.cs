using Microsoft.AspNetCore.Http;
using Microsoft.Graph.Drives.Item.Items.Item.Workbook.Functions.Now;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession(conf =>
            {
                conf.IdleTimeout = TimeSpan.FromMinutes(20);
            });


            var app = builder.Build();

            
             // Bulit in MiddleWares  !!!
             // Configure the HTTP request pipeline.
             if (!app.Environment.IsDevelopment())
             {
                 app.UseExceptionHandler("/Home/Error");
             }
             app.UseStaticFiles();

             app.UseRouting();

             app.UseAuthorization();

            app.UseSession();
            

           //now u can use
           // /controller name/action name /parameter  or /pro/ parameter  
            app.MapControllerRoute("Route1",         // customize the wirtten URl   Vedio 4 row 3 min 46
                "pro/{msg:alpha}", new 
                   {
                    controller = "Product",
                    action = "print"
                    }
                );
            
            // when make run URL Video 4 min50
            app.MapControllerRoute(
                 name: "default",
                 pattern: "{controller=Home}/{action=Index}/{id?}"
                 );
   

            //===================================================================================================
            /*
            //(CustomMiddleWares)

            app.Use(async (httpContext, next) =>
            {
                //write response
                await httpContext.Response.WriteAsync("1) Middle Ware 1\n");
                //call next
                await next.Invoke();
                //back
                await httpContext.Response.WriteAsync("1) Middle Ware 1\n");

            });

            app.Use(async (httpContext, next) =>
            {
                //write response
                await httpContext.Response.WriteAsync("2) Middle Ware 2\n");
                //call next
                await next.Invoke();
                // back
                await httpContext.Response.WriteAsync("2) Middle Ware 2\n");
            });
            // Terminate
            app.Run(async(httpContext)=>{
                await httpContext.Response.WriteAsync("3) Terminate\n");
            });*/

            app.Run();
        }
    }
}
