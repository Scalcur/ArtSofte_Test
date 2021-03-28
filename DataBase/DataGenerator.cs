using ArtSofte_Test.Models.Employee;
using ArtSofte_Test.Models.Department;
using ArtSofte_Test.Models.Language;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System;
using System.Collections.Generic;
using ArtSofte_Test.Models;

namespace ArtSofte_Test.DataBase
{
    public static class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
     {
         using (var context = new InMemoryDbСontext(
             serviceProvider.GetRequiredService<DbContextOptions<InMemoryDbСontext>>()))
         {
             
             if (!context.Employees.Any() && !context.Langs.Any() && !context.Departments.Any())
             {
                
                ViewDepartment Dep1 = new ViewDepartment
                    {
                        DepName = "Dep1",
                        DepFloor = 10,
                        DepId = Guid.NewGuid()

                    };

                ViewDepartment Dep2 = new ViewDepartment
                    {
                        DepName = "Dep2",
                        DepFloor = 5,
                        DepId = Guid.NewGuid()

                    };

                ViewDepartment Dep3 = new ViewDepartment
                    {
                        DepName = "Dep3",
                        DepFloor = 10,
                        DepId = Guid.NewGuid()

                    };
                
                context.Departments.AddRange(new List<ViewDepartment> { Dep1, Dep2, Dep3 });

                context.SaveChanges();

                ViewLang Lang1 = new ViewLang
                    {
                        LangName = "Lang1",
                        LangId = Guid.NewGuid()
                    };

                ViewLang Lang2 = new ViewLang
                    {
                        LangName = "Lang2",
                        LangId = Guid.NewGuid()
                    };

                ViewLang Lang3 = new ViewLang
                    {
                        LangName = "Lang3",
                        LangId = Guid.NewGuid()
                    };
                
                context.Langs.AddRange(new List<ViewLang> { Lang1, Lang2, Lang3 });
                
                context.SaveChanges();

                ViewEmployee Employee1 = new ViewEmployee
                    {
                        FirstName = "Test1",
                        SecondName = "Test1",
                        Age = 18,
                        Gender = "Male",
                        DepRefId = Dep1.DepId,
                        EmployeeId = Guid.NewGuid()

                    };

                 ViewEmployee Employee2 = new ViewEmployee
                    {
                        FirstName = "Test2",
                        SecondName = "Test2",
                        Age = 20,
                        Gender = "Female",
                        DepRefId = Dep2.DepId,
                        EmployeeId = Guid.NewGuid()
                    };

                ViewEmployee Employee3 = new ViewEmployee
                    {
                        FirstName = "Test3",
                        SecondName = "Test3",
                        Age = 40,
                        Gender = "Male",
                        DepRefId = Dep3.DepId,
                        EmployeeId = Guid.NewGuid()
                    };
                
                context.Employees.AddRange(new List<ViewEmployee> { Employee1, Employee2, Employee3 });

                context.SaveChanges();

                Employee1.EmployeeLanguages.Add(new EmployeeLanguage { LangId = Lang1.LangId, EmployeeId = Employee1.EmployeeId });
                Employee2.EmployeeLanguages.Add(new EmployeeLanguage { LangId = Lang2.LangId, EmployeeId = Employee2.EmployeeId });
                Employee3.EmployeeLanguages.Add(new EmployeeLanguage { LangId = Lang3.LangId, EmployeeId = Employee3.EmployeeId });

                context.SaveChanges();

             }
         }
     }
    }
}