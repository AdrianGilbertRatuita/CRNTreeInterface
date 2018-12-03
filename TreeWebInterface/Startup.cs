using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Azure.SignalR;
using Microsoft.Extensions.Configuration;

namespace TreeWebInterface
{
    public class Startup
    {

        public IConfiguration Configuration { get; }

        private Action<ServiceRouteBuilder> AzureSignalRBuilder;

        public Startup(IConfiguration configuration)
        {

            Configuration = configuration;
            AzureSignalRBuilder = delegate (ServiceRouteBuilder T) { T.MapHub<Chat>("/chat"); };

        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc();
            services.AddSignalR().AddAzureSignalR("Endpoint=https://cloudrelaynetwork.service.signalr.net;AccessKey=SLpj+SJE2jI9jUE10sQvtfytrU0SwcJF8s0yORpZn84=;Version=1.0;");

        }   

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            app.UseMvc();
            app.UseFileServer();
            app.UseAzureSignalR(AzureSignalRBuilder);

        }

        
    }
}
