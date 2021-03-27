using ArtSofte_Test.Controllers;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace ArtSofte_Test.Manager
{
    public class EmployeeManager 
    {
        public EmployeeManager(ILogger<EmployeeManager> logger) : base(logger)
        {
        }

        public async Task _GetList()
        {
            _logger.LogInformation("User List");

            await SuccessResult(EmployeeController.Employees);
        }

        public async Task _GetById(string id)
        {
            var employee = EmployeeController.Employees.FirstOrDefault(elem => elem.EmployeeId.ToString() == id);

            if(employee == null)
            {
                await ErrorResult("Employee not found");
            }

            await SuccessResult(employee);
        }

        

        public async Task _TrowException(System.Exception ex)
        {
             _logger.LogError(ex.Message);
            await ErrorResult(ex.Message);
        }
    }
}