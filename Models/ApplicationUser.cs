using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using InstaCore.Models.DataTransferObjects;
using System.ComponentModel.DataAnnotations;

namespace InstaCore.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public override string Id { get => base.Id; set => base.Id = value; }
        [NotMapped]
        [Required]
        public string RoleName { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public override string Email { get => base.Email; set => base.Email = value; }
        [NotMapped]
        public string Password { get; set; }
    }
}
