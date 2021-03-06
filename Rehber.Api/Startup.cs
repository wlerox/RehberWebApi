using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Rehber.Business.Abstract;
using Rehber.Business.Concrete;
using Rehber.DataAccess;
using Rehber.DataAccess.Abstract;
using Rehber.DataAccess.Concrete;
using Rehber.DataAccess.Mapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Rehber.Api
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
            services.AddControllers();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<ICacheProcesses, CacheProcesses>();
            //DB connection
            services.AddDbContext<PersonDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DatabaseConnect"),
                providerOptions => providerOptions.EnableRetryOnFailure());
            });
            //Redis connection
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = Configuration.GetConnectionString("RedisConnect");
            });
            //Add mapper
            services.AddAutoMapper(typeof(AppProfile));

            //Swagger
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Telefon Rehber Api",
                    Version = "v1"
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                x.IncludeXmlComments(xmlPath);

            });

            services.AddControllers().AddNewtonsoftJson(options =>
                  options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, PersonDbContext personDbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            personDbContext.Database.EnsureCreated();

            app.UseSwagger();
            app.UseSwaggerUI(x=> { x.SwaggerEndpoint("/swagger/v1/swagger.json", "Rehber API"); });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                /*endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });*/
            });
        }
    }
}
