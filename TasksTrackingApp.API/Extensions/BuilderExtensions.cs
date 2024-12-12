using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using TasksTrackingApp.Application.Mappings;
using TasksTrackingApp.Application.UserCQ.Commands;
using TasksTrackingApp.Application.UserCQ.Validators;
using TasksTrackingApp.Domain.Abstractions;
using TasksTrackingApp.Infrastructure.Persistence;
using TasksTrackingApp.Infrastructure.Repository.IRepositories;
using TasksTrackingApp.Infrastructure.Repository.Repositories;
using TasksTrackingApp.Infrastructure.Repository.UnitOfWork;
using TasksTrackingApp.Services.AuthService;

namespace TasksTrackingApp.API.Extensions
{
    public static class BuilderExtensions
    {
        public static void AddJwtAuth(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IAuthService, AuthService>();

            var configuration = builder.Configuration;

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => 
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = configuration["JWT:Issuer"],
                    ValidAudience = configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]!))
                }).AddCookie(options =>
                {
                    options.Cookie.HttpOnly = true;
                    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                    options.Cookie.SameSite = SameSiteMode.Strict;
                    options.ExpireTimeSpan = TimeSpan.FromHours(5);
                });
        }

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
            var connection = configuration.GetConnectionString("SqlConnection");

            builder.Services.AddDbContext<TasksDbContext>(options =>
                    options.UseSqlServer(connection));

            builder.Services.AddHealthChecks().AddSqlServer(connection!, name: "SQL Health Check");

            builder.Services.AddHealthChecksUI(options => {
                    options.SetEvaluationTimeInSeconds(10); // Tempo entre as verificações
                    options.MaximumHistoryEntriesPerEndpoint(100); // Máximo de entradas de histórico por endpoint
            }).AddSqlServerStorage(connection!);
            
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
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IWorkspaceRepository, WorkspaceRepository>();
            builder.Services.AddScoped<IListCardRepository, ListCardRepository>();
            builder.Services.AddScoped<ICardRepository, CardRepository>();
        }

    }
}
