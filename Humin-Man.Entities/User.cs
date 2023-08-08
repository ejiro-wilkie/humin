using Humin_Man.Core.Entities;
using Microsoft.AspNetCore.Identity;


namespace Humin_Man.Entities
{
    /// <summary>
    /// Class that implements the user.
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Identity.IdentityUser{Int64}" />
    /// <seealso cref="Humin_Man.Core.Entities.IBaseEntity" />
    public class User : IdentityUser<long>, IBaseEntity
    {
        /// <summary>
        /// Gets or sets a value indicating whether this instance is deleted.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is deleted; otherwise, <c>false</c>.
        /// </value>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>
        /// The image.
        /// </value>
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName { get; set; }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString() => $"{nameof(Id)}:{Id}|{nameof(Email)}:{Email}|{nameof(EmailConfirmed)}:{EmailConfirmed}|{nameof(NormalizedEmail)}:{NormalizedEmail}" +
            $"|{nameof(UserName)}:{UserName}|{nameof(PhoneNumber)}:{PhoneNumber}|{nameof(PhoneNumberConfirmed)}:{PhoneNumberConfirmed}|{nameof(Image)}:[{Image}]";
    }
}
