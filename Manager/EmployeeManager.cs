using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.Logging;
using ArtSofte_Test.Interfaces;
using ArtSofte_Test.Models.Employee;
using System.Collections.Generic;
using System;

namespace ArtSofte_Test.Manager
{
    public class EmployeeManager : IEmployeeManager
    {
        public static List<ViewEmployee> Employees { get; set; } = new List<ViewEmployee>();

        private readonly ILogger<EmployeeManager> _logger;

        public EmployeeManager(ILogger<EmployeeManager> logger)
        {
            _logger = logger;
        }

        public async Task<List<ViewEmployee>> GetAllEmployee()
        {
            return EmployeeManager.Employees;
        }
        
        public async Task<ViewEmployee> GetEmployeeById(string id)
        {
            var employee = EmployeeManager.Employees.FirstOrDefault(elem => elem.EmployeeId.ToString() == id);

            if(employee == null)
            {
                throw new Exception("Employee not found");
            }

            return employee;
        }

        public async Task<string> AddEmployee(CreateEmployee createEmployee)
        {
            var newEmployee = new ViewEmployee()
                {
                    EmployeeId = Guid.NewGuid(),
                    FirstName = createEmployee.FirstName,
                    SecondName = createEmployee.SecondName,
                    CompanyRefId = createEmployee.CompanyRefId,
                    Age = createEmployee.Age,
                    Gender = createEmployee.Gender
                };

            EmployeeManager.Employees.Add(newEmployee);

            return newEmployee.EmployeeId.ToString();
        }

        public async Task<string> EditEmployee(ViewEmployee viewEmployee)
        {
            _logger.LogInformation("Edit user");

                var editEmployee = EmployeeManager.Employees.FirstOrDefault(elem => elem.EmployeeId == viewEmployee.EmployeeId);
                if (editEmployee == null) 
                {
                  throw new Exception("Employee not found");  
                }

                EmployeeManager.Employees.Remove(editEmployee);
                
                editEmployee.FirstName = viewEmployee.FirstName;
                editEmployee.SecondName = viewEmployee.SecondName;
                editEmployee.Age = viewEmployee.Age;
                editEmployee.Gender = viewEmployee.Gender;
                editEmployee.CompanyRefId = viewEmployee.CompanyRefId;

                EmployeeManager.Employees.Add(editEmployee);

            return editEmployee.EmployeeId.ToString();
        }

        public async Task<string> DeleteEmployee(string id)
        {
            _logger.LogInformation("Delete user");
            
             var editEmployee = EmployeeManager.Employees.FirstOrDefault(elem => elem.EmployeeId.ToString() == id);
            if (editEmployee == null) 
            {
                throw new Exception("Employee not found");  
            }

            EmployeeManager.Employees.Remove(editEmployee);

            return editEmployee.EmployeeId.ToString();
        }
    }
}