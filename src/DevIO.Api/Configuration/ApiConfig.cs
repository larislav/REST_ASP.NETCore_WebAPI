using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace DevIO.Api.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection WebApiConfig(this IServiceCollection services)
        {
            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true; // para retornar no header caso a API esteja obsoleta
            });

            services.AddVersionedApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV"; //v de versão + aceito até 3 parametros: major version, minor version, e patch
                options.SubstituteApiVersionInUrl = true; // se tiver uma rota padrao, ele substitue o numero da versao pela versao default

            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true; //suprimir a forma de validação automatica da view model
            });

            services.AddCors(options =>
            {
                options.AddPolicy("Development",
                                    builder => builder
                                    .AllowAnyMethod()
                                    .AllowAnyHeader()
                                    .SetIsOriginAllowed(hostname => true));

                options.AddPolicy("Production",
                                    builder => builder
                                    .WithMethods("GET")
                                    .WithOrigins("http://desenvolvedor.io")
                                    .SetIsOriginAllowedToAllowWildcardSubdomains()
                                    .WithHeaders(HeaderNames.ContentType, "x-custom-header")
                                    .AllowAnyHeader());
            });
            return services;
        }

        public static IApplicationBuilder UseMvcConfiguration(this IApplicationBuilder app)
        {
            app.UseHttpsRedirection();
            app.UseCors("Development");
            //app.UseMvc();
            return app;
        }
    }
}
