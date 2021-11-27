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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
