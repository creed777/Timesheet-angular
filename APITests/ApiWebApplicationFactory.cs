using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;

using APITests.BogusData;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace APITests
{
    public class ApiWebApplicationFactory : WebApplicationFactory<Program>
    {
        public IConfiguration Configuration { get; private set; }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration(config => { Configuration = new ConfigurationBuilder().AddJsonFile("IntegrationSettings.json").Build(); config.AddConfiguration(Configuration); });

            builder.ConfigureTestServices(services =>
            {
                services.AddTransient<IClientBogusData, ClientBogusData>();
            });
        }
    }
}
