using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LibraryWebApp.Models
{
    public class RoleModel
    {
        [Required]
        public int RoleId { get; set; }

        [Required]
        [MaxLength(100, ErrorMessage = "Rolename can not be more the 100 characters long.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please.")]
        public string RoleName { get; set; }
    }
}