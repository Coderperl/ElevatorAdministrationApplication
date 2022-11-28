using ElevatorAdministrationApplication.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
using System;

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

        public async Task SeedDataAsync()
        {
            _context.Database.Migrate();
            SeedRoles();
            SeedUser();
            await SeedTechnicians().ConfigureAwait(false);
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
            CreateUserIfNotExist("Per", "Hejsan123#", new[] { "SecondLine Technician", "Field Technician" });
            CreateUserIfNotExist("Christoffer", "Hejsan123#", new[] { "SecondLine Technician", "Field Technician" });
            CreateUserIfNotExist("Amir", "Hejsan123#", new[] { "SecondLine Technician", "Field Technician" });
            CreateUserIfNotExist("Fredrik", "Hejsan123#", new[] { "SecondLine Technician", "Field Technician" });
            CreateUserIfNotExist("Joseph", "Hejsan123#", new[] { "SecondLine Technician", "Field Technician" });
            CreateUserIfNotExist("Hans", "Hejsan123#", new[] { "Field Technician" });
        }

        private void CreateUserIfNotExist(string name, string password, string[] roles)
        {
            if (_userManager.FindByEmailAsync(name + "@otis.com").Result != null) return;

            var user = new IdentityUser
            {
                UserName = name,
                Email = name.Split(" ")[0] + "@otis.com",
                EmailConfirmed = true
            };
            _userManager.CreateAsync(user, password).Wait();
            _userManager.AddToRolesAsync(user, roles).Wait();
        }

        private void SeedRoles()
        {
            CreateRoleIfNotExists("SecondLine Technician");
            CreateRoleIfNotExists("Field Technician");
        }

        private async Task SeedTechnicians()
        {
            if (_context.Technicians.Count() > 15)
                return;
            var techs =
            GenerateTechnicianFromUser();
            _context.Technicians.AddRange(techs);
            _context.SaveChanges();
        }


        private List<TechModel> GenerateTechnicianFromUser()
        {
            var fieldTech = _context.Roles.FirstOrDefault(e => e.NormalizedName == "Field Technician");
            var fieldTechs = _context.UserRoles.Where(e => e.RoleId == fieldTech.Id).ToList();


            List<TechModel> technicians = new List<TechModel>();

            foreach (var tech in fieldTechs)
            {
                foreach (var user in _context.Users)
                {
                    if (tech.UserId == user.Id)
                    {
                        var techmodel = new TechModel();
                        techmodel.Role = "Field Technician";
                        techmodel.Name = user.UserName;
                        technicians.Add(techmodel);
                    }
                }
            }

            return technicians;
        }
    }
}
