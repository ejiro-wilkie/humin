using Humin_Man.Entities;
using Humin_Man.Repository.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Humin_Man.Repository
{
    /// <summary>
    /// Class that defines the database context
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext" />
    public class HuminDbContext : IdentityDbContext<User, IdentityRole<long>, long>
    {
        /// <summary>
        /// Gets or sets the countries.
        /// </summary>
        /// <value>
        /// The countries.
        /// </value>
        public DbSet<Country> Countries { get; set; }

        /// <summary>
        /// Gets or sets the companies.
        /// </summary>
        /// <value>
        /// The companies.
        /// </value>
        public DbSet<Company> Companies { get; set; }

        /// <summary>
        /// Gets or sets the categories.
        /// </summary>
        /// <value>
        /// The categories.
        /// </value>
        public DbSet<Category> Categories { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HuminDbContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public HuminDbContext(DbContextOptions<HuminDbContext> options) : base(options)
        { }

        /// <summary>
        /// Called when [model creating].
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new CompanyConfiguration());

            builder.Entity<Company>(c =>
            {
                c.HasOne(country => (Country)country.Country)
                    .WithMany()
                    .HasForeignKey(country => country.CountryId);
            });
            builder.Entity<Category>();
        }
    }
}