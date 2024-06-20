using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;

    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Configura os serviços da aplicação.
        /// </summary>
        /// <param name="services">A coleção de serviços.</param>
        public void ConfigureServices(IServiceCollection services) 
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);

            // Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Asclepio.API", Version = "v1" });
            });

            var key = Configuration.GetConnectionString("DefaultConnection");
            services.AddScoped(provider => new AsclepioRepository(key));
        }

        /// <summary>
        /// Configura o pipeline de requisição HTTP.
        /// </summary>
        /// <param name="app">O construtor de aplicativos.</param>
        /// <param name="env">O ambiente de hospedagem.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Asclepio.API V1");
            });

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

internal class AsclepioRepository
{
    private string? key;

    public AsclepioRepository(string? key)
    {
        this.key = key;
    }
}