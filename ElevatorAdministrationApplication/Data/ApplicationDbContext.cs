using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ElevatorAdministrationApplication.Models;

namespace ElevatorAdministrationApplication.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ElevatorAdministrationApplication.Models.CaseModel> CaseModel { get; set; }
    }
}