using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ArtSofte_Test.Models.Department;
using ArtSofte_Test.Interfaces;

namespace ArtSofte_Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepController : BaseController<DepController>
    {
        private IDepManager _depManager { get; set; }

        public DepController(
            ILogger<DepController> logger,
            IDepManager depManager
            ) : base(logger)
        {
            _depManager = depManager;
        }

        [HttpGet] 
        public async Task GetList() 
        {
            try
            {
                var dep = await _depManager.GetAllDep();
               await SuccessResult(dep);
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
               var dep = await _depManager.GetDepById(id);
               await SuccessResult(dep);
            }
            catch(Exception ex)
            {
               _logger.LogError(ex.Message);
                await ErrorResult(ex.Message);
            }
        }

        [HttpPost("add")]
        public async Task Add([FromBody] CreateDepartment createDepartment)
        {
            try
            {
                var dep = await _depManager.AddDep(createDepartment); 
               await SuccessResult(dep);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                await ErrorResult(ex.Message);
            }
            
        }

        [HttpPut("edit")]
        async public Task Edit([FromBody] ViewDepartment viewDepartment)
        {
            try
            {
                var dep = await _depManager.EditDep(viewDepartment);
               await SuccessResult(dep);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                await ErrorResult(ex.Message);
            }
            
        }

        [HttpGet("delete/{id}")]
        async public Task Delete(string id)
        {
            try
            {
                var dep = await _depManager.DeleteDep(id);
               await SuccessResult(dep);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                await ErrorResult(ex.Message);
            }
        }
    }
}