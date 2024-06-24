using Common.Logging;
using Common.Logging.Correlation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace Ocelot.ApiGateway;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        var authScheme = "EShoppingGatewayAuthScheme";                          
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(authScheme, options => 
            {
                options.Authority = "https://localhost:9009";
                options.Audience = "EShoppingGateway";                                    
            });

        services.AddScoped<ICorrelationIdGenerator, CorrelationIdGenerator>();
        services.AddOcelot()
            .AddCacheManager(o => o.WithDictionaryHandle());
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.AddCorrelationIdMiddleware();
        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapGet("/", async context => 
            {
                await context.Response.WriteAsync("Hello Ocelot"); 
            });
        });

        app.UseOcelot().Wait();
    }
}