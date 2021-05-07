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

        public string Salt { get; set; }

        public int UserId { get; set;}

        public int RoleId { get; set; }

        public string RoleName { get; set; }

        // list of roles
        public IEnumerable<RoleModel> RoleList { get; set; }

        // selected value
        public int SelectedRoleId { get; set; }

        // constructors
        public UserModel()
        {
            this.RoleList = new List<RoleModel>() { 
                new RoleModel { RoleId = 1, RoleName = "Administrator"}, 
                new RoleModel { RoleId = 2, RoleName = "Librarian" }, 
                new RoleModel { RoleId = 3, RoleName = "Patron"} };
        
        }

    }
}