using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.Logging;
using ArtSofte_Test.Interfaces;
using ArtSofte_Test.Models.Department;
using System.Collections.Generic;
using System;
using ArtSofte_Test.DataBase;

namespace ArtSofte_Test.Manager
{
    public class DepManager : IDepManager
    {
        public static List<ViewDepartment> Deps { get; set; } = new List<ViewDepartment>();
        private InMemoryDbСontext _context;

        private readonly ILogger<DepManager> _logger;

        public DepManager(ILogger<DepManager> logger, InMemoryDbСontext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<List<ViewDepartment>> GetAllDep()
        {
            return _context.Departments.ToList();
        }
        
        public async Task<ViewDepartment> GetDepById(string id)
        {
            var dep = DepManager.Deps.FirstOrDefault(elem => elem.DepId.ToString() == id);

            if(dep == null)
            {
                throw new Exception("Department not found");
            }

            return dep;
        }

        public async Task<string> AddDep(CreateDepartment createDepartment)
        {
            var newDep = new ViewDepartment()
                {
                    DepId = Guid.NewGuid(),
                    DepName = createDepartment.DepName,
                    DepFloor = createDepartment.DepFloor
                };

            DepManager.Deps.Add(newDep);

            return newDep.DepId.ToString();
        }

        public async Task<string> EditDep(ViewDepartment viewDepartment)
        {
            _logger.LogInformation("Edit department");

                var editDep = DepManager.Deps.FirstOrDefault(elem => elem.DepId == viewDepartment.DepId);
                if (editDep == null) 
                {
                  throw new Exception("Department not found");  
                }

                DepManager.Deps.Remove(editDep);
                
                editDep.DepId = viewDepartment.DepId;
                editDep.DepName = viewDepartment.DepName;
                editDep.DepFloor = viewDepartment.DepFloor;
                
                DepManager.Deps.Add(editDep);

            return editDep.DepId.ToString();
        }

        public async Task<string> DeleteDep(string id)
        {
            _logger.LogInformation("Delete department");
            
             var editDep = DepManager.Deps.FirstOrDefault(elem => elem.DepId.ToString() == id);
            if (editDep == null) 
            {
                throw new Exception("Department not found");  
            }

            DepManager.Deps.Remove(editDep);

            return editDep.DepId.ToString();
        }
    }
}