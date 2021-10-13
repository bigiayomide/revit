using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Refit;
using Revix.Extentions;
using Revix.Filters;
using Revix.Models;
using Revix.Services.Contracts;
using System;

namespace Revix
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers(options =>
                {
                    options.Filters.Add(options.Filters.Add(typeof(HttpGlobalExceptionFilter)));
                });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Revix", Version = "v1" });
            });

            services.AddRefitClient<ICoinMarketCapService>()
                .ConfigureHttpClient(c =>
                {
                    c.BaseAddress = new Uri(Configuration["MARKET-URL"]);
                    c.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", Configuration["MARKET-API-KEY"]);

                });



            services
            .AddAutoMapper(typeof(DomainProfile))
                .AddDatabase(Configuration)
                .AddRepositories()
                .AddServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Revix v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
