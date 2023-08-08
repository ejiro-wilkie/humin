using Humin_Man.Common.Repository;
using Humin_Man.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Humin_Man.Repository
{
    /// <summary>
    /// Initialize the database context with default data.
    /// </summary>
    public class Initializer
    {
        private static IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="userManager">The user manager.</param>
        /// <param name="logger">The logger.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        public static async Task Initialize(HuminDbContext context, UserManager<User> userManager,
            ILogger<Initializer> logger, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            await context.Database.EnsureCreatedAsync();

            if (!(await context.Users.AnyAsync()))
                await CreateUser(userManager, logger);
            if (!(await context.Countries.AnyAsync()))
                await CreateCountries(logger);

            await unitOfWork.SaveAsync();
        }

        private static async Task CreateCountries(ILogger<Initializer> logger)
        {
            logger.LogInformation($"Create range of countries");

            await _unitOfWork.AddRangeAsync(new List<Country> {
             new Country
             {
                 Name = "Cyprus",
                 IsDeleted = false
             },
             new Country
             {
                 Name = "Turkey",
                 IsDeleted = false
             },
             new Country
             {
                 Name = "Syria",
                 IsDeleted = false
             },
             new Country
             {
                 Name = "Egypt",
                 IsDeleted = false
             },
             new Country
             {
                 Name = "Nigeria",
                 IsDeleted = false
             },
             new Country
             {
                 Name = "Libya",
                 IsDeleted = false
             }
         });
        }

        private static async Task CreateUser(UserManager<User> userManager, ILogger<Initializer> logger)
        {
            const string email = "admin@ozbul.com";
            const string password = "admin@ozbul.com";
            const string userName = "admin";

            await CreateUser(userManager, email, userName, password, logger);
        }

        private static async Task CreateUser(UserManager<User> userManager, string email, string userName,
            string password, ILogger<Initializer> logger)
        {
            logger.LogInformation($"Create user with email `{email}` for application");
            var user = new User
            {
                Email = email,
                NormalizedEmail = email.ToUpper(),
                UserName = userName,
                NormalizedUserName = email.ToUpper(),
                AccessFailedCount = 0,
                EmailConfirmed = true,
                FirstName = "Name",
                IsDeleted = false,
                LastName = "LastName",
            };

            var ir = await userManager.CreateAsync(user, password);

            if (ir.Succeeded)
            {
                logger.LogDebug($"Created user `{email}` successfully");
            }
            else
            {
                var exception = new Exception($"Default user `{email}` cannot be created");
                logger.LogError("Log in failed", exception);
                throw exception;
            }
        }
    }
}
