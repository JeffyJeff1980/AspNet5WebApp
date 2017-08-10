using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using InstaCore.Models;
using System;
using System.Linq;

namespace InstaCore.Data.Migrations
{
    public class UserDataSeed
    {
        private ApplicationDbContext _context;

        public UserDataSeed(ApplicationDbContext context)
        {
            _context = context;
        }

        public async void SeedAdminUser()
        {
            var user = new ApplicationUser
            {
                UserName = "admin@lmpresearch.com",
                NormalizedUserName = "admin@lmpresearch.com",
                Email = "admin@lmpresearch.com",
                NormalizedEmail = "admin@lmpresearch.com",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            var roleStore = new RoleStore<IdentityRole>(_context);

            if (!_context.Roles.Any(r => r.Name == "Admin"))
            {
                await roleStore.CreateAsync(new IdentityRole { Name = "Admin", NormalizedName = "Admin" });
                await roleStore.CreateAsync(new IdentityRole { Name = "Member", NormalizedName = "Member" });
            }

            if (!_context.Users.Any(u => u.UserName == user.UserName))
            {
                var password = new PasswordHasher<ApplicationUser>();
                var hashed = password.HashPassword(user, "p@ssw0rd");
                user.PasswordHash = hashed;
                var userStore = new UserStore<ApplicationUser>(_context);
                await userStore.CreateAsync(user);
                await userStore.AddToRoleAsync(user, "Admin");
            }

            await _context.SaveChangesAsync();
        }
    }
}