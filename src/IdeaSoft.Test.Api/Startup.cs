using AutoMapper;
using IdeaSoft.Test.Api.Data;
using IdeaSoft.Test.Api.Domain;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace IdeaSoft.Test.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));

            services.Configure<PersonDbSettings>(
                Configuration.GetSection(nameof(PersonDbSettings)));
            services.AddSingleton<IPersonDbSettings>(provider =>
                provider.GetRequiredService<IOptions<PersonDbSettings>>().Value);

            services.AddSingleton<IPersonRepository, PersonRepository>();

            services.AddScoped<IPersonService, PersonService>();

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
