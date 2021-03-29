using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ArtSofte_Test.Models.Language;
using ArtSofte_Test.Interfaces;

namespace ArtSofte_Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LangController : BaseController<LangController>
    {
        private ILangManager _langManager { get; set; }

        public LangController(
            ILogger<LangController> logger,
            ILangManager langManager
            ) : base(logger)
        {
            _langManager = langManager;
        }

        [HttpGet] 
        public async Task GetList() 
        {
            try
            {
                var lang = await _langManager.GetAllLang();
               await SuccessResult(lang);
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
               var lang = await _langManager.GetLangById(id);
               await SuccessResult(lang);
            }
            catch(Exception ex)
            {
               _logger.LogError(ex.Message);
                await ErrorResult(ex.Message);
            }
        }

        [HttpPost("add")]
        public async Task Add([FromBody] CreateLang createLang)
        {
            try
            {
                var lang = await _langManager.AddLang(createLang); 
               await SuccessResult(lang);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                await ErrorResult(ex.Message);
            }
            
        }

        [HttpPut("edit")]
        async public Task Edit([FromBody] ViewLang viewLang)
        {
            try
            {
                var lang = await _langManager.EditLang(viewLang);
               await SuccessResult(lang);
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
                var lang = await _langManager.DeleteLang(id);
               await SuccessResult(lang);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.Message);
                await ErrorResult(ex.Message);
            }
        }
    }
}