using ArtSofte_Test.Models.Employee;
using ArtSofte_Test.Models.Department;
using ArtSofte_Test.Models.Language;
using Microsoft.EntityFrameworkCore;

namespace ArtSofte_Test.DataBase
{
    public class InMemoryDbСontext : DbContext
    {
        public InMemoryDbСontext(DbContextOptions<InMemoryDbСontext> options)
        : base(options)
        {

        }

        public DbSet<CreateEmployee> Employees { get; set;}

        public DbSet<CreateLang> Langs { get; set;}

        public DbSet<CreateDepartment> Departments { get; set;}
    }

}