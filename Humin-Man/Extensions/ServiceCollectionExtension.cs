using Humin_Man.Auth.Managers;
using Humin_Man.Common;
using Humin_Man.Common.Repository;
using Humin_Man.Common.Service;
using Humin_Man.Converter;
using Humin_Man.Entities;
using Humin_Man.Repository;
using Humin_Man.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using System.Security.Claims;
using Humin_Man.Converters;

namespace Humin_Man.Extensions
{
    /// <summary>
    /// Extension class for services registrations.
    /// </summary>
    public static class ServiceCollectionExtension
    {
        /// <summary>
        /// Registers the sql database.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="serviceLifetime">The service lifetime.</param>
        /// <returns></returns>
        public static IServiceCollection RegisterSqlDatabase<T>(this IServiceCollection services, IConfiguration configuration, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped) where T : DbContext =>
            services.RegisterSqlDatabaseAndUnitOfWork<T>(configuration.GetConnectionString("HuminDbContext"), serviceLifetime);

        /// <summary>
        /// Registers the services.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();
            services.AddTransient<IContext, Context>(c =>
            {
                IHttpContextAccessor httpContextAccessor = c.GetService<IHttpContextAccessor>();

                ClaimsPrincipal claimsPrincipal = httpContextAccessor.HttpContext?.User;

                if (claimsPrincipal == null)
                    return new Context();

                var userManager = c.GetService<HuminUserManager>();
                string userId = userManager.GetUserId(claimsPrincipal);

                if (string.IsNullOrEmpty(userId))
                    return new Context();

                if (!long.TryParse(userId, out long id))
                    return new Context();

                return new Context(id);
            });

            services.AddTransient<ICompanyService, CompanyService>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<ICategoryService, CategoryService>();

            services.AddSingleton<CompanyConverter>();
            services.AddSingleton<CategoryConverter>();
            services.AddSingleton<UserConverter>();
            services.AddSingleton<UserViewModelConverter>();
            services.AddSingleton<CompanyViewModelConverter>();
            services.AddSingleton<CategoryModelConverter>();

            return services;
        }

        /// <summary>
        /// Registers the web component.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <param name="configuration">The configuration.</param>
        /// <returns></returns>
        public static IServiceCollection RegisterWebComponent(this IServiceCollection services, IConfiguration configuration)
        {
            services.ConfigureApplicationCookie(op => op.LoginPath = "/login");
            //services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            return services;
        }

        /// <summary>
        /// Registers the swagger.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection RegisterSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                c.AddSecurityDefinition("Auth", new OpenApiSecurityScheme
                {
                    Description = "Standard Authorization header",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic"
                });
            });

            return services;
        }

        /// <summary>
        /// Registers the identity.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection RegisterIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole<long>>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 8;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireNonAlphanumeric = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
            })
                .AddEntityFrameworkStores<HuminDbContext>()
                .AddUserManager<HuminUserManager>()
                .AddRoleManager<RoleManager<IdentityRole<long>>>()
                .AddSignInManager<HuminSingInManager>()
                .AddDefaultTokenProviders();

            return services;
        }

        /// <summary>
        /// Registers the web components.
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection RegisterWebComponents(this IServiceCollection services)
        {
            services.AddControllers(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                 .RequireAuthenticatedUser()
                                 .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });
            services.AddControllersWithViews();
            services.AddRazorPages();

            return services;
        }

        /// <summary>
        /// Registers the SQL database and unit of work.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="services">The services.</param>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="serviceLifetime">The service lifetime.</param>
        /// <returns></returns>
        private static IServiceCollection RegisterSqlDatabaseAndUnitOfWork<T>(this IServiceCollection services, string connectionString, ServiceLifetime serviceLifetime = ServiceLifetime.Scoped) where T : DbContext
        {
            services.AddUniteOfWork<T>();

            services.AddDbContext<HuminDbContext>(options =>
                options.UseSqlServer(connectionString));

            return services;
        }

        /// <summary>
        /// Adds the unite of work.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        private static IServiceCollection AddUniteOfWork<T>(this IServiceCollection services) where T : DbContext =>
            services.AddScoped<IUnitOfWork, UnitOfWork<T>>();
    }
}
