using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.Logging;
using ArtSofte_Test.Interfaces;
using ArtSofte_Test.Models;
using ArtSofte_Test.Models.Employee;
using System.Collections.Generic;
using System;
using ArtSofte_Test.DataBase;
using Microsoft.EntityFrameworkCore;

namespace ArtSofte_Test.Manager
{
    public class EmployeeManager : IEmployeeManager
    {
        public static List<ViewEmployee> Employees { get; set; } = new List<ViewEmployee>();

        private InMemoryDbСontext _context;

        private readonly ILogger<EmployeeManager> _logger;

        public EmployeeManager(ILogger<EmployeeManager> logger, InMemoryDbСontext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<List<ViewEmployee>> GetAllEmployee()
        {
            var getList = _context.Employees
            .Include(dep => dep.Department)
            .Include(d => d.EmployeeLanguages)
            .ThenInclude(d => d.Lang)
            .ToList();
            
            return  getList;
        }
        
        public async Task<ViewEmployee> GetEmployeeById(string id)
        {
            var employee = _context.Employees.Find(Convert.ToInt32(id));

            if(employee == null)
            {
                throw new Exception("Employee not found");
            }

            return employee;
        }

        public async Task<string> AddEmployee(CreateEmployee createEmployee)
        {
            var department = _context.Departments.FirstOrDefault(el => el.Id == createEmployee.DepRefId);
            var language = _context.Langs.FirstOrDefault(el => el.Id == createEmployee.LangIdForCreate);

            var newEmployee = new ViewEmployee()
                {
                    FirstName = createEmployee.FirstName,
                    SecondName = createEmployee.SecondName,
                    DepRefId = createEmployee.DepRefId,
                    Age = createEmployee.Age,
                    Gender = createEmployee.Gender,
                    Department = department
                };

            _context.Employees.Add(newEmployee);
            _context.SaveChanges();

            var connectLang = new EmployeeLanguage { LangId = createEmployee.LangIdForCreate, EmployeeId = newEmployee.Id };
            newEmployee.EmployeeLanguages.Add(connectLang);
            _context.SaveChanges();

            return newEmployee.Id.ToString();
        }

        public async Task<string> EditEmployee(ViewEmployee viewEmployee)
        {
            _logger.LogInformation("Edit user");

                //var editEmployee = _context.Employees.Find(Convert.ToInt32(viewEmployee.Id));
                var editEmployee = _context.Employees.Find(viewEmployee.Id);
                if (editEmployee == null) 
                {
                  throw new Exception("Employee not found");  
                }

                _context.Employees.Remove(editEmployee);
                _context.SaveChanges();
                
                /*editEmployee.FirstName = viewEmployee.FirstName;
                editEmployee.SecondName = viewEmployee.SecondName;
                editEmployee.Age = viewEmployee.Age;
                editEmployee.Gender = viewEmployee.Gender;
                editEmployee.DepRefId = viewEmployee.DepRefId;
                editEmployee.EmployeeLanguages = viewEmployee.EmployeeLanguages;
                editEmployee.Id = viewEmployee.Id;

                _context.Employees.Add(editEmployee);
                _context.SaveChanges();*/

                var department = _context.Departments.FirstOrDefault(el => el.Id == viewEmployee.DepRefId);

                var newEmployee = new ViewEmployee()
                {
                    FirstName = viewEmployee.FirstName,
                    SecondName = viewEmployee.SecondName,
                    DepRefId = viewEmployee.DepRefId,
                    Age = viewEmployee.Age,
                    Gender = viewEmployee.Gender,
                    Department = department,
                    EmployeeLanguages = viewEmployee.EmployeeLanguages,
                    Id = viewEmployee.Id

                };

                _context.Employees.Add(newEmployee);
                _context.SaveChanges();

            return editEmployee.Id.ToString();
        }

        public async Task<string> DeleteEmployee(string id)
        {
            _logger.LogInformation("Delete user");
            
             var editEmployee = _context.Employees.Find(Convert.ToInt32(id));
            if (editEmployee == null) 
            {
                throw new Exception("Employee not found");  
            }

            _context.Employees.Remove(editEmployee);
            _context.SaveChanges();

            return editEmployee.Id.ToString();
        }
    }
}