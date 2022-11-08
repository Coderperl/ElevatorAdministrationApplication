using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ElevatorAdministrationApplication.Data
{
    public class DataInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public DataInitializer(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public void SeedData()
        {
            _context.Database.Migrate();
            SeedRoles();
            SeedUser();
        }

        private void CreateRoleIfNotExists(string rolename)
        {
            if (_context.Roles.Any(e => e.Name == rolename))
                return;
            _context.Roles.Add(new IdentityRole { Name = rolename, NormalizedName = rolename });
            _context.SaveChanges();
        }

        private void SeedUser()
        {
            CreateUserIfNotExist("Stefan", "Hejsan123#", "Admin");
        }

        private void CreateUserIfNotExist(string name, string password, string role)
        {
            if (_userManager.FindByEmailAsync(name + "@gmail.com").Result != null) return;

            var user = new IdentityUser
            {
                UserName = name,
                Email = name + "@gmail.com",
                EmailConfirmed = true
            };
            _userManager.CreateAsync(user, password).Wait();
            _userManager.AddToRoleAsync(user, role).Wait();
        }

        private void SeedRoles()
        {
            CreateRoleIfNotExists("SecondLine Technician");
            CreateRoleIfNotExists("Field Technician");
        }
    }
}
