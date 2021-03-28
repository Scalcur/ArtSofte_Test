using ArtSofte_Test.Models.Employee;
using ArtSofte_Test.Models.Department;
using ArtSofte_Test.Models.Language;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System;

namespace ArtSofte_Test.DataBase
{
    public static class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
     {
         using (var context = new InMemoryDbСontext(
             serviceProvider.GetRequiredService<DbContextOptions<InMemoryDbСontext>>()))
         {
             
             if (context.Employees.Any())
             {
                 return;   
             }

             if (context.Langs.Any())
             {
                 return;   
             }

             if (context.Departments.Any())
             {
                 return;   
             }

             context.Employees.Add(
                 new ViewEmployee
                 {
                     FirstName = "Test",
                     SecondName = "Test",
                     Age = 18,
                     Gender = "Male",
                     EmployeeId = Guid.NewGuid()
                 });

            context.SaveChanges();

            context.Langs.Add(
                 new ViewLang
                 {
                    LangName = "Lang",
                    LangId = Guid.NewGuid()
                 });
            
            context.SaveChanges();

            context.Departments.Add(
                 new ViewDepartment
                 {
                     DepName = "Dep",
                     DepFloor = 10,
                     DepId = Guid.NewGuid()

                 });

             context.SaveChanges();
         }
     }
    }
}