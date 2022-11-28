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

        public void SeedData()
        {
            _context.Database.Migrate();
            SeedRoles();
            SeedUser();
            SeedTechnicians();
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
            CreateUserIfNotExist("Per Görtz", "Hejsan123#", new[] { "SecondLine Technician", "Field Technician" });
            CreateUserIfNotExist("Christoffer Korell", "Hejsan123#", new[] { "SecondLine Technician", "Field Technician" });
            CreateUserIfNotExist("Amir Husseini", "Hejsan123#", new[] { "SecondLine Technician", "Field Technician" });
            CreateUserIfNotExist("Fredrik Andreassen", "Hejsan123#", new[] { "SecondLine Technician", "Field Technician" });
            CreateUserIfNotExist("Joseph O'brien", "Hejsan123#", new[] { "SecondLine Technician", "Field Technician" });
            CreateUserIfNotExist("Hans TippTopp", "Hejsan123#", new[] { "Field Technician" });
        }

        private void CreateUserIfNotExist(string name, string password, string[] roles)
        {
            if (_userManager.FindByEmailAsync(name + "@otis.com").Result != null) return;

            var user = new IdentityUser
            {
                UserName = name.Split(" ")[0] + "@otis.com",
                NormalizedUserName = name,
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

        private void SeedTechnicians()
        {

            var techs =
                GenerateTechnicianFromUser();
            _context.Technicians.AddRange(techs);
            _context.SaveChanges();
        }

        private List<TechModel> GenerateTechnicianFromUser()
        {
            var fieldTech = _context.Roles.FirstOrDefault(e => e.NormalizedName == "Field Technician");
            var fieldTechs = _context.UserRoles.Where(e => e.RoleId == fieldTech.Id);


            List<TechModel> technicians = new List<TechModel>();

            foreach (var tech in fieldTechs)
            {
                foreach (var user in _context.Users)
                {
                        if (tech.UserId == user.Id)
                        {
                            var name = user.NormalizedUserName.Split("@")[0];
                            var techmodel = new TechModel();
                            techmodel.Role = "Field Technician";
                            techmodel.Name = name;
                            technicians.Add(techmodel);
                        }             
                }
            }
            
            return technicians;
        }
    }
}
