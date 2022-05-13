using Elmah.Io.Extensions.Logging;

namespace DevIO.Api.Configuration
{
    public static class LoggerConfig
    {
        public static IServiceCollection AddLoggingConfiguration(this IServiceCollection services)
        {
            services.AddElmahIo(o =>
            {
                o.ApiKey = "3561a5130f95412caca7141fa966c8d9";
                o.LogId = new Guid("82f7b369-ee76-482b-90ee-03684813b589");
            });

            //services.AddLogging(builder =>
            //{
            //    //configurar o Elmah como provider para os logs do .NET
            //    builder.AddElmahIo(o =>
            //    {
            //        o.ApiKey = "3561a5130f95412caca7141fa966c8d9";
            //        o.LogId = new Guid("82f7b369-ee76-482b-90ee-03684813b589");
            //    });
            //    builder.AddFilter<ElmahIoLoggerProvider>(null, LogLevel.Warning);

            //});

            return services;
        }

        public static IApplicationBuilder UseLoggingConfiguration(this IApplicationBuilder app)
        {
            app.UseElmahIo();
            return app;
        }
    }
}
