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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<ElevatorAdministrationApplication.Models.CaseModel> CaseModel { get; set; }
        public DbSet<TechModel> Technicians { get; set; }
    }
}