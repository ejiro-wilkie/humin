using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.Data.SqlClient.DataClassification;

namespace Humin_Man.ViewModels.User
{
    /// <summary>
    /// Class that represents the create user input view model.
    /// </summary>
    public class UpdateUserInputViewModel : CreateUserInputViewModel
    {
        /// <summary>
        /// Gets or sets the id of the user.
        /// </summary>
        /// <value>
        /// The id of the user.
        /// </value>
        public long Id { get; set; }
    }
}
