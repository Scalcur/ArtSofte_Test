using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ArtSofte_Test.Models.Employee;
using ArtSofte_Test.Interfaces;

namespace ArtSofte_Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : BaseController<EmployeeController>
    {
        private IEmployeeManager _employeeManager { get; set; }

        public EmployeeController(
            ILogger<EmployeeController> logger,
            IEmployeeManager employeeManager
            ) : base(logger)
        {
            _employeeManager = employeeManager;
        }

        [HttpGet] 
        public async Task GetList() 
        {
            try
            {
                var employee = await _employeeManager.GetAllEmployee();
               await SuccessResult(employee);
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
            try
            {
               var employee = await _employeeManager.GetEmployeeById(id);
               await SuccessResult(employee);
            }
            catch(Exception ex)
            {
               _logger.LogError(ex.Message);
                await ErrorResult(ex.Message);
            }
        }

        [HttpPost("add")]
        public async Task<RedirectResult> Add([FromForm] CreateEmployee createEmployee)
        {
            try
            {
                var employee = await _employeeManager.AddEmployee(createEmployee);
                string url = "http://127.0.0.1:5500/wwwroot/Employee.html";
                RedirectResult redirectResult = new RedirectResult(url, true);
                return redirectResult;
            }
            catch(Exception ex)
            {
               _logger.LogError(ex.Message);  
                string url = "http://127.0.0.1:5500/wwwroot/Employee.html";
                RedirectResult redirectResult = new RedirectResult(url, true);
                return redirectResult;
            }
            
        }

        [HttpPut("edit")]
        async public Task<RedirectResult> Edit([FromForm] ViewEmployee viewEmployee)
        {
            try
            {
                var employee = await _employeeManager.EditEmployee(viewEmployee);
                string url = "http://127.0.0.1:5500/wwwroot/Employee.html";
                RedirectResult redirectResult = new RedirectResult(url, true);
                return redirectResult;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);  
                string url = "http://127.0.0.1:5500/wwwroot/Employee.html";
                RedirectResult redirectResult = new RedirectResult(url, true);
                return redirectResult;
            }
            
        }

        [HttpGet("delete/{id}")]
        public async Task<RedirectResult> Delete(string id)
        {
            try
            {
                var employee = await _employeeManager.DeleteEmployee(id);
                string url = "http://127.0.0.1:5500/wwwroot/Employee.html";
                RedirectResult redirectResult = new RedirectResult(url, true);
                return redirectResult;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);  
                string url = "http://127.0.0.1:5500/wwwroot/Employee.html";
                RedirectResult redirectResult = new RedirectResult(url, true);
                return redirectResult;
            }
        }
    }
}
