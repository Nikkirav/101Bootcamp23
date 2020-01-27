namespace LibraryWebApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.ComponentModel.DataAnnotations;

    public class UserModel : BaseModel
    {

        // properties

        [Required(ErrorMessage ="First name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Password must be min of 8 character and max of 20 character.")]
        //TODO: other requirements for password at least one number and one special character !@#$%^&*
        public string Password { get; set; }

    }
}