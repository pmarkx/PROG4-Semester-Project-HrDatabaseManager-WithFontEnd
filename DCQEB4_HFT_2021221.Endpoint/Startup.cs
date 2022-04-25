using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using DCQEB4_HFT_2021221.Data;
using DCQEB4_HFT_2021221.Logic;
using DCQEB4_HFT_2021221.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using DCQEB4_HFT_2021221.Endpoint.Services;
using Microsoft.AspNetCore.Diagnostics;

namespace DCQEB4_HFT_2021221.Endpoint
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
//            services.AddControllers().AddJsonOptions(x =>
//x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
        
            services.AddTransient<ISalaryLogic, SalaryLogic>();
            services.AddTransient<ISalaryRepository, SalaryRepository>();

            services.AddTransient<IEmployeeLogic, EmployeeLogic>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();

            services.AddTransient<IDepartmentLogic, DepartmentLogic>();
            services.AddTransient<IDepartmentRepository, DepartmentRepository>();

            services.AddTransient<DbContext, HrDbContext>();
            services.AddTransient<HrDbContext,HrDbContext>();
            services.AddSignalR();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",new OpenApiInfo{Title = "HRDB.Endpoint", Version = "v1"});
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HRDB.Endpoint v1"));
            }

            app.UseExceptionHandler(c => c.Run(async context =>
            {
                var exception = context.Features
                    .Get<IExceptionHandlerPathFeature>()
                    .Error;
                var response = new { Msg = exception.Message };
                await context.Response.WriteAsJsonAsync(response);
            }));


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SignalRHub>("/hub");
            });
        }
    }
}
