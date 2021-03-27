using System.Threading.Tasks;
using ArtSofte_Test.Models.Department;
using System.Collections.Generic;

namespace ArtSofte_Test.Interfaces
{
    public interface IDepManager
    {
        Task<List<ViewDepartment>> GetAllDep();
        Task<ViewDepartment> GetDepById(string id);
        Task<string> AddDep(CreateDepartment createDepartment);
        Task<string> EditDep(ViewDepartment viewDepartment);
        Task<string> DeleteDep(string id);
    }
}