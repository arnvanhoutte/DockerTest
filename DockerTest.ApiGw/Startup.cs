using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace DockerTest.ApiGw
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
            //services.AddHealthChecks()
            //    .AddCheck("self", () => HealthCheckResult.Healthy())
            //    .AddUrlGroup(new Uri(_cfg["CatalogUrlHC"]), name: "catalogapi-check", tags: new string[] { "catalogapi" })
            //    .AddUrlGroup(new Uri(_cfg["OrderingUrlHC"]), name: "orderingapi-check", tags: new string[] { "orderingapi" })
            //    .AddUrlGroup(new Uri(_cfg["BasketUrlHC"]), name: "basketapi-check", tags: new string[] { "basketapi" })
            //    .AddUrlGroup(new Uri(_cfg["IdentityUrlHC"]), name: "identityapi-check", tags: new string[] { "identityapi" })
            //    .AddUrlGroup(new Uri(_cfg["MarketingUrlHC"]), name: "marketingapi-check", tags: new string[] { "marketingapi" })
            //    .AddUrlGroup(new Uri(_cfg["PaymentUrlHC"]), name: "paymentapi-check", tags: new string[] { "paymentapi" })
            //    .AddUrlGroup(new Uri(_cfg["LocationUrlHC"]), name: "locationapi-check", tags: new string[] { "locationapi" });

            services.AddOcelot(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseHttpsRedirection();
            await app.UseOcelot().ConfigureAwait(false);
        }
    }
}
