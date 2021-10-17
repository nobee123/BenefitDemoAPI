using Autofac;
using Autofac.Extensions.DependencyInjection;
using BenefitCalculation.API.Autofac;
using BenefitCalculation.Contracts.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;

namespace BenefitCalculation.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddAutofac();
            services.AddMvc();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Benefit Calculation API", Version = "v1" });
            });
            services.AddOptions();            
            services.Configure<FirstNameDiscountConfiguration>(Configuration.GetSection("FirstNameDiscount"));
            services.Configure<CostOfBenefitConfiguration>(Configuration.GetSection("CostOfBenefit"));
            services.Configure<CalculatePayPeriodConfiguration>(Configuration.GetSection("PayPeriod"));
            
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule(new ServiceModule());
            containerBuilder.Populate(services);
            var container = containerBuilder.Build();
            return new AutofacServiceProvider(container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Benefit Calculation API");
                c.RoutePrefix = string.Empty;

            });
            app.UseCors(b => b.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials());
            app.UseHttpsRedirection();
            app.UseMvc();
            
        }
    }
}
