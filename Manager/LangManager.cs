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
            var lang = _context.Langs.Find(Convert.ToInt32(id));

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

            _context.Langs.Add(newLang);
            _context.SaveChanges();

            return newLang.LangId.ToString();
        }

        public async Task<string> EditLang(ViewLang viewLang)
        {
            _logger.LogInformation("Edit language");

                var editLang = _context.Langs.Find(Convert.ToInt32(viewLang.Id));
                if (editLang == null) 
                {
                  throw new Exception("Language not found");  
                }

                _context.Langs.Remove(editLang);
                _context.SaveChanges();
                
                editLang.LangId = viewLang.LangId;
                editLang.LangName = viewLang.LangName;
                
                _context.Langs.Add(editLang);
                _context.SaveChanges();

            return editLang.LangId.ToString();
        }

        public async Task<string> DeleteLang(string id)
        {
            _logger.LogInformation("Delete language");
            
             var editLang = _context.Langs.Find(Convert.ToInt32(id));
            if (editLang == null) 
            {
                throw new Exception("Language not found");  
            }

            _context.Langs.Remove(editLang);
            _context.SaveChanges();

            return editLang.LangId.ToString();
        }
    }
}