using System.Reflection;
using Microsoft.OpenApi.Models;

namespace API.Helpers;

public static class SwaggerConfiguration
{
  public static void SwaggerConfigure(this IServiceCollection services)
  {
    services.AddSwaggerGen(c =>
    {
      c.SwaggerDoc("v1", new OpenApiInfo
      {
        Version = "v2",
        Title = "TaskTrackingAPI",
        Description = "Api provides work with tasks for TaskTrackingApp.",
        Contact = new OpenApiContact()
      });
      string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
      string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
      c.IncludeXmlComments(xmlPath);

      c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
      {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description =
                          "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\""
      });

      c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
                    {
                            new OpenApiSecurityScheme
                            {
                                    Reference = new OpenApiReference
                                    {
                                            Type = ReferenceType.SecurityScheme,
                                            Id = "Bearer"
                                    }
                            },
                            Array.Empty<string>()
                    }
        });
    });
  }
}