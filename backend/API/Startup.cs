using API.Helpers;
using BLL.Injections;

namespace API;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    private IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers(options =>
                {
                    options.Filters.Add(new ApiExceptionFilter());
                    options.Filters.Add(new ValidateModelAttribute());
                })
                .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true)
                .AddNewtonsoftJson(options => { options.SerializerSettings.DateFormatString = "yyyy-MM-dd"; });

        services.AddBusinessDependencies();

        services.ConfigureIdentityPasswordSettings();
        services.JwtAuthorizationConfiguration();

        services.SwaggerConfigure();

        services.AddCors();
        
        services.AddHealthChecks();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

        app.UseAuthentication();

        app.UseSwagger(c => { c.SerializeAsV2 = true; });

        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "TaskTrackingAPI");
            c.RoutePrefix = string.Empty;
        });

        app.UseRouting();

        app.UseAuthorization();
        
        app.UseHealthChecks("/healthz");

        app.UseEndpoints(endpoints => { endpoints.MapDefaultControllerRoute(); });
    }
}