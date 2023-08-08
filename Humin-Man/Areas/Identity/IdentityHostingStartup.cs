using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Humin_Man.Areas.Identity.IdentityHostingStartup))]
namespace Humin_Man.Areas.Identity
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="IHostingStartup" />
    public class IdentityHostingStartup : IHostingStartup
    {
        /// <summary>
        /// Configure the <see cref="T:Microsoft.AspNetCore.Hosting.IWebHostBuilder" />.
        /// </summary>
        /// <param name="builder"></param>
        /// <remarks>
        /// Configure is intended to be called before user code, allowing a user to overwrite any changes made.
        /// </remarks>
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
            });
        }
    }
}