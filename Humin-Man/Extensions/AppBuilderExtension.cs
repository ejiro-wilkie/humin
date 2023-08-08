using Microsoft.AspNetCore.Builder;

namespace Humin_Man.Extensions
{
    /// <summary>
    /// Extension class for app builder.
    /// </summary>
    public static class AppBuilderExtension
    {
        /// <summary>
        /// Configures the swagger.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <returns></returns>
        public static IApplicationBuilder ConfigureSwagger(this IApplicationBuilder builder)
        {
            builder.UseSwagger();

            builder.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint("/swagger/v1/swagger.json", "V1 endpoints");
            });

            return builder;
        }
    }
}
