using ArtSofte_Test.Models;
using ArtSofte_Test.Models.Employee;
using ArtSofte_Test.Models.Department;
using ArtSofte_Test.Models.Language;
using Microsoft.EntityFrameworkCore;

namespace ArtSofte_Test.DataBase
{
    public class InMemoryDbСontext : DbContext
    {
        
        public DbSet<ViewEmployee> Employees { get; set;}

        public DbSet<ViewLang> Langs { get; set;}

        public DbSet<ViewDepartment> Departments { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<EmployeeLanguage>()
            .HasKey(t => new { t.LangId, t.EmployeeId });

        modelBuilder.Entity<EmployeeLanguage>()
            .HasOne(sc => sc.Employee)
            .WithMany(s => s.EmployeeLanguages)
            .HasForeignKey(sc => sc.EmployeeId);

        modelBuilder.Entity<EmployeeLanguage>()
            .HasOne(sc => sc.Lang)
            .WithMany(c => c.EmployeeLanguages)
            .HasForeignKey(sc => sc.LangId);
        }

        public InMemoryDbСontext(DbContextOptions<InMemoryDbСontext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }
    }

}