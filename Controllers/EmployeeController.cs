using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ArtSofte_Test.Models;
using ArtSofte_Test.Models.Employee;

namespace ArtSofte_Test.Controllers
{
    // 2 создать класс менеджер, вынести туда эту логику, зарегистрировать его addTransient, заинжектить сюда 
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : BaseController<EmployeeController>
    {
        public static List<ViewEmployee> Employees { get; set; } = new List<ViewEmployee>();// 1) local dB 2)LINQ

        public EmployeeController(ILogger<EmployeeController> logger) : base(logger)
        {
        }

        [HttpGet] 
        public async Task GetList() 
        {
            try
            {
                _logger.LogInformation("User List");

                await SuccessResult(EmployeeController.Employees);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                await ErrorResult(ex.Message);
            }
        }

        [HttpGet("{id}")] 
        public async Task GetOne(string id) 
        {
<<<<<<< HEAD
            _logger.LogInformation("About user");
            return new JsonResult(new { Data = "User id"});
        }

        [HttpPost("add-{id}")]
        public IActionResult Add(string id)
        {
            _logger.LogInformation("Add user");

            

            return new JsonResult(new { Data = $"New User id - {id}"});
=======
            try
            {
            var employee = EmployeeController.Employees.FirstOrDefault(elem => elem.EmployeeId.ToString() == id);

            if(employee == null)
            {
                await ErrorResult("Employee not found");
            }

            await SuccessResult(employee);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                await ErrorResult(ex.Message);
            }
        }

        [HttpPost("add")]
        public async Task Add([FromBody] CreateEmployee createEmployee)
        {
            try
            {
                _logger.LogInformation("Add user");

                var newEmployee = new ViewEmployee()
                {
                    EmployeeId = Guid.NewGuid(),
                    FirstName = createEmployee.FirstName,
                    SecondName = createEmployee.SecondName,
                    CompanyRefId = createEmployee.CompanyRefId,
                    Age = createEmployee.Age
                };

                EmployeeController.Employees.Add(newEmployee);

            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                await ErrorResult(ex.Message);
            }
            
>>>>>>> 7ada2322d999ce6c3528fc97f07a32f6579ae088
        }

        [HttpPut("edit")]
        async public Task Edit([FromBody] ViewEmployee viewEmployee)
        {
            try
            {
                _logger.LogInformation("Edit user");

                var editEmployee = EmployeeController.Employees.FirstOrDefault(elem => elem.EmployeeId == viewEmployee.EmployeeId);
                if (editEmployee == null) 
                {
                  throw new Exception("employee not found");  
                }

                EmployeeController.Employees.Remove(editEmployee);
                
                editEmployee.FirstName = viewEmployee.FirstName;
                editEmployee.SecondName = viewEmployee.SecondName;
                editEmployee.Age = viewEmployee.Age;
                editEmployee.CompanyRefId = viewEmployee.CompanyRefId;

                EmployeeController.Employees.Add(editEmployee);

                await SuccessResult(EmployeeController.Employees);

            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                await ErrorResult(ex.Message);
            }
            
        }

        [HttpDelete("delete/{id}")]
        async public Task Delete(string id)
        {
<<<<<<< HEAD
            _logger.LogInformation("Delete user");
            return new JsonResult(new { Data = "New User"});
=======
            try
            {
            _logger.LogInformation("Delete user");
            
             var editEmployee = EmployeeController.Employees.FirstOrDefault(elem => elem.EmployeeId.ToString() == id);
                if (editEmployee == null) 
                {
                  throw new Exception("employee not found");  
                }

            EmployeeController.Employees.Remove(editEmployee);

            await SuccessResult(EmployeeController.Employees);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                await ErrorResult(ex.Message);
            }
>>>>>>> 7ada2322d999ce6c3528fc97f07a32f6579ae088
        }
    }
}
