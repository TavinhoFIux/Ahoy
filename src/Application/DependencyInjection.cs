using Application.NoticiaCommands.Validations;
using Domain.Repositorys;
using Infrastructure.Data;
using Infrastructure.Repositorys;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using FluentValidation;
using Application.TagCommands.Validations;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<INoticiaRepository, NoticiaRepository>();
            services.AddScoped<INoticiaTagRepository, NoticiaTagRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));



            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssemblyContaining<CreateNoticiaCommandValidator>();
            services.AddValidatorsFromAssemblyContaining<CreateTagCommandValidator>();
            services.AddValidatorsFromAssemblyContaining<UpdateTagCommandValidator>();
            services.AddValidatorsFromAssemblyContaining<GetTagByIdQueryValidator>();
            services.AddValidatorsFromAssemblyContaining<GetNoticiaByIdQueryValidator>();

            return services;
        }
    }
}
