using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text.Unicode;
using static System.Text.Encoding;

namespace App.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<Role> Roles => Set<Role>();

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Role>().HasData(CreateRoles());

            List<User> users = new List<User>
            {
                CreateAdmin(), CreateUser()
            };

            modelBuilder.Entity<User>().HasData(users);
        }

        private User CreateAdmin()
        {
            CreatePasswordHash("AdminPassword", out byte[] passwordHash, out byte[] passwordSalt);

            var admin = new User
            {
                Id = 1,
                RoleId = 1,
                PasswordTestString = "AdminPassword",
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash,
                UserName = "Admin"
            };
            return admin;
        }

        private User CreateUser()
        {
            CreatePasswordHash("UserPassword", out byte[] passwordHash, out byte[] passwordSalt);

            var user = new User
            {
                Id = 2,
                RoleId = 2,
                PasswordTestString = "UserPassword",
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash,
                UserName = "User"
            };
            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA256())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(UTF8.GetBytes(password));
            }
        }

        private List<Role> CreateRoles()
        {
            List<Role> roles = new List<Role>
            {
                new() {Id = 1, RoleName = "Administrator"},
                new() {Id = 2, RoleName = "User"}
            };

            return roles;
        }
    }
}
