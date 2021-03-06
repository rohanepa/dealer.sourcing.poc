using Dealer.Sourcing.Api.Private.Application.Mappers;
using Dealer.Sourcing.Api.Private.Config.IoC;
using Dealer.Sourcing.Api.Private.Config.Middlewares;
using Dealer.Sourcing.Infrastructure.Repository.Tech;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Dealer.Sourcing.Api.Private
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
            //Configure Mediator
            services.AddMediatR(typeof(Startup));

            //Register Repositories
            services.RegisterAllRepositories(typeof(IRepository<>).Assembly);

            DapperConfig.Configure(services);

            services.AddAutoMapper(typeof(Infrastructure.Mappers.SourcingMapper), typeof(Mapper));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Dealer.Sourcing.Api.Private", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Dealer.Sourcing.Api.Private v1"));
            }

            app.UseMiddleware<ExceptionHandlerMiddleware>();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
