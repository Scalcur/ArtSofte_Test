using System.Threading.Tasks;
using ArtSofte_Test.Models.Employee;
using System.Collections.Generic;

namespace ArtSofte_Test.Interfaces
{
    public interface IEmployeeManager
    {
        Task<List<ViewEmployee>> GetAllEmployee();
        Task<ViewEmployee> GetEmployeeById(string id);
        Task<string> AddEmployee(CreateEmployee createEmployee);
        Task<string> EditEmployee(ViewEmployee viewEmployee);
        Task<string> DeleteEmployee(string id);

    }
}