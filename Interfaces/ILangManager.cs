using System.Threading.Tasks;
using ArtSofte_Test.Models.Language;
using System.Collections.Generic;

namespace ArtSofte_Test.Interfaces
{
    public interface ILangManager
    {
        Task<List<ViewLang>> GetAllLang();
        Task<ViewLang> GetLangById(string id);
        Task<string> AddLang(CreateLang createLang);
        Task<string> EditLang(ViewLang viewLang);
        Task<string> DeleteLang(string id);
    }
}