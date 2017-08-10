using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InstaCore.Models.DataTransferObjects
{
    public class UserDto
    {
        public string Id { get; set; }
        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        public string Password { get; set; }
        [Required]
        public string RoleName { get; set; }
    }
}
