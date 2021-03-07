using DataRepository.DB;
using DataRepository.Interfaces;
using DataRepository.Models.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Npgsql;
using TodosService.Interfaces;
using TodosService.Handlers;
using DataRepository.Models.DB;
using Serilog;

namespace TodosService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            Log.Logger = new LoggerConfiguration()
                                .ReadFrom.Configuration(configuration)
                                .CreateLogger();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddHealthChecks();
            services.AddControllers();

            var builder = new NpgsqlConnectionStringBuilder(Configuration.GetConnectionString("DefaultConnection"));

            services.AddDbContext<TodosDbContext>
                (options => options.UseNpgsql(builder.ConnectionString, b => b.MigrationsAssembly("TodosService")));

            services.AddScoped<TodosDbContext>();

            services.AddScoped(typeof(IModelRepository<>), typeof(ModelRepository<>));
            services.AddScoped(typeof(INotificationsHandler), typeof(NotificationsHandler));

            // Add the model repositories to the dep injector
            services.AddScoped<ITodoListRepository, TodoListRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITodoItemRepository, TodoItemRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TodosService", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, TodosDbContext dataContext)
        {
            app.UseHealthChecks("/checkhealth");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TodosService v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Run DB migrations on app start
            dataContext.Database.Migrate();
        }
    }
}
