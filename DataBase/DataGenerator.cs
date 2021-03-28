using ArtSofte_Test.Models.Employee;
using ArtSofte_Test.Models.Department;
using ArtSofte_Test.Models.Language;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System;

namespace ArtSofte_Test.DataBase
{
    public class DataGenerator
    {
        public static void InitializeEmployee(IServiceProvider serviceProvider)
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
                 new CreateEmployee
                 {
                     FirstName = "Test",
                     SecondName = "Test",
                     Age = 18,
                     Gender = "Male"
                 });

            context.Langs.Add(
                 new CreateLang
                 {
                     LangName = "Lang"
                 });

            context.Departments.Add(
                 new CreateDepartment
                 {
                     DepName = "Dep",
                     DepFloor = 10
                 });

             context.SaveChanges();
         }
     }
    }
}