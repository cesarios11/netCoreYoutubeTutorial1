using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.IIS.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp
{
    public class Startup
    {
        private IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //TODO:Inicialización del motor de base de datos que se va a utilizar ('Sql Server')
            services.AddDbContextPool<AppDbContext>(options => options.UseSqlServer(_configuration.GetConnectionString("ConexionSQLServer")));

            //TODO: Se inicializa la configuración  del patrón MVC.
            services.AddMvc(options => options.EnableEndpointRouting = false);
            //services.AddMvcCore(options => options.EnableEndpointRouting = false);

            //TODO:Crea un servicio singleton cuando se solicita por primera vez y esta es la misma instancia que 
            //es utilizada por todas las solicitudes posteriores.
            //services.AddSingleton<IAmigoAlmacen, MockAmigoRepositorio>();

            //TODO:Se utiliza el acceso a datos de la BD SQL Server.
            services.AddScoped<IAmigoAlmacen, SQLAmigoRepositorio>();

            /*
            //TODO:Se crea un servicio transitorio. Crea una instancia de un servicio transitorio, cada vez que se solicita.
            //Cada peticion crearía un nuevo objeto
            services.AddTransient<IAmigoAlmacen, MockAmigoRepositorio>();

            //TODO:Crea una nueva instancia durante el ámbito de ejecución. Durante el tiempo que dure la petición.
            services.AddScoped<IAmigoAlmacen, MockAmigoRepositorio>();
            */

            //TODO:
            //AddIdentity: Agrega la configuración predeterminada para el sistema de gestión de identidades para el usuario especificado y para los roles.
            //IdentityUser: Esta clase proporciona para asp net core propiedades de usuario. (Nombre usuario, password, un hash, un email etc).
            //IdentityRole: Esta clase de manera predeterminada en asp net core se utiliza para administrar usuarios registrados en la aplicación.
            //AddEntityFrameworkStores: Para almacenar y recuperar la información de usuario de las tablas, pasándole como argumento 'AppDbContext'
            //Se agrega '.AddErrorDescriber<ErroresCastellano>()' para que tome los valores de texto de las validaciones de errores de la clase 'ErroresCastellano'.
            services.AddIdentity<IdentityUser, IdentityRole>().AddErrorDescriber<ErroresCastellano>().AddEntityFrameworkStores<AppDbContext>();

            //TODO: Si por defecto se redirige al controlador 'Account' (que trae predeterminadamente Identity)
            //y no a 'Cuentas', entonces es necesario utilizar la siguiente línea de código.
            //Adicional a esto, si el usuario no está logueado, entonces lo redirige a la página de Login para que
            //inicie sesión.
            services.ConfigureApplicationCookie(options=> options.LoginPath ="/Cuentas/Login");

            //TODO:Se configuran las restricciones para el campo password
            services.Configure<IdentityOptions>(opciones => {
                opciones.Password.RequiredLength = 8;
                opciones.Password.RequiredUniqueChars = 3;
                opciones.Password.RequireNonAlphanumeric = false;

            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                DeveloperExceptionPageOptions opt = new DeveloperExceptionPageOptions {
                    SourceCodeLineCount = 2
                };
                app.UseDeveloperExceptionPage(opt);   
            }
            else if (env.IsProduction() || env.IsStaging())
            {
                //TODO: Redirige al controlador 'ErrorController' y se muestra la vista 'Error' ubicada en Shared para manejar los errores que se puedan producir
                app.UseExceptionHandler("/Error");
                //TODO: Redirige al controlador 'ErrorController' y se muestra la vista 'Error' que recibe un statusCode ubicada en Shared para manejar los errores que se puedan producir
                app.UseStatusCodePagesWithRedirects("/Error/{0}");
            }
            /*
            DefaultFilesOptions d = new DefaultFilesOptions();
            d.DefaultFileNames.Clear();
            d.DefaultFileNames.Add("noDefault.html");
            app.UseDefaultFiles(d);
            app.UseStaticFiles();
            */

            /*
            app.UseDefaultFiles();
            app.UseStaticFiles();   
            */

            //TODO: Middleware que permite cargar los archivos estáticos: imagenes, js, css etc
            app.UseStaticFiles();

            //TODO:Se especifica que utilice la autenticación.
            app.UseAuthentication();

            //TODO: Usa por defecto el enrutamiento de las aplicaciones asp.net core
            //app.UseMvcWithDefaultRoute();

            //TODO:Define un enrutamiento personalizado
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });

            //TODO: Este enrutamiento obliga a definir la etiqueta '[Route("Home/Details5/{id?}")]' para cada 
            //método del controlador.
            //Si solo se usa app.UseMvcWithDefaultRoute(); entonces estas etiquetas no son necesarias
            //app.UseMvc();

            /*
            app.Use(async(context, next) => {
                await context.Response.WriteAsync($"Entorno: {env.EnvironmentName}");
                await next.Invoke();
            });
            */

            /*
            app.Run(async (context) => {
                //await context.Response.WriteAsync(System.Diagnostics.Process.GetCurrentProcess().ProcessName);
                await context.Response.WriteAsync($"\n{_configuration["KeyWord"]}");
            });
            */
            
        }
    }
}
