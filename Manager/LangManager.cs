using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.Logging;
using ArtSofte_Test.Interfaces;
using ArtSofte_Test.Models.Language;
using System.Collections.Generic;
using System;
using ArtSofte_Test.DataBase;

namespace ArtSofte_Test.Manager
{
    public class LangManager : ILangManager
    {
        public static List<ViewLang> Langs { get; set; } = new List<ViewLang>();

        private InMemoryDbСontext _context;

        private readonly ILogger<LangManager> _logger;

        public LangManager(ILogger<LangManager> logger, InMemoryDbСontext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<List<ViewLang>> GetAllLang()
        {
            return _context.Langs.ToList();
        }
        
        public async Task<ViewLang> GetLangById(string id)
        {
            var lang = LangManager.Langs.FirstOrDefault(elem => elem.LangId.ToString() == id);

            if(lang == null)
            {
                throw new Exception("Language not found");
            }

            return lang;
        }

        public async Task<string> AddLang(CreateLang createLang)
        {
            var newLang = new ViewLang()
                {
                    LangId = Guid.NewGuid(),
                    LangName = createLang.LangName
                };

            LangManager.Langs.Add(newLang);

            return newLang.LangId.ToString();
        }

        public async Task<string> EditLang(ViewLang viewLang)
        {
            _logger.LogInformation("Edit language");

                var editLang = LangManager.Langs.FirstOrDefault(elem => elem.LangId == viewLang.LangId);
                if (editLang == null) 
                {
                  throw new Exception("Language not found");  
                }

                LangManager.Langs.Remove(editLang);
                
                editLang.LangId = viewLang.LangId;
                editLang.LangName = viewLang.LangName;
                
                LangManager.Langs.Add(editLang);

            return editLang.LangId.ToString();
        }

        public async Task<string> DeleteLang(string id)
        {
            _logger.LogInformation("Delete language");
            
             var editLang = LangManager.Langs.FirstOrDefault(elem => elem.LangId.ToString() == id);
            if (editLang == null) 
            {
                throw new Exception("Language not found");  
            }

            LangManager.Langs.Remove(editLang);

            return editLang.LangId.ToString();
        }
    }
}