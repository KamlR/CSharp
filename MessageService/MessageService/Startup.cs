using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace MessageService
{
    /// <summary>
    /// ����� ������� ������� ������ � ���������� ASP.NET Core.
    /// ���������� ������������ ����������, ����������� �������, ������� ���������� ����� ������������.
    /// ������������� ���������� ��� ��������� ������� ��� middleware.
    /// </summary>
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// ����������� ������������ ���������, �������������� ���������������� ����������.
        /// </summary>
        /// <param name="services"> c����� �������������� � � ������������ � ���������� � ������� ��������� ������������ (DI) </param>
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MessageService", Version = "v1" });
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                c.IncludeXmlComments(xmlFilename);
            });
        }

        /// <summary>
        /// ���� ����� ���������� ������ ����������. ����������� ���� ����� ��� ��������� ��������� HTTP-��������.
        /// </summary>
        /// <param name="app"> ��������� ��� ��������� ��������� �������� ���������� </param>
        /// <param name="env"> ������������� �������� � ����� ���-����������, � ������� ����������� ���������� </param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MessageService v1"));
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
