using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ArtSofte_Test.Controllers
{
    // 2 создать класс менеджер, вынести туда эту логику, зарегистрировать его addTransient, заинжектить сюда 
    [ApiController]
    [Route("[controller]")] // path /employee
    public class EmployeeController : BaseController<EmployeeController>
    {
        private List<object> Users { get; set; } // 1) local dB 2)LINQ

        public EmployeeController(ILogger<EmployeeController> logger) : base(logger)
        {
        }

        [HttpGet] 
        public async Task GetList() 
        {
            try
            {
                _logger.LogInformation("User List");
                var data = new { Data = "User List"};

                await SuccessResult(data);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                await ErrorResult(ex.Message);
            }
        }

        [HttpGet("{id}")] 
        public IActionResult GetOne(string id) 
        {
            _logger.LogInformation("About user");
            return new JsonResult(new { Data = "User id"});
        }

        [HttpPost("add-{id}")]
        public IActionResult Add(string id)
        {
            _logger.LogInformation("Add user");

            

            return new JsonResult(new { Data = $"New User id - {id}"});
        }

        [HttpPut("edit")]
        public IActionResult Edit()
        {
            _logger.LogInformation("Edit user");
            return new JsonResult(new { Data = "Edit User"});
        }

        [HttpDelete("delete")]
        public IActionResult Delete()
        {
            _logger.LogInformation("Delete user");
            return new JsonResult(new { Data = "New User"});
        }
    }
}
