using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Pos.Core.Modelos;
using Pos.Infraestructure.Atributos;
using Pos.Infraestructure.Filtros;
using Pos.Infraestructure.Services;

namespace Pos.Infraestructure.Starup.Services
{
    public static class ControllersService
    {
        private static readonly string SettingsApi = "Settings";

        public static IServiceCollection AddControllersExtend(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AppSettingsModel>(configuration.GetSection(SettingsApi));
            var appsettings = configuration.GetSection(SettingsApi).Get<AppSettingsModel>();

            services
                .AddControllers(opt => { 
                    opt.Filters.Add<GlobalValidationFilterAttribute>(); 
                    opt.Filters.Add<TokenAuthenticationFilter>(); 
                })

                .ConfigureApiBehaviorOptions(opt => opt.SuppressModelStateInvalidFilter = true)

                .AddNewtonsoftJson(opt =>
                {
                    opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    opt.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                    opt.SerializerSettings.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Local;
                    opt.UseCamelCasing(false);
                });

            services.AddHttpContextAccessor();
            services.AddSingleton<RouteService>();

            // In production, the React files will be served from this directory
            //services.AddSpaStaticFiles(configuration =>
            //{
            //    configuration.RootPath = "ClientApp/build";
            //});

            services.AddCors(options =>
            {
                options.AddPolicy(name: nameof(appsettings.AllowedOrigins),
                                  policy =>
                                  {
                                      policy
                                        .WithOrigins(appsettings is null ? new string[] { } : appsettings.AllowedOrigins)
                                        .AllowAnyMethod()
                                        .AllowAnyHeader();
                                  });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "VSoftPos Api", Version = "v1" });
            });

            return services;
        }
    }
}
