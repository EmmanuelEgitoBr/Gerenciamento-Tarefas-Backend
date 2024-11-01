using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using TasksTrackingApp.Application.UserCQ.Validators;
using TasksTrackingApp.Infrastructure.Persistence;
using TasksTrackingApp.Application.UserCQ.Commands;
using TasksTrackingApp.Application.Mappings;
using Microsoft.OpenApi.Models;
using System.Reflection;
using TasksTrackingApp.Infrastructure.Repository.IRepositories;
using TasksTrackingApp.Infrastructure.Repository.Repositories;

namespace TasksTrackingApp.API.Extensions
{
    public static class BuilderExtensions
    {
        public static void AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
        }

        public static void AddSwaggerDoc(this WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Gerenciamento de Tarefas",
                    Description = "API feita com Clear Architeture",
                    Contact = new OpenApiContact
                    {
                        Name = "Página de contato",
                        Url = new Uri("https://www.google.com")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Licenciamento",
                        Url = new Uri("https://www.google.com")
                    }
                });
                var xmlFileName = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName));
            });
        }

        public static void AddDatabase(this WebApplicationBuilder builder) 
        {
            var configuration = builder.Configuration;

            builder.Services.AddDbContext<TasksDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("SqlConnection")));
        }

        public static void AddMediator(this WebApplicationBuilder builder)
        {
            builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblies(typeof(CreateUserCommand).Assembly));
        }

        public static void AddValidations(this WebApplicationBuilder builder)
        {
            builder.Services.AddValidatorsFromAssemblyContaining<CreateUserCommandValidator>();
            builder.Services.AddFluentValidationAutoValidation();
        }

        public static void AddMapper(this WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(typeof(ProfileMappings).Assembly);
        }

        public static void AddRepositories(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUserRepository, UserRepository>();
        }

    }
}
